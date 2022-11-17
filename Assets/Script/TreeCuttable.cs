using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCuttable : ToolHit
{
    [SerializeField]
    GameObject pickUpDrop;
    [SerializeField]
    int dropNum = 5;
    [SerializeField]
    float spread = 0.7f;
    [SerializeField]
    Item item;
    [SerializeField]
    int itemCountInOneDrop = 1;
    public override void Hit()
    {
        while (dropNum > 0) {
            dropNum -= 1;
            
            Vector3 position = transform.position;
            position.x += spread * UnityEngine.Random.value - spread / 2;
            position.y += spread * UnityEngine.Random.value - spread / 2;
            //GameObject obj = Instantiate(pickUpDrop);
            //obj.GetComponent<PickUpItems>().Set(item, itemCountInOneDrop);
            //obj.transform.position = position;

            ItemSpawnManager.instance.SpawnItem(position, item, itemCountInOneDrop);
        }
        Destroy(gameObject);
    }
}
