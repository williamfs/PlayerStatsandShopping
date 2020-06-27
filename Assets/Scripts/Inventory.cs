using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject inventoryPanel;
    private bool hasOpen;
    public GameObject inventory;
    public GameObject playerStats;

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
        hasOpen = !hasOpen;
    }

    public void OpenInventory()
    {
        playerStats.SetActive(false);
        inventory.SetActive(true);
    }

    public void OpenPlayerStats()
    {
        inventory.SetActive(false);
        playerStats.SetActive(true);
    }


}
