using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStats : MonoBehaviour
{
    public string charName;
    public int playerLevel = 1;
    public int currentEXP;
    public int[] expToNextLevel;
    public int maxLevel = 100;
    public int baseEXP = 1000;

    public int currentHP;
    public int maxHP = 100;
    public int currentMP;
    public int maxMP = 30;
    public int[] mpLvlBonus;

    public int strength;
    public int defence;
    public int wpnPwr;
    public int armrPwr;

    public string equippedWpn;
    public string equippedArmr;
    public Sprite charImage;

    // Start is called before the first frame update
    void Start()
    {
        expToNextLevel = new int[maxLevel];
        expToNextLevel[1] = baseEXP;

        for (int i = 2; i < expToNextLevel.Length; i++)
        {
            expToNextLevel[i] = Mathf.RoundToInt(expToNextLevel[i - 1] * 1.05f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))  // TODO: delete this and call AddExp outside
        {
            AddExp(1000);
        }
    }

    public void AddExp(int exp) // Call this when you need
    {
        if (playerLevel < maxLevel)
        {
            currentEXP += exp;

            if (currentEXP >= expToNextLevel[playerLevel])
            {
                currentEXP -= expToNextLevel[playerLevel];
                LevelUp();
            }
        }
        
        if(playerLevel >= maxLevel)
        {
            currentEXP = 0;
        }
    }

    private void LevelUp() // Helper method
    {
        playerLevel++;

        // Gain all the stats you need 
        if (playerLevel % 2 == 0)  // even
        {
            strength += 2;
        }
        else
        {
            defence += 3;
        }

        maxHP = Mathf.FloorToInt(maxHP * 1.03f);
        currentHP = maxHP;

        maxMP += mpLvlBonus[playerLevel];
        currentMP = maxMP;
    }
}
