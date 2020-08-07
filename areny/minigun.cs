using System;
using System.Collections.Generic;
using GrandTheftMultiplayer.Server;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Constant;
using GrandTheftMultiplayer.Server.Managers;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Math;

public class Minigun : Script
{
    private List<Vector3> spawns;
    private List<WeaponHash> weapons;
    private Random rInst;

    
    public Minigun()
    {
        spawns = new List<Vector3>();

        spawns.Add(new Vector3(2782.046 ,1386.867 ,24.45051));
        spawns.Add(new Vector3(2738.019 ,1370.368 ,24.524));
        spawns.Add(new Vector3(2712.959 ,1371.399 ,24.52398));
        spawns.Add(new Vector3(2673.534 ,1398.645 ,24.56055));
        spawns.Add(new Vector3(2652.6 ,1393.3 ,23.93099));
        spawns.Add(new Vector3(2657.123 ,1437.063 ,24.50641));
        spawns.Add(new Vector3(2655.958 ,1477.586 ,24.50213));
        spawns.Add(new Vector3(2652.811 ,1520.993 ,24.49402));
        spawns.Add(new Vector3(2661.609 ,1568.007 ,24.5022));
        spawns.Add(new Vector3(2658.978 ,1608.57 ,24.76037));
        spawns.Add(new Vector3(2662.369 ,1641.808 ,24.87111));
        spawns.Add(new Vector3(2650.819 ,1697.673 ,24.48824));
        spawns.Add(new Vector3(2714.315 ,1719.803 ,24.51203));
        spawns.Add(new Vector3(2764.763 ,1719.497 ,24.5182));
        spawns.Add(new Vector3(2813.568 ,1719.376 ,24.52602));
        spawns.Add(new Vector3(2837.071 ,1712.611 ,24.62695));
        spawns.Add(new Vector3(2833.985 ,1668.48 ,24.57357));
        spawns.Add(new Vector3(2845.987 ,1600.8 ,24.58345));
        spawns.Add(new Vector3(2847.684 ,1561.959 ,24.57154));
        spawns.Add(new Vector3(2876.068 ,1522.453 ,24.56755));
        spawns.Add(new Vector3(2842.955 ,1489.046 ,24.56752));
        spawns.Add(new Vector3(2838.57 ,1448.959 ,24.73578));
        spawns.Add(new Vector3(2783.726 ,1437.442 ,24.52183));
        spawns.Add(new Vector3(2739.494 ,1461.11 ,24.50145));
        spawns.Add(new Vector3(2729.156 ,1503.425 ,24.50072));
        spawns.Add(new Vector3(2760.407 ,1483.989 ,24.50072));
        spawns.Add(new Vector3(2733.331 ,1525.19 ,24.50072));
        spawns.Add(new Vector3(2739.688 ,1571.366 ,24.50097));
        spawns.Add(new Vector3(2775.197 ,1543.657 ,24.50062));
        spawns.Add(new Vector3(2761.159 ,1574.883 ,24.50095));
        spawns.Add(new Vector3(2732.403 ,1582.38 ,24.50096));
        spawns.Add(new Vector3(2704.5 ,1606.103 ,24.55885));
        spawns.Add(new Vector3(2712.733 ,1634.354 ,24.54596));
        spawns.Add(new Vector3(2757.953 ,1654.717 ,24.52363));
        spawns.Add(new Vector3(2780.819 ,1678.408 ,24.48871));
        spawns.Add(new Vector3(2713.014 ,1685.329 ,24.48872));
        spawns.Add(new Vector3(2674.216 ,1593.244 ,24.4945));
        spawns.Add(new Vector3(2758.872 ,1557.995 ,32.50755));
        spawns.Add(new Vector3(2748.171 ,1560.966 ,32.50754));
        spawns.Add(new Vector3(2746.368 ,1557.623 ,29.85778));
        spawns.Add(new Vector3(2771.149 ,1581.384 ,30.79192));
        spawns.Add(new Vector3(2778.397 ,1553.56 ,30.79283));
        spawns.Add(new Vector3(2775.629 ,1541.874 ,30.79132));
        spawns.Add(new Vector3(2767.065 ,1510.743 ,30.79139));
        spawns.Add(new Vector3(2756.995 ,1474.714 ,30.79179));
        spawns.Add(new Vector3(2759.196 ,1544.729 ,30.7918));
        spawns.Add(new Vector3(2747.866 ,1504.418 ,30.7918));
        spawns.Add(new Vector3(2737.583 ,1468.261 ,30.79157));
        spawns.Add(new Vector3(2730.972 ,1491.625 ,35.13144));
        spawns.Add(new Vector3(2748.71 ,1508.957 ,35.31416));
        spawns.Add(new Vector3(2748.868 ,1544.718 ,32.50694));
        spawns.Add(new Vector3(2731.538 ,1533.954 ,32.50657));
        spawns.Add(new Vector3(2730.976 ,1519.433 ,30.13121));
        spawns.Add(new Vector3(2741.752 ,1574.224 ,32.5075));
        spawns.Add(new Vector3(2764.285 ,1557.795 ,32.5075));
        spawns.Add(new Vector3(2761.261 ,1578.61 ,40.33311));
        spawns.Add(new Vector3(2758.185 ,1579.425 ,40.33311));
        spawns.Add(new Vector3(2739.347 ,1565.639 ,40.33312));
        spawns.Add(new Vector3(2749.058 ,1571.408 ,40.33312));
        spawns.Add(new Vector3(2749.732 ,1542.259 ,40.33221));
        spawns.Add(new Vector3(2739.838 ,1537.094 ,40.33221));
        spawns.Add(new Vector3(2731.268 ,1528.702 ,40.33221));
        spawns.Add(new Vector3(2747.044 ,1524.558 ,40.33221));
        spawns.Add(new Vector3(2752.133 ,1525.644 ,42.89385));
        spawns.Add(new Vector3(2732.738 ,1540.295 ,42.89967));
        spawns.Add(new Vector3(2740.721 ,1521.822 ,45.50159));
        spawns.Add(new Vector3(2751.826 ,1522.781 ,48.15126));
        spawns.Add(new Vector3(2744.85 ,1543.059 ,48.15119));
        spawns.Add(new Vector3(2734.028 ,1528.916 ,48.15126));
        spawns.Add(new Vector3(2743.741 ,1563.878 ,48.15166));
        spawns.Add(new Vector3(2756.26 ,1578.778 ,48.15124));
        spawns.Add(new Vector3(2755.414 ,1578.521 ,50.68685));
        spawns.Add(new Vector3(2728.898 ,1577.351 ,50.53123));
        spawns.Add(new Vector3(2746.062 ,1541.91 ,50.68704));
        spawns.Add(new Vector3(2718.651 ,1541.206 ,50.53093));
        spawns.Add(new Vector3(2742.885 ,1528.967 ,50.68705));
        spawns.Add(new Vector3(2751.789 ,1522.446 ,48.1513));
        spawns.Add(new Vector3(2733.286 ,1498.43 ,34.311));
        spawns.Add(new Vector3(2730.865 ,1510.632 ,34.3111));
        spawns.Add(new Vector3(2749.462 ,1508.481 ,38.47031));
        spawns.Add(new Vector3(2738.063 ,1464.873 ,38.28244));
        spawns.Add(new Vector3(2720.767 ,1472.843 ,34.3114));
        spawns.Add(new Vector3(2745.917 ,1464.744 ,40.83115));
        spawns.Add(new Vector3(2722.454 ,1479.953 ,34.36079));
        spawns.Add(new Vector3(2708.001 ,1473.874 ,42.24905));
        spawns.Add(new Vector3(2702.847 ,1482.971 ,44.46589));
        spawns.Add(new Vector3(2717.642 ,1479.289 ,47.09513));
        spawns.Add(new Vector3(2723.294 ,1483.739 ,40.31248));
        spawns.Add(new Vector3(2716.078 ,1505.501 ,42.24909));
        spawns.Add(new Vector3(2725.977 ,1510.032 ,47.14873));
        spawns.Add(new Vector3(2711.587 ,1512.642 ,44.58864));
        spawns.Add(new Vector3(2741.079 ,1507.016 ,45.29535));
        spawns.Add(new Vector3(2733.48 ,1477.866 ,45.29578));
        spawns.Add(new Vector3(2723.316 ,1487.842 ,42.24909));
        spawns.Add(new Vector3(2724.693 ,1534.825 ,24.5007));
        spawns.Add(new Vector3(2715.82 ,1508.182 ,24.50072));
        spawns.Add(new Vector3(2713.747 ,1535.906 ,20.82407));


        weapons = new List<WeaponHash>();
        weapons.Add(WeaponHash.Minigun);
        
        rInst = new Random();

    //API.onPlayerRespawn += OnPlayerRespawnHandler;
    }

    public void Respawn(Client player)
    {
        API.removeAllPlayerWeapons(player);
        var rand = spawns[rInst.Next(spawns.Count)];
        API.setEntityPosition(player.handle, rand);
        foreach(var gun in weapons)
        {
            API.givePlayerWeapon(player, gun, 9999, false, true);
        }
        
        API.setPlayerHealth(player, 100);
    }
    
    [Command("minigun")]
    public void ArenaMinigun(Client player)
    {
        Respawn(player);
        API.setEntityDimension(player, 1);
    }
    
    public void OnPlayerRespawnHandler(Client player)
    {
        Respawn(player);        
    }    
}