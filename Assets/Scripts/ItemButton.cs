using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    public Image buttonImage;
    public Text amountText;
    public int buttonValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pressed()
    {
        if (FindObjectOfType<ShopManager>().shopItems[buttonValue] != "")
        {
            for (int j = 0; j < FindObjectOfType<ShopManager>().itemsInfo.Length; j++)
            {
                if (FindObjectOfType<ShopManager>().itemsInfo[j].itemName == FindObjectOfType<ShopManager>().shopItems[buttonValue])
                {
                    FindObjectOfType<ShopManager>().descriptionText.text = FindObjectOfType<ShopManager>().itemsInfo[j].description;
                    FindObjectOfType<ShopManager>().activeItem = FindObjectOfType<ShopManager>().itemsInfo[j];
                    FindObjectOfType<ShopManager>().shopIndex = buttonValue;
                }
            }
        }
        else
        {
            FindObjectOfType<ShopManager>().shopIndex = -1;
        }
    }
}
