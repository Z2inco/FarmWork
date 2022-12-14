using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPanel : MonoBehaviour
{
    
    public ItemContainer inventory;
    public List<InventoryButton> buttons;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        SetIndex();
        Show();
    }
    private void OnEnable()
    {
        Show();
    }

    private void LateUpdate()
    {
        if (inventory == null) { return; }

        if (inventory.isDirty)
        {
            Show();
            inventory.isDirty = false;
        }
    }

    private void SetIndex()
    {
        //遍历库存和按钮计数 （&&工具栏 防止超出按钮数
        for (int i = 0; i < inventory.slots.Count && i < buttons.Count; i++)
        {
            buttons[i].SetIndex(i);
        }
    }

    public void Show()
    {
        if (inventory == null) { return; }
        for (int i = 0; i < inventory.slots.Count && i < buttons.Count; i++)
        {
            if (inventory.slots[i].item == null)
            {
                buttons[i].Clean();
            }
            else
            {
                buttons[i].Set(inventory.slots[i]);
            }
        }
    }

    public virtual void onClick(int id)
    {

    }
}

