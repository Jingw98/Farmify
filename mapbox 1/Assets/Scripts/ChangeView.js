#pragma strict

// Target object of reference
var target : Transform;

// Scale factor
var distance = 450.0;

// Move speed
var xSpeed = 200.0;
var ySpeed = 120.0;

// Scale limit factor
var yMinLimit = -1000;
var yMaxLimit = 1000;

// Position of camera
var x = 0.0;
var y = 0.0;

// Previous position, for checking zoom in/out
private var oldPosition1 : Vector2;
private var oldPosition2 : Vector2;

// Init
function Start () {
    var angles = transform.eulerAngles;
    x = angles.y;
    y = angles.x;

// Make the rigid body not change rotation
   if (GetComponent.<Rigidbody>())
		GetComponent.<Rigidbody>().freezeRotation = true;
}

function Update () {
	// Single touch
	if(Input.touchCount == 1) {
		// Move
		if(Input.GetTouch(0).phase == TouchPhase.Moved) {
			x += Input.GetAxis("Mouse X") * xSpeed * 0.02;
			//y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02;
		}
	}

	// Multi touch
	if(Input.touchCount > 1) {
		// When the first or second finger moves
		if(Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(1).phase == TouchPhase.Moved) {
			// Get current position
			var tempPosition1 = Input.GetTouch(0).position;
			var tempPosition2 = Input.GetTouch(1).position;

			// Check if the user want to zoom in (true) or zoom out (false)
			if(isEnlarge(oldPosition1, oldPosition2, tempPosition1, tempPosition2)) {
				distance -= 5;
				if(distance < 300) distance += 5;
			} else {
				distance += 5;
				if(distance > 700) distance -= 5;
			}

			// Note down current positions for comparing with next ones
			oldPosition1 = tempPosition1;
			oldPosition2 = tempPosition2;
		}
	}

}

// True - zoom in / False - zoom out
function isEnlarge(oP1 : Vector2,oP2 : Vector2,nP1 : Vector2,nP2 : Vector2) : boolean {

    var leng1 = Mathf.Sqrt((oP1.x-oP2.x)*(oP1.x-oP2.x)+(oP1.y-oP2.y)*(oP1.y-oP2.y));
    var leng2 = Mathf.Sqrt((nP1.x-nP2.x)*(nP1.x-nP2.x)+(nP1.y-nP2.y)*(nP1.y-nP2.y));

    if(leng1 < leng2) return true; //zoom in
    else return false; //zoom out
}

// After each update, set the position of camera
function LateUpdate () {
	// Target object is necessary
	if (target) {	
		// Reset the position of camera
		y = ClampAngle(y, yMinLimit, yMaxLimit);
		var rotation = Quaternion.Euler(y, x, 0);
		var position = rotation * Vector3(0.0, 0.0, -distance) + target.position;

		transform.rotation = rotation;
		transform.position = position;
	}
}

static function ClampAngle (angle : float, min : float, max : float) {
	if (angle < -360) angle += 360;
	if (angle > 360) angle -= 360;
	return Mathf.Clamp (angle, min, max);
}