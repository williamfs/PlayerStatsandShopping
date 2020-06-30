using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject inventoryPanel;
    private bool hasOpen;
    public GameObject inventory;
    public GameObject playerStats;

    public GameObject[] items;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            TogglePlayerMenu();
        }
    }

    public void TogglePlayerMenu()
    {
        if (!hasOpen)
        {
            inventoryPanel.SetActive(true);
        }
        else
        {
            inventoryPanel.SetActive(false);
        }
        DisplayInventory();
        hasOpen = !hasOpen;
    }

    public void OpenInventory()
    {
        playerStats.SetActive(false);
        inventory.SetActive(true);

        // Update what dictionary have and display on this panel
        DisplayInventory();
    }

    private void DisplayInventory() // 從GameManager的List拿取資料 並顯示在UI上
    {
        for (int i = 0; i < GameManager.instance.Inventory.Count; i++)
        {
            items[i].GetComponentInChildren<Image>().color = new Color(1, 1, 1, 1);
            items[i].GetComponentInChildren<Image>().sprite = GameManager.instance.Inventory[i].sprite;
            items[i].GetComponentInChildren<Text>().text = GameManager.instance.Inventory[i].amount.ToString();
        }

        for (int j = GameManager.instance.Inventory.Count; j < items.Length; j++)
        {
            items[j].GetComponentInChildren<Image>().color = new Color(1, 1, 1, 0);
            items[j].GetComponentInChildren<Text>().text = "";
        }
    }

    public void OpenPlayerStats()
    {
        inventory.SetActive(false);
        playerStats.SetActive(true);
    }
}
