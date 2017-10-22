#pragma strict
var currentItem : int = 0;


var getItemTexture : Texture2D;
var getItemSound :AudioClip;

private var getItem : boolean = true;

var timeToShowLevelUp : float = 3f;
var timeTillNotShowLevelUp : float = 0f;

function Update () {

}
function CollectItemSystem()
{

}

function OnGUI()
{
 GUI.Box(new Rect(5,140,40,20), "Item");
 GUI.Box(new Rect(45,140,100,20), currentItem + "");
}