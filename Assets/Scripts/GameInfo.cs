using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameInfo {

    private static int players, laps, map;
    private static int[] cars = new int[]{1,1,1,1};

    public static int Players 
    {
        get 
        {
            return players;
        }
        set 
        {
            players = value;
        }
    }

    public static int[] Cars
    {
        get
        {
            return cars;
        }

        set
        {
            cars = value;
        }
    }

    
    public static int Laps 
    {
        get 
        {
            return laps;
        }
        set 
        {
            laps = value;
        }
    }

    public static int Map
    {
        get
        {
            return map;
        }
        set
        {
            map = value;
        }
    }
}
