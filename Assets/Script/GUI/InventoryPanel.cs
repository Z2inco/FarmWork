using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : ItemPanel
{
    public override void onClick(int id)
    {
        GameManager.instance.dragAndDropController.onClick(inventory.slots[id]);
        Show();
    }
}
