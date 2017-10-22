using UnityEngine;
using System.Collections;

[System.Serializable]
public class FarmItem
{
	public string itemName;
	public Sprite icon;
}

public class FarmScrollList : MonoBehaviour {
	
	public FarmObjectPool grassObjectPool;
	public FarmObjectPool cowObjectPool;
	public FarmObjectPool chickenObjectPool;
	public Transform farmPanel;

	public void TryPlantGrass()
	{
		ShopScrollList.grassNumber++;
		GameObject newItem = grassObjectPool.GetObject();
		newItem.transform.SetParent(farmPanel);
		newItem.transform.position = farmPanel.transform.position;
		SampleItem sampleItem = newItem.GetComponent<SampleItem>();
		sampleItem.Setup (this);
	}

	public void TryPlantCow()
	{
		ShopScrollList.cowNumber++;
		GameObject newItem = cowObjectPool.GetObject(); 	
		newItem.transform.SetParent(farmPanel);
		newItem.transform.position = farmPanel.transform.position;
		SampleItem sampleItem = newItem.GetComponent<SampleItem>();
		sampleItem.Setup (this);
	}
	public void TryPlantChicken()
	{

		ShopScrollList.chickenNumber++;
		if (ShopScrollList.chickenNumber <= 3) {
			GameObject newItem = chickenObjectPool.GetObject (); 	
			newItem.transform.SetParent (farmPanel);
			newItem.transform.position = farmPanel.transform.position;
			SampleItem sampleItem = newItem.GetComponent<SampleItem> ();
			sampleItem.Setup (this);
		}
	}
}
