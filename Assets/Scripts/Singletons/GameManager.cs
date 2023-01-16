using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
        Debug.LogWarning("Game manager is created");
    }

    public GameObject player;
    public ItemContainer itemContainer;
    public ItemDragAndDropController itemDragAndDropController;
    public PlaceableObjectsReferenceManager placeableObjectsReferenceManager;
    public ItemPanel toolbarPanel;
    public ItemPanel inventoryPanel;

}
