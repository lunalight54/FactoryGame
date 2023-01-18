using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemContainerInteractController : MonoBehaviour
{
    ItemContainer targetItemContainer;
    InventoryController inventoryController;
    [SerializeField] ItemContainerPanel itemContainerPanel;
    Transform locationOfObject;
    [SerializeField] float maxDistance = 2f;

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
                
                locationOfObject.GetComponent<FurnanceInteractableController>().Close(GetComponent<Character>());

            }
        }
    }

    public void Open(ItemContainer itemContainer, Transform _locationOfObject) 
    {
        targetItemContainer = itemContainer;
        itemContainerPanel.itemContainer = targetItemContainer;
        inventoryController.Open();
        itemContainerPanel.gameObject.SetActive(true);
        locationOfObject = _locationOfObject;
    }

    public void Close() 
    {
        inventoryController.Close();
        itemContainerPanel.gameObject.SetActive(false);
        locationOfObject = null;
    }
}