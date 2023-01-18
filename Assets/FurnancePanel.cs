using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnancePanel : ItemPanel
{
    //[SerializeField] private FurnanceInteractableController furnance;
    public override void OnClick(int id)
    {
        GameManager.instance.itemDragAndDropController.OnClick(itemContainer.slots[id]);
        Show();
        
    }
}
