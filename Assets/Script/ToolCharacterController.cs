using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolCharacterController : MonoBehaviour
{
    PlayerController2D character;
    Rigidbody2D rg2d;
    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteractableArea = 1.2f;

    private void Awake() {
        character = GetComponent<PlayerController2D>();
        rg2d = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            UseTool();
        }
    }

    private void UseTool()
    {
        Vector2 position = rg2d.position + character.lastMotionVector * offsetDistance;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

        foreach (Collider2D c in colliders) {
            ToolHit hit = c.GetComponent<ToolHit>();
            if (hit != null) {
                hit.Hit();
                break;
            }
        }
    }
}
