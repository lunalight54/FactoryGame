using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FurnanceInteractableController : Interactable
{
    [SerializeField] GameObject workingFurnance;
    [SerializeField] GameObject NotWorkingFurnance;
    [SerializeField] bool isWorking;
    private bool isOpened;
    [SerializeField] private FurnanceRecipeList furnanceRecipeList;
    [SerializeField] private Item fuelForFurnance;
    [SerializeField] private float oneIterationLength;
    [SerializeField] ItemContainer itemContainer;
    private ItemSlot toMeltItemSlot;
    private ItemSlot meltedItemSlot;
    private ItemSlot fuelSlot;
    private float time;

    private void Start()
    {
        isOpened = false;
        time = 0;
        if (itemContainer == null)
        {
            itemContainer = (ItemContainer)ScriptableObject.CreateInstance(typeof(ItemContainer));
            itemContainer.Init(3);
        }
        toMeltItemSlot = itemContainer.slots[0];
        meltedItemSlot = itemContainer.slots[1];
        fuelSlot = itemContainer.slots[2];
    }

    public void Update()
    {
        time += Time.deltaTime;
        if (time > oneIterationLength)
        {
            time = 0;
            if (Production(toMeltItemSlot.item) != null &&
                fuelSlot.item != null &&
                (meltedItemSlot.item == null || meltedItemSlot.item == Production(toMeltItemSlot.item))
               )
            {
                if(isWorking == false)
                    startWork();
                if (Production(toMeltItemSlot.item) == null)
                    return;
                if (fuelSlot.item == fuelForFurnance)
                {
                    if (meltedItemSlot.item == null)
                    {
                        meltedItemSlot.Set(Production(toMeltItemSlot.item), 1);
                    }
                    else if (meltedItemSlot.item == Production(toMeltItemSlot.item))
                    {
                        meltedItemSlot.count++;
                    }

                    fuelSlot.Decrease();
                    toMeltItemSlot.Decrease();
                    
                    
                    GameManager.instance.furnancePanel.Show();
                }
            }

            if (fuelSlot.count ==0 || toMeltItemSlot.count == 0)
            {
                stopWork();
            }
        }
    }

    public override void Interact(Character character)
    {
        if (isOpened == false)
        {
            Open(character);
        }
        else {
            Close(character);
        }
    }
    public  void Open(Character character)
    {
        isOpened = true;
        character.GetComponent<FurnanceContainerInteractController>().Open(itemContainer, transform);
    }

    public  void Close(Character character)
    {
        isOpened = false;
        character.GetComponent<FurnanceContainerInteractController>().Close();
    }

    public void startWork()
    {
        isWorking = true;
        NotWorkingFurnance.SetActive(false);
        workingFurnance.SetActive(true);
    }
    public void stopWork()
    {
        isWorking = false;
        NotWorkingFurnance.SetActive(true);
        workingFurnance.SetActive(false);
    }

    public Item Production(Item itemToMelt)
    {
        foreach (var recipe in furnanceRecipeList.recipes)
        {
            if (itemToMelt == recipe.input)
            {
                return recipe.output;
            }
        }

        return null;
    }
}
