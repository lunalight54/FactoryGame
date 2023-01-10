using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemSlot
{
    public Item item;
    public int count;

    public void Copy(ItemSlot slot)
    {
        item = slot.item;
        count = slot.count;
    }
    public void Set(Item item, int count)
    {
        this.item = item;
        this.count = count;
    }

    public void Clear()
    {
        item = null;
        count = 0;
    }
}
[CreateAssetMenu(menuName = "Data/Item Container")]
public class ItemContainer : ScriptableObject
{
    public List<ItemSlot> slots;

    public void Add(Item item, int count)
    {
        
        if (item.stackable == true)
        {
            ItemSlot availableItemSlot = slots.Find(x => x.item == item);
            if (availableItemSlot != null)
            {
                availableItemSlot.count += count;
            }
            else
            {
                availableItemSlot = slots.Find(x => x.item == null);
                if (availableItemSlot != null)
                {
                    availableItemSlot.item = item;
                    availableItemSlot.count = count;
                }
            }


        }
        else
        {
            ItemSlot availableItemSlot = slots.Find(x => x.item == null);
            if (availableItemSlot != null)
            {
                availableItemSlot.item = item;
            }
        }
    }
}
