namespace CoreTests;

public class BuilderTests
{
    [Fact]
    public void BuildEarth()
    {
        IStellarMap map = new StellarMap.Core.StellarMap();
        var earth = Builders.BuildEarth(map);

        Assert.NotNull(earth);
        Assert.Equal("Earth", earth.Name);
        Assert.Equal("SOL-03", earth.Properties[PropertiesConstant.DESIGNATION]);
        Assert.NotNull(earth.Satelites);
        Assert.Single(earth.Satelites);
        var result = earth.GetSatelite("Moon");
        Assert.True(result.Success);

        Identifier identifier = new("Satelite-00001");
        result = earth.GetSatelite(identifier); 
        Assert.True(result.Success);

        Assert.Single(map.Planets!);
        Assert.Single(map.Satelites!);
        Assert.Null(map.Stars);
        Assert.Null(map.Asteroids);
        Assert.Null(map.Comets);
    }

    [Fact]
    public void BuildEarthFail()
    {
        IStellarMap map = new StellarMap.Core.StellarMap();
        var moon = StellarObjectBuilder.CreateSatelite("Moon", MapIdentifierGenerator.Instance, map).Build();
        
        Assert.True(moon.Success);
        Assert.NotNull(moon.Value);

        // Add moon twice
        var earth = PlanetBuilder.Create("Earth", MapIdentifierGenerator.Instance, map)
            .AddSatelite(moon)
            .AddSatelite(moon)
            .Build();

        Assert.False(earth.Success);
        Assert.Null(earth.Value);

        var mapAdd = map.Add<Planet>(earth.Value!);

        Assert.False(mapAdd.Success);
    }

    [Fact]
    public void BuildMercury()
    {
        IStellarMap map = new StellarMap.Core.StellarMap();

        var mercury = Builders.BuildMercury(map);

        Assert.NotNull(mercury);
        Assert.Equal("Mercury", mercury.Name);
        Assert.Equal("SOL-01", mercury.Properties[PropertiesConstant.DESIGNATION]);
        Assert.Null(mercury.Satelites);
        Assert.Single(map.Planets!);
        Assert.Null(map.Stars!);
        Assert.Null(map.Satelites!);
        Assert.Null(map.Asteroids!);
        Assert.Null(map.Comets!);

        Identifier identifier = new("Planet-00001");
        var planet = map.Get<Planet>(identifier);
        Assert.True(planet.Success);

        identifier = new("Satelite-00001");
        var satelite = map.Get<Satelite>(identifier);
        Assert.False(satelite.Success);
    }

    [Fact]
    public void BuildJupiter()
    {
        IStellarMap map = new StellarMap.Core.StellarMap();
        var jupiter = Builders.BuildJupiter(map);

        Assert.NotNull(jupiter);
        Assert.Equal("Jupiter", jupiter.Name);
        Assert.Equal("SOL-05", jupiter.Properties[PropertiesConstant.DESIGNATION]);
        Assert.NotNull(jupiter.Satelites);
        Assert.Equal(12, jupiter.Satelites.Count);

        var io = jupiter.GetSatelite("Io");
        Assert.True(io.Success);
        Assert.NotNull(io.Value);
        Assert.Equal("Io", io.Value.Name);
        Assert.Equal("Satelite-00005", io.Value.Identifier.Id);

        Assert.NotNull(map.Planets);
        Assert.Single(map.Planets);
        Assert.NotNull(map.Satelites);
        Assert.Equal(12, map.Satelites.Count);
        Assert.Null(map.Stars);
        Assert.Null(map.Asteroids);
        Assert.Null(map.Comets);
    }

    [Fact]
    public void BuildSolarSystem()
    {
        IStellarMap map = new StellarMap.Core.StellarMap();
        var sol = Builders.BuildSol(map);

        Assert.NotNull(sol);
        Assert.Equal("Sol", sol.Name);
        Assert.Equal("Sun", sol.Properties[PropertiesConstant.ALTERNATIVENAME]);
        Assert.Equal("Sol", sol.Properties[PropertiesConstant.DESIGNATION]);
        Assert.Equal("G2V", sol.Properties[PropertiesConstant.STELLARCLASS]);
        Assert.NotNull(sol.Planets);
        Assert.Equal(10, sol.Planets.Count);
        Assert.NotNull(sol.Asteroids);
        Assert.Equal(11, sol.Asteroids.Count);
        Assert.NotNull(sol.Comets);
        Assert.Equal(7, sol.Comets.Count);

        var earth = sol.GetPlanet("Earth");
        Assert.True(earth.Success);
        Assert.NotNull(earth.Value);
        Assert.Equal("SOL-03", earth.Value.Properties[PropertiesConstant.DESIGNATION]);
        Assert.Equal("Planet-00003", earth.Value.Identifier.Id);
        Assert.NotNull(earth.Value.Satelites);
        Assert.Single(earth.Value.Satelites);

        Assert.NotNull(map.Stars);
        Assert.Single(map.Stars);
        Assert.NotNull(map.Planets);
        Assert.Equal(10, map.Planets.Count);
        Assert.NotNull(map.Satelites);
        Assert.Equal(39, map.Satelites.Count);
        Assert.NotNull(map.Asteroids);
        Assert.Equal(11, map.Asteroids.Count);
        Assert.NotNull(map.Comets);
        Assert.Equal(7, map.Comets.Count);
    }
}
