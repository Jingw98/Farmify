using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SampleButton : MonoBehaviour{
	
	public Button buttonComponent;
	public Text nameLabel;
	public Image iconImage;
	public Text priceText;

	private Item item;
	private FarmItem farmItem;
	private ShopScrollList scrollList;
	private FarmScrollList farmList;

	// Use this for initialization
	void Start () 
	{
		buttonComponent.onClick.AddListener (OnPointerClick);
	}
	
	public void Setup(Item currentItem, ShopScrollList currentScrollList, FarmScrollList currentFL)
	{
		item = currentItem;
		nameLabel.text = item.itemName;
		iconImage.sprite = item.icon;
		priceText.text = "$"+ item.price.ToString ();
		scrollList = currentScrollList;
		farmList = currentFL;
	}


	public void OnPointerClick()
	{
		//if (eventData.button == PointerEventData.InputButton.Left)
			//scrollList.TryTransferItemToOtherShop (item);
		if (this.transform.parent.name.Equals ("ContentB")) {
			if (this.nameLabel.text.Equals ("Grass")) {
				farmList.TryPlantGrass ();
				scrollList.Planting (item);
			} else if (this.nameLabel.text.Equals ("Cow")) {
				farmList.TryPlantCow ();
				scrollList.Planting (item);
			} else if (nameLabel.text.Equals ("Chicken")) {
				farmList.TryPlantChicken ();
				scrollList.Planting (item);
			}
		}
		else if (this.transform.parent.name.Equals ("ContentA"))
			scrollList.TryTransferItemToOtherShop (item);
//		else if (eventData.button == PointerEventData.InputButton.Right)
//			scrollList.TryPutInFarmFromStorage (item);
	}

}