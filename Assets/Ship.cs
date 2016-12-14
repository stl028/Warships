using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {
	
	//Vars with general information
	int hp;
	int posX;
	int posY;
    int id;
	
	//Vars detailing movement
	int coneWidth;
	double arrowSpeed;
	double power;

	public Ship(int num)
    {
        id = num;
    }

	public void SetParams(int health, int xCoor, int yCoor, int cWidth, double aSpeed, double str) {
		hp = health;
		posX = xCoor;
		posY = yCoor;
		coneWidth = cWidth;
		arrowSpeed = aSpeed;
		power = str;
	}

	public void updatePos(int xCoor, int yCoor) {
		posX = xCoor;
		posY = yCoor;
	}

	public void updateHP(int health) {
		hp = health;
	}

    public int getHP()
    {
        return hp;
    }

    public int getPosX()
    {
        return posX;
    }

    public int getPosY()
    {
        return posY;
    }

    public double getPower()
    {
        return power;
    }

    public double getArrowSpeed()
    {
        return arrowSpeed;
    }

    public int getConeWidth()
    {
        return coneWidth;
    }

}
