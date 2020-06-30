using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public GameObject shopingPanel;
    public string[] shopItems = new string[32];
    public Button[] itemButtons;
    public Image[] itemImages;
    public Item[] itemsInfo;


    public Text descriptionText;

    public Item activeItem;
    public int shopIndex;

    private bool hasOpen;

    // Start is called before the first frame update
    void Start()
    {
        itemImages = new Image[itemButtons.Length];
        for (int i = 0; i < itemImages.Length; i++)
        {
            itemImages[i] = itemButtons[i].transform.GetChild(0).GetComponent<Image>();
        }
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
                            itemImages[i].color = new Color(1, 1, 1, 1);
                            itemImages[i].sprite = itemsInfo[j].sprite;
                            itemButtons[i].GetComponentInChildren<Text>().text = itemsInfo[j].number.ToString();
                            break;
                        }
                        else
                        {
                            itemImages[i].color = new Color(1, 1, 1, 0);
                            itemImages[i].sprite = itemsInfo[j].sprite;
                            shopItems[i] = "";

                            break;
                        }

                    }
                }
            }
            else
            {
                itemImages[i].color = new Color(1, 1, 1, 0);
                itemButtons[i].GetComponentInChildren<Text>().text = "";
            }
        }
    }

    public void Pressed(int shopIndex)  // When you pressed the button on shop menu, show the detail of that item
    {
        if (shopItems[shopIndex] != "")
        {
            for (int j = 0; j < itemsInfo.Length; j++)
            {
                if (itemsInfo[j].itemName == shopItems[shopIndex])
                {
                    descriptionText.text = itemsInfo[j].description;
                    activeItem = itemsInfo[j];
                    this.shopIndex = shopIndex;
                }
            }
        }
    }

    public void BuyItem()  // Pressed the Buy button
    {
        // TODO: check if you have enough money

        for (int i = 0; i < shopItems.Length; i++)
        {
            if (shopItems[shopIndex] == itemsInfo[i].itemName && itemsInfo[i].number > 0)
            {
                GameManager.instance.AddItems(activeItem);
                itemsInfo[i].number--;

                if (itemsInfo[i].number <= 0)
                {
                    shopItems[shopIndex] = "";
                }

                SortShopItems();
                UpdateItemButton();
                break;
            }
        }
    }
}
