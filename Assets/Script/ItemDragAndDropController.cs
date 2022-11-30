using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDragAndDropController : MonoBehaviour
{
    public ItemSlot itemSlot;
    [SerializeField]GameObject itemIcon;
    RectTransform iconTransform;

    public bool CheckForSale()
    {
        if(itemSlot.item == null) { return false; }
        if(itemSlot.item.canBeSold == false) { Debug.Log("1"); return false; }
        return true;
    }

    Image itemIconImage;

    private void Start ()
    {
        itemSlot = new ItemSlot();
        iconTransform = itemIcon.GetComponent<RectTransform>();
        itemIconImage = itemIcon.GetComponent<Image>();
    }

    private void Update()
    {
        //拖动图标
        if (itemIcon.activeInHierarchy == true)
        {
            iconTransform.position = Input.mousePosition;
            //删除物品
            if (Input.GetMouseButtonDown(0))
            {
                //检测是否在物品栏外点击（扔掉动作
                if (EventSystem.current.IsPointerOverGameObject() == false)
                {
                 
                    Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    //设置视口深度
                    worldPosition.z = 0;
                    ItemSpawnManager.instance.SpawnItem(worldPosition, itemSlot.item, itemSlot.count);

                    itemSlot.Clear();
                    itemIcon.SetActive(false);
                }
            }
            
        }
    }

    internal void onClick(ItemSlot itemSlot)
    {
        if (this.itemSlot.item == null)
        {
            //为空直接复制
            this.itemSlot.Copy(itemSlot);
            itemSlot.Clear();
        }
        else
        {
            //不为空 交换物品栏物品
            Item item = itemSlot.item;
            int count = itemSlot.count;

            itemSlot.Copy(this.itemSlot);
            this.itemSlot.Set(item, count);
        }
        UpdateIcon();
    }

    public void UpdateIcon()
    {
        if (itemSlot.item == null)
        {
            itemIcon.SetActive(false);
        }
        else
        {
            itemIcon.SetActive(true);
            itemIconImage.sprite = itemSlot.item.icon;
        }

        
    }
}
