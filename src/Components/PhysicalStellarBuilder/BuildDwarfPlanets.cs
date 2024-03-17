namespace StellarMap.PhysicalStellarBuilder;

public class BuildDwarfPlanets
{
    public static Result<DwarfPlanet> Pluto(IStellarMap map)
    {
        Satelite[] satelites =
        {
            BuildSatelites.PlutoCharon(map),
            BuildSatelites.PlutoNix(map),
            BuildSatelites.PlutoHydra(map),
            BuildSatelites.PlutoKerberos(map),
            BuildSatelites.PlutoStyx(map)
        };

        PhysicalProperties physicalProperties = new()
        {
            Mass = 1.303E22,
            Radius = 2376.6,
            Area = 1.774E7,
            Volume = 7.057E9,
            Density = 1.854,
            Gravity = 0.620,
            EscapeVelocity = 1.212
        };

        return DwarfPlanetBuilder.Create("Pluto", MapIdentifierGenerator.Instance, map)
            .WithDescription("The largets Dwarf Planet in the Solar System.")
            .WithProperty(PropertiesConstant.DESIGNATION, "SOL-D-01")
            .WithProperty(PropertiesConstant.PLANETTYPE, PropertiesConstant.ROCKYDWARFPLANET)
            .AddPhysicalProperties(physicalProperties)
            .AddSatelites(satelites)
            .Build();
    }

    public static Result<DwarfPlanet> Ceres(IStellarMap map)
    {

        PhysicalProperties physicalProperties = new()
        {
            Mass = 9.3839E20,
            Radius = 939.4,
            Dimensions = "966.2x962.0x891.8",
            Area = 2.772E6,
            Volume = 4.34E8,
            Density = 2.1616,
            Gravity = 0.284,
            EscapeVelocity = 0.516
        };

        return DwarfPlanetBuilder.Create("Ceres", MapIdentifierGenerator.Instance, map)
            .WithDescription("Dwarf planet in the asteroid belt.")
            .WithProperty(PropertiesConstant.DESIGNATION, "SOL-D-2")
            .WithProperty(PropertiesConstant.PLANETTYPE, PropertiesConstant.ROCKYDWARFPLANET)
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }
}
