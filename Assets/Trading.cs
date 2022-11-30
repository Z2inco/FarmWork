using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trading : MonoBehaviour
{
    [SerializeField] GameObject storePanel;
    [SerializeField] GameObject inventoryPanel;

    ChestInteract store;

    Currency money;

    private void Awake()
    {
        money = GetComponent<Currency>();
    }

    public void BeginTrading(ChestInteract store)
    {
        this.store = store;
        //Debug.Log("Being Trading");

        storePanel.SetActive(true);
        inventoryPanel.SetActive(true);
    }

    public void StopTrading()
    {
        store = null;

        storePanel.SetActive(false);
        inventoryPanel.SetActive(false);
    }

    public void SellItem()
    {
        //Debug.Log("SellItem");
        if (GameManager.instance.dragAndDropController.CheckForSale() == true)
        {
            Debug.Log("true");
            ItemSlot itemToSell = GameManager.instance.dragAndDropController.itemSlot;
            int moneyGain = itemToSell.item.stackable == true ? itemToSell.item.price * itemToSell.count : itemToSell.item.price;
            money.Add(moneyGain);
            itemToSell.Clear();
            GameManager.instance.dragAndDropController.UpdateIcon();
        }
        else
        {
            Debug.Log("false");
        }
    }
}
