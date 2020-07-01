using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;
    public GameObject shopingPanel, notificationPanel;
    public Text descriptionText, costText, moneyText;
    public ItemButton firstButton;

    public string[] shopItems = new string[32];
    public ItemButton[] itemButtons;
    public Item[] itemsInfo;

    public Item activeItem;
    public int shopIndex;

    private bool hasOpen;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

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
        firstButton.Pressed();
    }

    public void CloseShoppingMenu()
    {
        hasOpen = false;
        shopingPanel.SetActive(false);
        shopIndex = 0;
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

        moneyText.text = GameManager.instance.currentMoney + "g";
        costText.text = itemsInfo[shopIndex].cost + "g";
    }

    public void BuyItem()  // Pressed the Buy button
    {
        if (shopIndex >= 0)
        {
            for (int i = 0; i < itemsInfo.Length; i++)
            {
                if (shopItems[this.shopIndex] == itemsInfo[i].itemName && itemsInfo[i].number > 0)  // Find the exact item in itemInfo
                {
                    if (GameManager.instance.currentMoney >= itemsInfo[i].cost) // Check if have enough money
                    {
                        GameManager.instance.currentMoney -= itemsInfo[i].cost;
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
                    else
                    {
                        // Show that you don't have enough money
                        notificationPanel.SetActive(true);
                    }
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
