using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestPanel : ItemPanel
{
    public override void OnClick(int id)
    {
        GameManager.instance.itemDragAndDropController.OnClick(itemContainer.slots[id]);
        Show();
    }
}
