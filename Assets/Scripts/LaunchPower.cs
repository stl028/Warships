using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaunchPower : MonoBehaviour {

	public Slider bar;

	public void ChangeSlider(float one, float two) {
	
		bar.value = Mathf.MoveTowards(bar.value, one, two);

	}
}
