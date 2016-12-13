using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using objClasses;

    public class Player : MonoBehaviour {

        public string ign = "";
        public List<Ship> units;
        Base homebase;

        // Use this for initialization
        public Player(string id) {

            ign = id;
            homebase = new Base();
            units.Add(new Ship());
       }

    }
