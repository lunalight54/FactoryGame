using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestContainerInteractController : MonoBehaviour
{
    ItemContainer targetItemContainer;
    [SerializeField] ChestContainerPanel itemContainerPanel;
    Transform locationOfObject;
    [SerializeField] float maxDistance = 2f;
    private ItemContainer itemContainer;
    InventoryController inventoryController;
    private void Awake()
    {
        inventoryController = GetComponent<InventoryController>();
    }

    private void Update()
    {
        if(locationOfObject != null) 
        {
            float distance = Vector2.Distance(locationOfObject.position, transform.position);

            if (distance > maxDistance) 
            {
                locationOfObject.GetComponent<LootContainerInteract>().Close(GetComponent<Character>());
            }
        }
    }

    public void Open(ItemContainer itemContainer, Transform _locationOfObject) 
    {
        targetItemContainer = itemContainer;
        itemContainerPanel.itemContainer = targetItemContainer;
        GameManager.instance.chestPanel.gameObject.SetActive(true);
        inventoryController.Open();
        itemContainerPanel.gameObject.SetActive(true);
        locationOfObject = _locationOfObject;
    }

    public void Close() 
    {
        GameManager.instance.chestPanel.gameObject.SetActive(false);
        itemContainerPanel.gameObject.SetActive(false);
        inventoryController.Close();
        locationOfObject = null;
    }
}
