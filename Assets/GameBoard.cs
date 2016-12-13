using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour {

    Player p1;
    Player p2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void enterNames(string name1, string name2)
    {
        p1.ign = name1;
        p2.ign = name2;


    }
}
