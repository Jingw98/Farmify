#pragma strict

var tim;
var lat;
var lon;
var locStyle : GUIStyle;
var latField : UI.Text ;
var lonField : UI.Text ;

function Start () {
	// First, check if user has location service enabled
	if (!Input.location.isEnabledByUser)
		return;

	// Start service before querying location
	Input.location.Start (0.1, 0.1);

	// Wait until service initializes
	var maxWait : int = 20;
	while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0) {
		yield WaitForSeconds (1);
		maxWait--;
	}

	// Service didn't initialize in 20 seconds
	if (maxWait < 1) {
		print ("Timed out");
		return;
	}

	// Connection has failed
	if (Input.location.status == LocationServiceStatus.Failed) {
		print ("Unable to determine device location");
		return;
	}

}

function Update () {
	// Access granted and location value could be retrieved
	//lat = Input.location.lastData.latitude;
	//lon = Input.location.lastData.longitude;
	//tim = Input.location.lastData.timestamp;
	
}

function OnGUI () {
	GUI.Box (Rect(Screen.width - 205, 100, 200, 40), "Time: " + tim, locStyle);
	GUI.Box (Rect(Screen.width - 205, 140, 200, 40), "Lat: " + lat, locStyle);
	GUI.Box (Rect(Screen.width - 205, 180, 200, 40), "Lon: " + lon, locStyle);
}
