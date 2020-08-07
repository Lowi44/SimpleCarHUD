using System;
using System.Collections.Generic;
using GrandTheftMultiplayer.Server;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Constant;
using GrandTheftMultiplayer.Server.Managers;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Math;

public class Deagle : Script
{
    private List<Vector3> spawns;
    private List<WeaponHash> weapons;
    private Random rInst;

    
    public Deagle()
    {
        spawns = new List<Vector3>();
        spawns.Add(new Vector3( , ,));
        spawns.Add(new Vector3( , ,));
        spawns.Add(new Vector3( , ,));
        spawns.Add(new Vector3( , ,));
        spawns.Add(new Vector3( , ,));
        spawns.Add(new Vector3( , ,));
        spawns.Add(new Vector3( , ,));
        spawns.Add(new Vector3( , ,));
        spawns.Add(new Vector3( , ,));
        spawns.Add(new Vector3( , ,));
        spawns.Add(new Vector3( , ,));
        spawns.Add(new Vector3( , ,));
        spawns.Add(new Vector3( , ,));
        spawns.Add(new Vector3( , ,));
        spawns.Add(new Vector3( , ,));
        spawns.Add(new Vector3( , ,));
        spawns.Add(new Vector3( , ,));
        spawns.Add(new Vector3( , ,));
        spawns.Add(new Vector3( , ,));
        spawns.Add(new Vector3( , ,));
        spawns.Add(new Vector3( , ,));
        spawns.Add(new Vector3( , ,));
        spawns.Add(new Vector3( , ,));
        spawns.Add(new Vector3( , ,));
        
        weapons = new List<WeaponHash>();
        weapons.Add(WeaponHash.HeavyPistol);
        
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
    
    [Command("Deagle")]
    public void ArenaDeagle(Client player)
    {
        Respawn(player);
        API.setEntityDimension(player, 1);
    }
    
    public void OnPlayerRespawnHandler(Client player)
    {
        Respawn(player);        
    }    
}