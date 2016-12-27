using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour {

    Player p1;
    Player p2;
    List<Ship> army1;
    List<Ship> army2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /*public void enterNames(string name1, string name2)
    {
        p1.ign = name1;
        p2.ign = name2;
    }*/

    public void createArmies(int totalShips)
    {
        int allocatedShips = totalShips / 2;
        for (int i = 0; i < allocatedShips; i++)
        {
            army1.Add(new Ship(i));
        }

        for (int j = 0; j < allocatedShips; j++)
        {
            army2.Add(new Ship(j));
        }
    }

    public void createPlayers(string name1, string name2, int health)
    {
        p1 = new Player(name1, ref army1, health);
        p2 = new Player(name2, ref army2, health);
    }

    public void initShips(int health, int xCoor, int yCoor, int cWidth, double aSpeed, double str)
    {
        for (int i = 0; i < army1.Count; i++)
        {
            army1[i].SetParams(health, xCoor, yCoor, cWidth, aSpeed, str);
            army2[i].SetParams(health, xCoor, yCoor, cWidth, aSpeed, str);
        }
    }

}
