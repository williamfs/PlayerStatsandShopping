using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Dictionary<Item, int> inventory = new Dictionary<Item, int>();  // item, amount

    public Item[] itemPrefabs;

    // Start is called before the first frame update
    void Start()
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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            //Debug.Log(inventory[itemPrefabs[0]] + " has " + inventory[itemToAdd]);

        }
    }

    public void AddItems(Item itemToAdd, int amount = 1)
    {
        if (!inventory.ContainsKey(itemToAdd))
        {
            inventory.Add(itemToAdd, amount);
        }
        else
        {
            int backpackAmount = inventory[itemToAdd];
            backpackAmount += amount;
            inventory[itemToAdd] = backpackAmount;
        }

        Debug.Log(itemToAdd.itemName + " has " + inventory[itemToAdd]);
    }
}
