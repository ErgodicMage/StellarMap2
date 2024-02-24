namespace CoreTests;

public class StellarObjectEqualityTests
{
    [Fact]
    public void DictionaryEqual()
    {
        Dictionary<string, string> dictionary1 = new()
        {
            {"Key1", "Value1" },
            {"Key2", "Value2" }
        };

        Dictionary<string, string> dictionary2 = new()
        {
            {"Key1", "Value1" },
            {"Key2", "Value2" }
        };

        Assert.True(CommonFunctionality.CompareDictionaries(dictionary1, dictionary2));
    }

    [Fact] public void DictionaryNotEqual() 
    {
        Dictionary<string, string> dictionary1 = new()
        {
            {"Key1", "Value1" },
            {"Key2", "Value2" }
        };

        Dictionary<string, string> dictionary2 = new()
        {
            {"Key1", "Value2" },
        };

        Assert.False(CommonFunctionality.Equals(dictionary1, dictionary2));

        Dictionary<string, string> dictionary3 = new()
        {
            {"Key3", "Value3" },
            {"Key4", "Value4" }
        };

        Assert.False(CommonFunctionality.Equals(dictionary1, dictionary3));
    }

    [Fact]
    public void AsteroidReferenceEqual()
    {
        IStellarMap map = new StandardStellarMap();

        var result = StellarObjectBuilder.CreateAsteroid("Vesta", MapIdentifierGenerator.Instance, map).Build();
        Assert.True(result.Success);
        var asteroid = result.Value;
        Assert.NotNull(asteroid);

        Assert.Equal(asteroid, asteroid);
    }

    [Fact]
    public void AsteroidEqual()
    {
        IStellarMap map = new StandardStellarMap();

        var result = StellarObjectBuilder.CreateAsteroid("Vesta", MapIdentifierGenerator.Instance, map).Build();
        Assert.True(result.Success);
        var asteroid1 = result.Value;
        Assert.NotNull(asteroid1);

        result = StellarObjectBuilder.CreateAsteroid("Vesta", asteroid1.Identifier, map).Build();
        Assert.True(result.Success);
        var asteroid2 = result.Value;
        Assert.NotNull(asteroid2);

        Assert.Equal(asteroid1, asteroid2);
    }

    [Fact]
    public void AsteroidNotEqual()
    {
        IStellarMap map = new StandardStellarMap();

        var result = StellarObjectBuilder.CreateAsteroid("Vesta", MapIdentifierGenerator.Instance, map).Build();
        Assert.True(result.Success);
        var asteroid1 = result.Value;
        Assert.NotNull(asteroid1);

        result = StellarObjectBuilder.CreateAsteroid("Vesta2", asteroid1.Identifier, map).Build();
        Assert.True(result.Success);
        var asteroid2 = result.Value;
        Assert.NotNull(asteroid2);

        Assert.NotEqual(asteroid1, asteroid2);

        result = StellarObjectBuilder.CreateAsteroid("Vesta", asteroid1.Identifier, map).Build();
        Assert.True(result.Success);
        var asteroid3 = result.Value;
        asteroid3.ParentIdentifier = new Identifier("asteroid");
        Assert.NotNull(asteroid3);

        Assert.NotEqual(asteroid1, asteroid3);
    }

    [Fact]
    public void PlanetEarthEqual()
    {
        IStellarMap map1 = new StandardStellarMap();
        var planetEarth1 = Builders.BuildEarth(map1);
        Assert.NotNull(planetEarth1);

        IStellarMap map2 = new StandardStellarMap();
        var planetEarth2 = Builders.BuildEarth(map2);
        Assert.NotNull(planetEarth2);

        Assert.Equal(planetEarth1, planetEarth2);
    }

    [Fact]
    public void PlanetEarthNotEqual()
    {
        IStellarMap map1 = new StandardStellarMap();
        var planetEarth1 = Builders.BuildEarth(map1);
        Assert.NotNull(planetEarth1);

        IStellarMap map2 = new StandardStellarMap();
        var planetEarth2 = Builders.BuildEarth(map2);
        planetEarth2.Properties[PropertiesConstant.DESCRIPTION] = "Earth of course";
        Assert.NotNull(planetEarth2);

        Assert.NotEqual(planetEarth1, planetEarth2);

        IStellarMap map3 = new StandardStellarMap();
        var planetEarth3 = Builders.BuildEarth(map3);
        var newSatelite = StellarObjectBuilder.CreateSatelite("Not Moon", MapIdentifierGenerator.Instance, map3).Build();
        planetEarth3.AddSatelite(newSatelite);
        Assert.NotNull(planetEarth3);

        Assert.NotEqual(planetEarth1, planetEarth3);
    }

    [Fact]
    public void SolEqual()
    {
        IStellarMap map1 = new StandardStellarMap();
        var sol1 = Builders.BuildSol(map1);
        Assert.NotNull(sol1);

        IStellarMap map2 = new StandardStellarMap();
        var sol2 = Builders.BuildSol(map2);
        Assert.NotNull(sol2);

        Assert.Equal(sol1, sol2);
    }

    [Fact]
    public void SolNotEqual()
    {
        IStellarMap map1 = new StandardStellarMap();
        var sol1 = Builders.BuildSol(map1);
        Assert.NotNull(sol1);

        IStellarMap map2 = new StandardStellarMap();
        var sol2 = Builders.BuildSol(map2);
        Assert.NotNull(sol2);
        // remove Pluto and Ceres from Sol Planets
        var planetsRemove = map2.Planets?.Where(p => p.Value.IsDwarf);
        foreach (var planet in planetsRemove!)
        {
            sol2.Planets?.Remove(planet.Value.Name!);
            map2.Planets?.Remove(planet.Value.Identifier.Id);
        }

        Assert.NotEqual(sol1, sol2);

        IStellarMap map3 = new StandardStellarMap();
        var sol3 = Builders.BuildSol(map3);
        Assert.NotNull(sol3);
        // Add another asteroid
        sol3.AddAsteroid(new Asteroid("NewAsteroid", 
            MapIdentifierGenerator.Instance.GenerateIdentifier(StellarObjectType.Asteroid, map3), map3));

        Assert.NotEqual(sol1, sol3);

        IStellarMap map4 = new StandardStellarMap();
        var sol4 = Builders.BuildSol(map4);
        Assert.NotNull(sol4);
        sol4.StellarClass = "Yellow";

        Assert.NotEqual(sol1, sol4);
    }

    [Fact]
    public void MapReferenceEqual()
    {
        IStellarMap map = new StandardStellarMap();
        var earth = Builders.BuildEarth(map);
        Assert.NotNull(earth);

        Assert.Equal(map, map);
    }

    [Fact]
    public void MapNotEqual()
    {
        IStellarMap map1 = new StandardStellarMap();
        var earth1 = Builders.BuildEarth(map1);
        Assert.NotNull(earth1);

        IStellarMap map2 = new StandardStellarMap();
        var earth2 = Builders.BuildEarth(map2);
        Assert.NotNull(earth2);

        Assert.NotEqual(map1, map2);
    }
}
