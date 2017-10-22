using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

[System.Serializable]
public class Item
{
	public string itemName;
	public Sprite icon;
	public float price = 1;
}

public class ShopScrollList : MonoBehaviour {
	
	public Text shopName;
	public List<Item> itemList;
	public Transform contentPanel;
	public ShopScrollList otherShop;
	public Text myGoldDisplay;
	public SimpleObjectPool buttonObjectPool;
	public FarmScrollList grassDirt1;
	public FarmScrollList grassDirt2;
	public FarmScrollList grassDirt3;
	public FarmScrollList chickenHome;
	public FarmScrollList chickenHome2;
	public FarmScrollList cowPlace;
	public FarmScrollList cowPlace2;
	public static int grassNumber = 1;
	public static int chickenNumber = 1;
	public static int cowNumber = 1;
	public float gold = 20f;
	
	
	void Start () 
	{
		RefreshDisplay ();
	}
	
	void RefreshDisplay()
	{
		myGoldDisplay.text = "Gold: " + gold.ToString ();
		RemoveButtons ();
		AddButtons ();
	}
	
	private void RemoveButtons()
	{
		while (contentPanel.childCount > 0) 
		{
			GameObject toRemove = transform.GetChild(0).gameObject;
			buttonObjectPool.ReturnObject(toRemove);
		}
	}
	
	private void AddButtons()
	{
	
		for (int i = 0; i < itemList.Count; i++) 
		{
			Item item = itemList[i];
			GameObject newButton = buttonObjectPool.GetObject();
			newButton.transform.SetParent(contentPanel);
			
			SampleButton sampleButton = newButton.GetComponent<SampleButton>();
			if (item.itemName.Equals("Grass")){
				if (grassNumber==1){
					sampleButton.Setup(item, this, grassDirt1);
				}
				else if (grassNumber==2){
					sampleButton.Setup(item, this, grassDirt2);

				}
				else if(grassNumber==3){
					sampleButton.Setup(item, this, grassDirt3);
				}
			}
			else if (item.itemName.Equals("Cow")){
				if (cowNumber==1)
					sampleButton.Setup(item, this, cowPlace);
				else if (cowNumber==2)
					sampleButton.Setup(item, this, cowPlace2);
			}
			else if (item.itemName.Equals("Chicken")){
				if (chickenNumber==1)
					sampleButton.Setup(item, this, chickenHome);
				if (chickenNumber==2)
					sampleButton.Setup(item, this, chickenHome2);
			}

		}
	}
	
	public void TryTransferItemToOtherShop(Item item)
	{
		if (otherShop.gold >= item.price) 
		{
			gold += item.price;
			otherShop.gold -= item.price;
			
			AddItem(item, otherShop);
			RemoveItem(item, this);
			
			RefreshDisplay();
			otherShop.RefreshDisplay();
			Debug.Log ("enough gold");
			
		}
		Debug.Log ("attempted");
	}

	public void Planting(Item item)
	{
	
			RemoveItem(item, this);
			
			RefreshDisplay();

	}
	
	void AddItem(Item itemToAdd, ShopScrollList shopList)
	{
		shopList.itemList.Add (itemToAdd);
	}
	
	private void RemoveItem(Item itemToRemove, ShopScrollList shopList)
	{
		for (int i = shopList.itemList.Count - 1; i >= 0; i--) 
		{
			if (shopList.itemList[i] == itemToRemove)
			{
				shopList.itemList.RemoveAt(i);
			}
		}
	}
}