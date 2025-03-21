﻿using Microsoft.Extensions.Configuration;

IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    //.AddEnvironmentVariables()
    .Build();
var dataDir = config["DataPath"];

BuildEarthMap(dataDir!);
BuildSolMap(dataDir!);
BuildNearestStarsMap(dataDir!);

void BuildEarthMap(string folder)
{
    Console.WriteLine("Creating Earth");

    StandardStellarMap map = new("Earth");
    map.DefaultMetaData();

    var result = BuildPlanets.Earth(map);
    if (!result.Success)
    {
        Console.WriteLine($"Could not Build Earth {result.ErrorMessage}");
        return;
    }

    SaveMap(folder, "PhysicalEarth.json", map);
}

void BuildSolMap(string folder)
{
    Console.WriteLine("Creating Sol");

    StandardStellarMap map = new("Sol");
    map.DefaultMetaData();

    var result = BuildStars.Sol(map);
    if (!result.Success)
    {
        Console.WriteLine($"Could not Build Earth {result.ErrorMessage}");
        return;
    }

    SaveMap(folder, "PhysicalSol.json", map);
}

void BuildNearestStarsMap(string folder)
{
    Console.WriteLine("Creating nearest stars");

    StandardStellarMap map = new("Nearest Stars");
    map.DefaultMetaData();

    var result = BuildNearestStars.NearestStars(map);
    if (!result.Success)
    {
        Console.WriteLine($"Could not build nearest stars map {result.ErrorMessage}");
        return;
    }

    SaveMap(folder, "PhysicalNearestStars.json", map);
}


void SaveMap(string folder, string jsonFileName, IStellarMap map)
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
