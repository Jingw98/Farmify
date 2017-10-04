#pragma strict

private var itemCollectScript : CollectItemSystem;

function Start () {
	itemCollectScript = GameObject.Find("Player").GetComponent(CollectItemSystem);
}

function OnTriggerEnter (Col:Collider)
{
	if(Col.tag == "Player")
	{
		Destroy(gameObject);
		itemCollectScript.currentItem +=1;
	}
}

function Update () {

}