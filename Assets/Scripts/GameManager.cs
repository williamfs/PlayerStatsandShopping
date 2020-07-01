using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemInBackPack
{
    public string itemName;
    public int amount;
    public Sprite sprite;

    public ItemInBackPack(Item item)
    {
        this.itemName = item.itemName;
        this.amount = 1;
        this.sprite = item.sprite;
    }
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int currentMoney = 1000;
    public List<ItemInBackPack> Inventory = new List<ItemInBackPack>();

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

    public void AddItems(Item itemToAdd, int amount = 1)  // Called by ShopManager when you hit Buy button
    {
        if (Inventory.Count > 0)
        {
            for (int i = 0; i < Inventory.Count; i++)
            {
                if (Inventory[i].itemName == itemToAdd.itemName)
                {
                    Inventory[i].amount++;
                    return;
                }
            }

            // new item added
            ItemInBackPack newItem = new ItemInBackPack(itemToAdd);
            Inventory.Add(newItem);
        }
        else
        {
            ItemInBackPack newItem = new ItemInBackPack(itemToAdd);
            Inventory.Add(newItem);
        }
    }
}
