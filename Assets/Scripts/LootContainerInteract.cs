using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootContainerInteract : Interactable
{
    [SerializeField] GameObject closedChest;
    [SerializeField] GameObject openedChest;
    [SerializeField] bool opened;
    [SerializeField] ItemContainer itemContainer;

    private void Start()
    {
        if (itemContainer == null)
        {
            itemContainer = (ItemContainer)ScriptableObject.CreateInstance(typeof(ItemContainer));
            itemContainer.Init(18);
        }
    }
    public override void Interact(Character character)
    {
        if (opened == false)
        {
            Open(character);
        }
        else {
            Close(character);
        }
    }

    public void Open(Character character) 
    {
        opened = true;
        closedChest.SetActive(false);
        openedChest.SetActive(true);

        character.GetComponent<ChestContainerInteractController>().Open(itemContainer, transform);
    }

    public void Close(Character character) 
    {
        opened = false;
        closedChest.SetActive(true);
        openedChest.SetActive(false);
        character.GetComponent<ChestContainerInteractController>().Close();
    }
}