using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BackPack
{
    public BackPack(Item newItem)
    {
        this.item = newItem;
    }

    public Item item;
    public int amount;
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //public List<BackPack> Inventory = new List<BackPack>();
    public List<Item> Inventory2 = new List<Item>();

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

    //public void AddItems(BackPack itemToAdd, int amount = 1)
    //{
    //    if (!Inventory.Contains(itemToAdd))
    //    {
    //        Inventory.Add(itemToAdd);
    //    }
    //    else
    //    {
    //        int index = Inventory.IndexOf(itemToAdd);
    //        int backpackAmount = Inventory[index].amount;
    //        backpackAmount += amount;
    //        Inventory[index].amount = backpackAmount;
    //        Debug.Log(Inventory[index] + " has " + Inventory[index].amount);
    //    }

    //}

    public void AddItems2(Item itemToAdd, int amount = 1)
    {
        if (!Inventory2.Contains(itemToAdd))
        {
            Inventory2.Add(itemToAdd);
        }
        else
        {
            int index = Inventory2.IndexOf(itemToAdd);
            int backpackAmount = Inventory2[index].number;
            backpackAmount += amount;
            Inventory2[index].number = backpackAmount;
            Debug.Log(Inventory2[index] + " has " + Inventory2[index].number);
        }

    }
}
