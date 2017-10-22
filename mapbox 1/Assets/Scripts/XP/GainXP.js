#pragma strict

private var levelUpScript : LevelUpSystem;

function Start () {
	levelUpScript = GameObject.Find("Player").GetComponent(LevelUpSystem);
}

function OnTriggerEnter (Col:Collider) {
    Debug.Log("test");
	if(Col.tag == "Player")
	{
		Destroy(gameObject);
		levelUpScript.currentXP +=10;
	}
}

function Update () {

}