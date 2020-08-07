using System;
using System.Collections.Generic;
using GrandTheftMultiplayer.Server;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Constant;
using GrandTheftMultiplayer.Server.Managers;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Math;

public class Musket : Script
{
    private List<Vector3> spawns;
    private List<WeaponHash> weapons;
    private Random rInst;

    
    public Musket()
    {
        spawns = new List<Vector3>();
        spawns.Add(new Vector3(-547.5703 ,5387.408 ,70.04324));
        spawns.Add(new Vector3(-578.1264 ,5371.23 ,70.2535));
        spawns.Add(new Vector3(-591.9277 ,5356.171 ,70.4747));
        spawns.Add(new Vector3(-589.6947 ,5321.488 ,70.36116));
        spawns.Add(new Vector3(-554.2698 ,5323.755 ,73.59967));
        spawns.Add(new Vector3(-535.8047 ,5360.771 ,75.01944));
        spawns.Add(new Vector3(-505.1288 ,5332.869 ,77.04476));
        spawns.Add(new Vector3(-473.8156 ,5359.394 ,80.78579));
        spawns.Add(new Vector3(-477.2262 ,5322.541 ,80.61004));
        spawns.Add(new Vector3(-501.5061 ,5293.489 ,80.59248));
        spawns.Add(new Vector3(-494.4044 ,5252.519 ,86.82958));
        spawns.Add(new Vector3(-527.1093 ,5292.508 ,74.23982));
        spawns.Add(new Vector3(-559.9581 ,5287.919 ,76.23024));
        spawns.Add(new Vector3(-561.9651 ,5253.392 ,70.49667));
        spawns.Add(new Vector3(-593.6217 ,5242.661 ,70.32964));
        spawns.Add(new Vector3(-616.2371 ,5263.866 ,72.74117));

        weapons = new List<WeaponHash>();
        weapons.Add(WeaponHash.Musket);
        
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
    
    [Command("musket")]
    public void ArenaMusket(Client player)
    {
        Respawn(player);
        API.setEntityDimension(player, 1);
    }
    
    public void OnPlayerRespawnHandler(Client player)
    {
        Respawn(player);        
    }    
}