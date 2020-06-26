using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public GameObject shopingPanel;
    public string[] shopItems = new string[40];
    public Button[] itemButtons;

    private bool hasOpen;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!hasOpen && Input.GetKeyDown(KeyCode.I))
        {
            OpenShoppingMenu();
        }
        else if (hasOpen && Input.GetKeyDown(KeyCode.I))
        {
            CloseShoppingMenu();
        }
    }

    private void OpenShoppingMenu()
    {
        hasOpen = true;
        shopingPanel.SetActive(true);
        SortItems();
        UpdateItemButton();
    }

    public void CloseShoppingMenu()
    {
        hasOpen = false;
        shopingPanel.SetActive(false);
    }

    private void UpdateItemButton()
    {
        for (int i = 0; i < shopItems.Length; i++)
        {
            if (shopItems[i] != "")
            {
                itemButtons[i].gameObject.SetActive(true);

                itemButtons[i].GetComponentInChildren<Text>().text = shopItems[i];
            }
            else
            {
                itemButtons[i].GetComponentInChildren<Text>().text = "";
            }
        }
    }

    private void SortItems()
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
}
