using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    public Image buttonImage;
    public Text amountText;
    public int buttonValue;

    public void Pressed()  // Called in editor OnClick()
    {
        if (ShopManager.instance.shopItems[buttonValue] != "")
        {
            for (int j = 0; j < ShopManager.instance.itemsInfo.Length; j++)
            {
                if (ShopManager.instance.itemsInfo[j].itemName == ShopManager.instance.shopItems[buttonValue])
                {
                    ShopManager.instance.descriptionText.text = ShopManager.instance.itemsInfo[j].description;
                    ShopManager.instance.costText.text = ShopManager.instance.itemsInfo[j].cost + "g";
                    ShopManager.instance.activeItem = ShopManager.instance.itemsInfo[j];
                    ShopManager.instance.shopIndex = buttonValue;
                    return;  // If finds the corresponding item, then return, no need to keep finding
                }
            }
        }
        else
        {
            ShopManager.instance.shopIndex = -1;
        }
    }
}
