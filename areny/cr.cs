using System;
using System.Collections.Generic;
using GrandTheftMultiplayer.Server;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Constant;
using GrandTheftMultiplayer.Server.Managers;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Math;

public class Cr : Script
{
    private List<Vector3> spawns;
    private List<WeaponHash> weapons;
    private Random rInst;

    
    public Cr()
    {
        spawns = new List<Vector3>();
        spawns.Add(new Vector3(-2149.874 ,224.4239 ,184.602));
        spawns.Add(new Vector3(-2196.556 ,248.7701 ,184.5996));
        spawns.Add(new Vector3(-2185.883 ,217.0497 ,184.602));
        spawns.Add(new Vector3(-2213.838 ,185.3625 ,174.6019));
        spawns.Add(new Vector3(-2259.859 ,233.5088 ,174.6069));
        spawns.Add(new Vector3(-2197.181 ,247.8289 ,174.6068));
        spawns.Add(new Vector3(-2216.278 ,286.519 ,174.6018));
        spawns.Add(new Vector3(-2193.561 ,288.6546 ,169.6072));
        spawns.Add(new Vector3(-2230.573 ,330.0835 ,174.6019));
        spawns.Add(new Vector3(-2252.91 ,380.9758 ,174.6021));
        spawns.Add(new Vector3(-2299.649 ,334.4276 ,174.6018));
        spawns.Add(new Vector3(-2287.295 ,357.5957 ,174.6017));
        spawns.Add(new Vector3(-2294.568 ,325.7716 ,184.5958));
        spawns.Add(new Vector3(-2257.565 ,324.7921 ,184.6015));
        spawns.Add(new Vector3(-2225.34 ,305.7191 ,184.5984));
        spawns.Add(new Vector3(-2221.856 ,262.7703 ,184.5995));
        spawns.Add(new Vector3(-2315.372 ,311.5605 ,169.6021));
        spawns.Add(new Vector3(-2318.897 ,253.4747 ,169.602));
        spawns.Add(new Vector3(-2282.125 ,262.5189 ,184.6015));
        spawns.Add(new Vector3(-2311.273 ,313.4725 ,184.6048));

        weapons = new List<WeaponHash>();
        weapons.Add(WeaponHash.CarbineRifle);
        
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
    
    [Command("cr")]
    public void ArenaCr(Client player)
    {
        Respawn(player);
        API.setEntityDimension(player, 1);
    }
    
    public void OnPlayerRespawnHandler(Client player)
    {
        Respawn(player);        
    }    
}