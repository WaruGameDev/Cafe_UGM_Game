using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Dictionary<string, int> inventory = new Dictionary<string, int>();
    public List<FoodSO> foodSOs = new List<FoodSO>();



    public Transform scrollInventory;
    public GameObject panelProduct;

    public FoodSO GetFoodSO(string foodName)
    {
        foreach (var food in foodSOs)
        {
            if(food.foodName == foodName) return food;
        }
        return null;
    }


    public void AddObject(string itemName, int count)
    {
        if (inventory.ContainsKey(itemName))
        {
            inventory[itemName] += count;
        }
        else
        {
            inventory.TryAdd(itemName, count);
        }
        Debug.Log("Has obtenido:" + count + " " + itemName);
        RefreshInventoryUI();

    }
    public int RemoveObject(string itemName, int count)
    {
        if (!inventory.ContainsKey(itemName))
        {
            RefreshInventoryUI();
            return 0;
        }
        else
        {
            if (inventory[itemName] >= count)
            {
                RefreshInventoryUI();
                inventory[itemName] -= count;
                return inventory[itemName];
            }
            else
            {
                RefreshInventoryUI();
                inventory[itemName] = 0;
                return inventory[itemName] - count;

            }
        }
        
    }
    public void RefreshInventoryUI()
    {
        if (inventory.Count <= 0)
        {
            return;
        }
        foreach(Transform child in scrollInventory)
        {
            Destroy(child.gameObject);
        }
        foreach (var item in inventory)
        {
            GameObject p = Instantiate(panelProduct, scrollInventory);
            p.GetComponent<FoodPanel>().SetInformation(GetFoodSO(item.Key), this);
        }

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            AddObject("Apple", 10);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            AddObject("Pie", 10);
        }
        
        if (Input.GetKeyDown(KeyCode.O))
        {
            RemoveObject("Apple", 5);
        }
    }
}
