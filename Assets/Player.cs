using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public string ign = "";
    public List<Ship> units;
    Base homebase;

    // Use this for initialization
    public Player(string id, ref List<Ship> army, int baseHp)
    {
        ign = id;
        homebase = new Base(baseHp);
        units = army;
    }

    public void updateBase(int hp)
    {
        homebase.updateHp(hp);
    }


}
