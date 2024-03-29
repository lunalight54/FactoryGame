using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDragAndDropController : MonoBehaviour
{
    [SerializeField] ItemSlot itemSlot;
    [SerializeField] private GameObject ItemIcon;
    private RectTransform iconTransform;
    private RawImage itemIconImage;
    private void Start()
    {
        itemSlot = new ItemSlot();
        iconTransform = ItemIcon.GetComponent<RectTransform>();
        itemIconImage = ItemIcon.GetComponent<RawImage>();
    }

    private void Update()
    {
        if (ItemIcon.activeInHierarchy == true)
        {
            iconTransform.position = Input.mousePosition;
            if (Input.GetMouseButtonDown(0))
            {
                if (EventSystem.current.IsPointerOverGameObject() == false)
                {
                    Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    worldPosition.z = 0;

                    ItemSpawnManager.instance.SpawnItem(worldPosition, itemSlot.item, itemSlot.count);
                    itemSlot.Clear();
                    ItemIcon.SetActive(false);
                }
            }
            
        }
    }

    public void OnClick(ItemSlot currentItemSlot)
    {
        if (this.itemSlot.item == null)
        {
            this.itemSlot.Copy(currentItemSlot);
            currentItemSlot.Clear();
        }
        else
        {
            Item item = currentItemSlot.item;
            int count = currentItemSlot.count;
            currentItemSlot.Copy(this.itemSlot);
            this.itemSlot.Set(item, count);
        }

        UpdateIcon();
    }

    private void UpdateIcon()
    {
        if (itemSlot.item == null)
        {
            ItemIcon.SetActive(false);
        }
        else
        {
            ItemIcon.SetActive(true);
            itemIconImage.texture = itemSlot.item.icon.texture;
        }
    }
}
