using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Dictionary<Item, int> items = new Dictionary<Item, int>();

    public Item[] itemPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            AddItems(itemPrefabs[0]);
        }
    }

    public void AddItems(Item itemToAdd)
    {
        if (!items.ContainsKey(itemToAdd))
        {
            items.Add(itemToAdd, 1);
        }
        else
        {
            int amount = items[itemToAdd];
            amount++;
            items[itemToAdd] = amount;
        }

        Debug.Log(itemToAdd.itemName + " has " + items[itemToAdd]);
    }
}
