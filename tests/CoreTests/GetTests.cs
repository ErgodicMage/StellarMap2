using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreTests;

public class GetTests
{
    [Fact]
    public void GetEarth()
    {
        IStellarMap map = new StandardStellarMap();
        var sol = Builders.BuildSol(map);
        Assert.NotNull(sol);

        var earth1 = sol.GetPlanet("Earth");
        Assert.True(earth1.Success);
        Assert.Equal("Earth", earth1.Value.Name);
        Assert.Equal("Planet-00003", earth1.Value.Identifier.Id);
        Assert.NotNull(earth1.Value.Satelites);
        Assert.Equal(1, earth1.Value?.Satelites?.Count);

        var earth2 = sol.GetPlanet(earth1.Value!.Identifier);
        Assert.Equal(earth1.Value, earth2.Value);

        var earth3 = map.Get<Planet>(earth1.Value!.Identifier);
        Assert.Equal(earth1.Value, earth3.Value);
    }

    [Fact]
    public void GetPluto()
    {
        IStellarMap map = new StandardStellarMap();
        var sol = Builders.BuildSol(map);

        var plutoError = sol.GetPlanet("Pluto");
        // yes Pluto is not a planet
        Assert.False(plutoError.Success);

        var pluto1 = sol.GetDwarfPlanet("Pluto");
        Assert.True(pluto1.Success);
        Assert.Equal("DwarfPlanet-00001", pluto1.Value.Identifier.Id);
        Assert.NotNull(pluto1.Value.Satelites);
        Assert.Equal(5, pluto1.Value?.Satelites?.Count);

        var pluto2 = sol.GetDwarfPlanet(pluto1.Value!.Identifier);
        Assert.Equal(pluto1.Value, pluto2.Value);

        var pluto3 = map.Get<DwarfPlanet>(pluto1.Value!.Identifier);
        Assert.Equal(pluto1.Value, pluto3.Value);

    }
}
