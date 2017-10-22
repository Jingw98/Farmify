using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainFunction : MonoBehaviour {
	public Text HRInput;
	public Text btn;
	public static bool playing = false;

	public void GetInputHR () {		
		int heartRate = int.Parse(HRInput.text);
		Debug.Log("Your heart rate: " + heartRate);

		// Start game
		if (btn.text == "Start") {
			playing = true;
			btn.text = "Stop";
		}

		// Stop game
		else if (btn.text == "Stop") {
			playing = false;
			btn.text = "Start";
		}




	}
}
