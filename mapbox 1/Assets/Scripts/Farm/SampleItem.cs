using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SampleItem : MonoBehaviour {

	public Button buttonComponent;
	public Text nameLabel;
	
	private FarmItem item;
	private FarmScrollList farmList;

	// Use this for initialization
	void Start () {
	
	}

	public void Setup(FarmScrollList currentFarmList)
	{
	//	item = currentItem;
	//	nameLabel.text = item.itemName;
		//farmList = currentFarmList;

	}

	// Update is called once per frame
	void Update () {
	
	}
}
