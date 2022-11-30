using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

//读取纹理地图的位置、名称
public class TileMapReadController : MonoBehaviour
{
    public CropsManager cropsManager;
    [SerializeField] Tilemap tilemap;
    

    public Vector3Int GetGridPosition(Vector2 position, bool mousePosition)
    {
        //修复因分场景破坏的种植系统
        if (tilemap == null)
        {
            tilemap = GameObject.Find("BaseTilemap").GetComponent<Tilemap>();
        }

        if (tilemap == null) { return Vector3Int.zero; }

        Vector3 worldPosition;
        if (mousePosition)
        {
            worldPosition = Camera.main.ScreenToWorldPoint(position);
        }
        else
        {
            worldPosition = position;
        }
        Vector3Int gridPosition = tilemap.WorldToCell(worldPosition);

        return gridPosition;
    }

    public TileBase GetTileBase(Vector3Int gridPosition)
    {
        if (tilemap == null)
        {
            tilemap = GameObject.Find("BaseTilemap").GetComponent<Tilemap>();
        }

        if (tilemap == null) { return null; }

        TileBase tile = tilemap.GetTile(gridPosition);

        return tile;
    }

  
}
