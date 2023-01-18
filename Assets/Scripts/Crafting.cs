using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafting : MonoBehaviour
{
    [SerializeField] ItemContainer inventory;
    public void Craft(CraftingRecipe recipe)
    {
        String messageToUser = "You need: ";
        bool canMake = true;
        if (inventory.FreeSpace() == false)
        {
            //Debug.Log("Not enough space in Inventory");
            GameManager.instance.messageController.Show("Not enough space in Inventory",1, Color.black);
            return;
        }
        
        for (int i = 0; i < recipe.elements.Count; i++)
        {
            if (inventory.CheckItem(recipe.elements[i]) == false)
            {
                Debug.Log("Don't have enough crafting items for recipe");
                messageToUser += recipe.elements[i].count+" "+recipe.elements[i].item.name+"\n";
                canMake = false;
            }
        }

        if (canMake == false)
        {
            GameManager.instance.messageController.Show(messageToUser,2,Color.black);
            return;
        }

        
        for (int i = 0; i < recipe.elements.Count; i++)
        {
            inventory.Remove(recipe.elements[i].item, recipe.elements[i].count);
        }

        inventory.Add(recipe.output.item, recipe.output.count);
        GameManager.instance.inventoryPanel.Show();
        GameManager.instance.toolbarPanel.Show();

    }
}
