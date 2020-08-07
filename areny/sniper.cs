using System;
using System.Collections.Generic;
using GrandTheftMultiplayer.Server;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Constant;
using GrandTheftMultiplayer.Server.Managers;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Math;

public class Sniper : Script
{
    private List<Vector3> spawns;
    private List<WeaponHash> weapons;
    private Random rInst;

    
    public Sniper()
    {
        spawns = new List<Vector3>();
        spawns.Add(new Vector3(1136.978, 2066.974, 56.24113));
        spawns.Add(new Vector3(1131.355, 2180.361, 48.45324));
        spawns.Add(new Vector3(1161.193, 2342.224, 57.17844));
        spawns.Add(new Vector3(1145.7, 2469.607, 54.0278));
        spawns.Add(new Vector3(1048.63, 2518.582, 44.90314));
        spawns.Add(new Vector3(899.614, 2490.321, 53.28391));
        spawns.Add(new Vector3(861.0319, 2418.602, 53.57724));
        spawns.Add(new Vector3(819.5492, 2352.811, 50.06596));
        spawns.Add(new Vector3(937.5201, 2255.404, 44.66494));
        spawns.Add(new Vector3(959.4749, 2209.262, 48.78069));
        spawns.Add(new Vector3(1077.677, 2138.044, 52.6725));
        spawns.Add(new Vector3(1068.924, 2241.282, 43.65987));
        spawns.Add(new Vector3(1033.513, 2299.37, 44.82005));
        spawns.Add(new Vector3(1014.618, 2383.19, 51.18369));
        spawns.Add(new Vector3(946.4108, 2428.279, 49.73853));
        spawns.Add(new Vector3(1027.592, 2457.62, 49.56542));
        spawns.Add(new Vector3(923.3156, 2374.427, 47.8811));
        spawns.Add(new Vector3(1137.762, 2101.198, 55.2753));

        weapons = new List<WeaponHash>();
        weapons.Add(WeaponHash.HeavySniper);
        
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
    
    [Command("sniper")]
    public void ArenaSniper(Client player)
    {
        Respawn(player);
        API.setEntityDimension(player, 1);
    }
    
    public void OnPlayerRespawnHandler(Client player)
    {
        Respawn(player);        
    }    
}