using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Base : MonoBehaviour
{

    public int health;
    // Use this for initialization
    public Base(int hp)
    {
        health = hp;
    }

    public int getHealth()
    {
        return health;
    }

    public void updateHp(int newHp)
    {
        health = newHp;
    }
}