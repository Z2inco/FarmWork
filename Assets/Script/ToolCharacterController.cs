using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ToolCharacterController : MonoBehaviour
{
    PlayerController2D character;
    Rigidbody2D rg2d;
    ToolBarController toolBarController;
    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteractableArea = 1.2f;
    [SerializeField] MarkerManger markerManger;
    [SerializeField] TileMapReadController tileMapReadcontroller;
    [SerializeField] float maxDistance = 1.5f;  //工具最大涉及范围
    //[SerializeField] CropsManager cropsManager;
    //[SerializeField] TileData plowableTile;


    Vector3Int selectedTilePosition;
    bool selectable;

    private void Awake() {
        character = GetComponent<PlayerController2D>();
        rg2d = GetComponent<Rigidbody2D>();
        toolBarController = GetComponent<ToolBarController>();
    }

    private void Update() {
        SelectTile();
        CanSelectCheck();
        Marker();
        if (Input.GetMouseButtonDown(0)) {
            if (UseToolWorld())
            {
                return;
            }
            UseToolGrid();
        }
    }

    private void SelectTile()
    {
        selectedTilePosition = tileMapReadcontroller.GetGridPosition(Input.mousePosition, true);
    }

    void CanSelectCheck()
    {
        Vector2 characterPosition = transform.position;
        Vector2 cameraPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        selectable = Vector2.Distance(characterPosition, cameraPosition) < maxDistance;
        markerManger.Show(selectable);
    }
    private void Marker()
    {
        markerManger.markedCellPosition = selectedTilePosition;
    }

    private bool UseToolWorld()
    {
        Vector2 position = rg2d.position + character.lastMotionVector * offsetDistance;

        Item item = toolBarController.GetItem;
        if(item == null || item.onAction == null) { return false; }
        bool complete =  item.onAction.OnApply(position);
        if (complete == true)
        {
            if (item.onItemUsed != null)
            {
                item.onItemUsed.OnItemUsed(item, GameManager.instance.inventoryContainer);
            }

        }

       
        return complete;
    }

    private void UseToolGrid()
    {
        if (selectable == true)
        {
            Item item = toolBarController.GetItem;
            if (item == null || item.onTileMapAction == null) { return; }

            bool complete = item.onTileMapAction.OnApplyToTileMap(selectedTilePosition, tileMapReadcontroller, item);

            if (complete == true)
            {
                if (item.onItemUsed != null)
                {
                    item.onItemUsed.OnItemUsed(item, GameManager.instance.inventoryContainer);
                }
                
            }

        }
    }
}
