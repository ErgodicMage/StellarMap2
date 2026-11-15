using System;
using System.IO;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

using StellarMap.Core;
using StellarMap.PhysicalStellarBuilder;
using StellarMap.Progression;
using StellarMap.ProgressionStellarBuilder;

IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    //.AddEnvironmentVariables()
    .Build();
var dataDir = config["DataPath"];

BuildEarthMap(dataDir!);

static void BuildEarthMap(string folder)
{
    Console.WriteLine("Creating Earth");

    ProgressionMap map = new("Earth");
    map.DefaultMetaData();

    var result = BuildSolarSystem.Earth(map);
    if (!result.Success)
    {
        Console.WriteLine($"Could not Build Earth {result.ErrorMessage}");
        return;
    }

    SaveMap(folder, "ProgressionEarth.json", map);
}

static void SaveMap(string folder, string jsonFileName, IProgressionMap map)
{
    var jsonOptions = new JsonSerializerOptions()
    {
        WriteIndented = true
    };

    var json = JsonSerializer.Serialize<IStellarMap>(map, jsonOptions);

    var fileName = Path.Combine(folder, jsonFileName);
    File.WriteAllText(fileName, json);

    Console.WriteLine($"Saved {fileName}");
}