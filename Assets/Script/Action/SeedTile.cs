using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName ="Data/Tool Action/Seeds Tile")]
public class SeedTile : ToolAction
{
    //[SerializeField] List<TileBase> canSeed;
    public override bool OnApplyToTileMap(Vector3Int gridPosition, TileMapReadController tileMapReadController,Item item)
    {
        //TileBase tileToSeed = tileMapReadController.GetTileBase(gridPosition);
        if (tileMapReadController.cropsManager.Check(gridPosition) == false)
        {
            return false;
        }
        tileMapReadController.cropsManager.Seed(gridPosition, item.crop);

        return true;

    }

    public override void OnItemUsed(Item usedItem, ItemContainer inventory)
    {
        inventory.Remove(usedItem);
    }
}
