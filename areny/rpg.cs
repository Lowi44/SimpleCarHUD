using System;
using System.Collections.Generic;
using GrandTheftMultiplayer.Server;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Constant;
using GrandTheftMultiplayer.Server.Managers;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Math;

public class Rpg : Script
{
    private List<Vector3> spawns;
    private List<WeaponHash> weapons;
    private Random rInst;

    
    public Rpg()
    {
        spawns = new List<Vector3>();
        spawns.Add(new Vector3(3026.393 ,3029.116 ,90.36359));
        spawns.Add(new Vector3(2949.443 ,2938.193 ,89.11959));
        spawns.Add(new Vector3(2877.976 ,2885.713 ,85.25345));
        spawns.Add(new Vector3(3076.053 ,2977.331 ,91.17164));
        spawns.Add(new Vector3(3025.041 ,2877.611 ,85.00388));
        spawns.Add(new Vector3(3058.148 ,2969.031 ,81.44517));
        spawns.Add(new Vector3(3025.273 ,2993.512 ,71.5573));
        spawns.Add(new Vector3(3026.22 ,2891.885 ,73.01724));
        spawns.Add(new Vector3(3048.852 ,2805.823 ,69.28227));
        spawns.Add(new Vector3(3056.114 ,2740.562 ,63.78006));
        spawns.Add(new Vector3(2982.68 ,2687.942 ,64.10765));
        spawns.Add(new Vector3(2903.667 ,2743.037 ,62.03175));
        spawns.Add(new Vector3(2860.304 ,2821.302 ,52.77958));
        spawns.Add(new Vector3(2889.191 ,2855.357 ,63.02919));
        spawns.Add(new Vector3(2938.481 ,2888.971 ,59.29075));
        spawns.Add(new Vector3(3022.993 ,2911.945 ,63.31779));
        spawns.Add(new Vector3(3022.486 ,2958.085 ,66.87321));
        spawns.Add(new Vector3(2961.559 ,2900.511 ,72.2328));
        spawns.Add(new Vector3(3018.318 ,2823.4 ,63.62601));
        spawns.Add(new Vector3(3047.048 ,2855.31 ,81.78201));
        spawns.Add(new Vector3(3078.45 ,2915.808 ,91.13103));
        spawns.Add(new Vector3(3061.101 ,3009.428 ,90.45996));
        spawns.Add(new Vector3(3069.124 ,2796.621 ,76.8472));
        spawns.Add(new Vector3(3072.493 ,2716.27 ,71.90445));
        spawns.Add(new Vector3(3002.623 ,2694.641 ,74.28159));
        spawns.Add(new Vector3(2939.702 ,2667.211 ,74.54491));
        spawns.Add(new Vector3(2888.551 ,2740.004 ,69.84426));
        spawns.Add(new Vector3(2857.741 ,2773.684 ,63.70095));
        spawns.Add(new Vector3(2885.378 ,2789.363 ,55.66802));
        spawns.Add(new Vector3(2927.948 ,2721.772 ,53.46693));
        spawns.Add(new Vector3(2955.136 ,2695.186 ,54.70913));
        spawns.Add(new Vector3(3029.461 ,2770.281 ,55.50961));
        spawns.Add(new Vector3(2986.775 ,2842.311 ,55.42621));
        spawns.Add(new Vector3(2954.234 ,2849.83 ,47.09655));
        spawns.Add(new Vector3(2991.869 ,2802.478 ,43.38214));
        spawns.Add(new Vector3(2996.007 ,2752.683 ,43.06762));
        spawns.Add(new Vector3(2945.208 ,2741.367 ,43.15849));
        spawns.Add(new Vector3(2913.534 ,2779.589 ,44.03295));
        spawns.Add(new Vector3(2924.22 ,2811.117 ,43.3591));

        weapons = new List<WeaponHash>();
        weapons.Add(WeaponHash.RPG);
        
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
    
    [Command("rpg")]
    public void ArenaRpg(Client player)
    {
        Respawn(player);
        API.setEntityDimension(player, 1);
    }
    
    public void OnPlayerRespawnHandler(Client player)
    {
        Respawn(player);        
    }    
}