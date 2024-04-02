namespace ProgressionTests;

public class GetTests
{
    [Fact]
    public void GetEarthSatelite()
    {
        ProgressionMap map = new("Earth Satelite Test");
        var earth = Builders.BuildEarth(map);
        Assert.NotNull(earth);
        Assert.NotNull(earth.Satelites);
        Assert.Equal(1, earth.Satelites?.Count);

        var moon1 = earth.GetSatelite("Moon");
        Assert.True(moon1.Success);
        Assert.Equal("Moon", moon1.Value.Name);
        Assert.Equal("Satelite-00001", moon1.Value.Identifier.Id);

        var moon2 = earth.GetSatelite(moon1.Value.Identifier);
        Assert.True(moon2.Success);
        Assert.Equal(moon1.Value, moon2.Value);

        var moon3 = map.GetProgressionSatelite(moon1.Value.Identifier);
        Assert.True(moon3.Success);
        Assert.Equal(moon1.Value, moon3.Value);
    }

    [Fact]
    public void GetEarthHabitats()
    {
        ProgressionMap map = new("Get Earth Habitats");
        var earth = Builders.BuildEarth(map);
        Assert.NotNull(earth);
        Assert.NotNull(earth.Habitats);
        Assert.Equal(2, earth.Habitats.Count);

        var habitat1 = earth.GetHabitat("Earth Station 1");
        Assert.True(habitat1.Success);
        Assert.Equal("Earth Station 1", habitat1.Value.Name);
        Assert.Equal("Habitat-00001", habitat1.Value.Identifier.Id);

        var habitat2 = earth.GetHabitat(habitat1.Value.Identifier);
        Assert.True(habitat2.Success);
        Assert.Equal(habitat1.Value, habitat2.Value);

        var habitat3 = map.GetHabitat(habitat1.Value.Identifier);
        Assert.True(habitat3.Success);
        Assert.Equal(habitat1.Value, habitat3.Value);

        var habitat4 = earth.GetHabitat("Earth Station 2");
        Assert.True(habitat4.Success);
        Assert.Equal("Earth Station 2", habitat4.Value.Name);
        Assert.Equal("Habitat-00002", habitat4.Value.Identifier.Id);

        var habitat5 = earth.GetHabitat(habitat4.Value.Identifier);
        Assert.True(habitat5.Success);
        Assert.Equal(habitat4.Value, habitat5.Value);

        var habitat6 = map.GetHabitat(habitat4.Value.Identifier);
        Assert.True(habitat6.Success);
        Assert.Equal(habitat4.Value, habitat6.Value);
    }
}
