using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaunchPower : MonoBehaviour {

    public Image PowerBarFill;

    public LaunchPower(ref Image fill)
    {
        PowerBarFill = fill;
    }

	public void UpdatePower(float currentPower, float maxPower)
    {
        //turn final power into a percentage to alter power bar
        float ratio = currentPower / maxPower;
        PowerBarFill.rectTransform.localScale = new Vector3(1, ratio, 1);
    }


}
