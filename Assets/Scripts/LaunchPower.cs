using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaunchPower : MonoBehaviour {

	//maximum width of the power bar
	float fullWidth = 256;

	//stores the current set power
	float finalPower;

	//to start and stop addition/subtraction to power
	bool powerInc = false;

	bool powerDec = false;

	//This is a reference to the power bar
	public Slider bar;


	public LaunchPower(Slider pBar) {

		bar = pBar;
	}

	public void ChangeSlider(float one, float two) {
	
		bar.value = Mathf.MoveTowards(bar.value, one, two);

	}

	public void ChangeValue(float val) {
		bar.value = val;
	}


}
