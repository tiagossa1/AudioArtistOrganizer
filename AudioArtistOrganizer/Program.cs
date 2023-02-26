using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using AudioArtistOrganizer.Interfaces;
using AudioArtistOrganizer.Services;
using AudioArtistOrganizer.Validators;

var configuration =  new ConfigurationBuilder()
    .AddJsonFile("appsettings.json");
            
var config = configuration.Build();
var musicDirectoryPath = config.GetSection("MusicFolderPath").Value;
var folderPathToCreate = config.GetSection("FolderPathToCreate").Value;

var builder = new ServiceCollection()
    .AddLogging(configure => configure.AddConsole()).Configure<LoggerFilterOptions>(options => options.MinLevel = LogLevel.Information)
    .AddSingleton<IPathValidator, PathValidator>()
    .AddSingleton<IStringManipulator, StringManipulator>()
    .AddSingleton<IReadDirectoryService, ReadDirectoryService>()
    .AddSingleton<IReadMusicFile, ReadMusicFile>()
    .AddSingleton<IWriteDirectoryService, WriteDirectoryService>()
    .AddSingleton<IInputValidator, InputValidator>()
    .BuildServiceProvider();

var pathValidator = builder.GetRequiredService<IPathValidator>();
var inputValidator = builder.GetRequiredService<IInputValidator>();
var readDirectoryService = builder.GetRequiredService<IReadDirectoryService>();
var readMusicService = builder.GetRequiredService<IReadMusicFile>();
var writeDirectoryService = builder.GetRequiredService<IWriteDirectoryService>();
var logger = builder.GetRequiredService<ILogger<Program>>();

var isPathValid = pathValidator.IsPathValid(musicDirectoryPath);
if (!isPathValid)
{
    logger.LogError("Cannot continue due to missing or invalid music folder path.");
    return;
}

var musicFilePaths = readDirectoryService.FindAllMusicFiles(musicDirectoryPath);
var singersNames = new List<string>();

for (var i = 0; i < musicFilePaths.Count; i++)
{
    logger.LogInformation("Processing {itemNumber}/{pathsCount}", i + 1, musicFilePaths.Count);
    
    var metadata = readMusicService.GetMusicMetadataByPath(musicFilePaths[i]);
    if (string.IsNullOrWhiteSpace(metadata?.Singer))
    {
        continue;
    }

    if (!singersNames.Any(singer => string.Equals(singer, metadata.Singer, StringComparison.InvariantCultureIgnoreCase)))
    {
        singersNames.Add(metadata.Singer);
    }
}

foreach (var singerName in singersNames.OrderBy(singerName => singerName))
{
    Console.Write($"> Do you want to create a folder for singer {singerName}? (y/n): ");
    var isUserInputPositive = inputValidator.IsUserInputPositive(Console.ReadLine());

    if (!isUserInputPositive)
    {
        continue;
    }

    var result = writeDirectoryService.CreateArtistFolder(folderPathToCreate, singerName);
    if (!result)
    {
        logger.LogError("Could not create main folder for singer {singerName}.", singerName);
        continue;
    }

    var subFoldersCreated = writeDirectoryService.CreateMusicSubfolders(folderPathToCreate, singerName);
    if (subFoldersCreated.Count > 0)
    {
        logger.LogInformation("Created {subFoldersPath}.", string.Join(Environment.NewLine, subFoldersCreated));
    }
    else
    {
        logger.LogInformation("Subfolders already created for singer {singerName}.", singerName);
    }
}

Console.ReadKey();