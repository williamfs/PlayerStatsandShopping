﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public GameObject shopingPanel;
    public Text descriptionText;

    public string[] shopItems = new string[32];
    public ItemButton[] itemButtons;
    public Item[] itemsInfo;

    public Item activeItem;
    public int shopIndex;

    private bool hasOpen;

    // Start is called before the first frame update
    void Start()
    {
        AssignButtonValues();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasOpen && Input.GetKeyDown(KeyCode.P))
        {
            OpenShoppingMenu();
        }
        else if (hasOpen && Input.GetKeyDown(KeyCode.P))
        {
            CloseShoppingMenu();
        }
    }

    private void OpenShoppingMenu()
    {
        hasOpen = true;
        shopingPanel.SetActive(true);
        SortShopItems();
        UpdateItemButton();
    }

    public void CloseShoppingMenu()
    {
        hasOpen = false;
        shopingPanel.SetActive(false);
    }

    private void SortShopItems()
    {
        bool haveSpace = false;

        for (int i = 0; i < shopItems.Length - 1; i++)
        {

            if (shopItems[i] == "")
            {
                shopItems[i] = shopItems[i + 1];
                shopItems[i + 1] = "";
            }

            if (shopItems[i] == "")
            {
                haveSpace = true;
            }
            else
            {
                haveSpace = false;
            }

            while (haveSpace)
            {
                for (int j = i + 2; j < shopItems.Length; j++)
                {
                    if (shopItems[j] != "")
                    {
                        shopItems[i] = shopItems[j];
                        shopItems[j] = "";
                        haveSpace = false;
                        break;
                    }
                }
                haveSpace = false;
            }
        }

    }

    private void UpdateItemButton()
    {
        for (int i = 0; i < shopItems.Length; i++)
        {
            if (shopItems[i] != "")
            {
                for (int j = 0; j < itemsInfo.Length; j++)  // Search through the itemsInfo array to find the same items by name
                {
                    if (shopItems[i] == itemsInfo[j].itemName)
                    {
                        if (itemsInfo[j].number > 0)
                        {
                            itemButtons[i].buttonImage.color = new Color(1, 1, 1, 1);
                            itemButtons[i].buttonImage.sprite = itemsInfo[j].sprite;
                            itemButtons[i].GetComponentInChildren<Text>().text = itemsInfo[j].number.ToString();
                            break;
                        }
                        else
                        {
                            itemButtons[i].buttonImage.color = new Color(1, 1, 1, 0);
                            itemButtons[i].buttonImage.sprite = itemsInfo[j].sprite;
                            shopItems[i] = "";

                            break;
                        }

                    }
                }
            }
            else
            {
                itemButtons[i].buttonImage.color = new Color(1, 1, 1, 0);
                itemButtons[i].GetComponentInChildren<Text>().text = "";
            }
        }
    }



    public void BuyItem()  // Pressed the Buy button
    {
        // TODO: check if you have enough money
        if (shopIndex >= 0)
        {
            for (int i = 0; i < itemsInfo.Length; i++)
            {
                if (shopItems[this.shopIndex] == itemsInfo[i].itemName && itemsInfo[i].number > 0)
                {
                    GameManager.instance.AddItems(activeItem);
                    itemsInfo[i].number--;

                    if (itemsInfo[i].number <= 0)
                    {
                        shopItems[this.shopIndex] = "";
                    }

                    SortShopItems();
                    UpdateItemButton();
                    itemButtons[shopIndex].Pressed();
                    break;
                }
            }
        }

    }

    public void AssignButtonValues()
    {
        for (int i = 0; i < itemButtons.Length; i++)
        {
            itemButtons[i].buttonValue = i;
        }
    }
}
