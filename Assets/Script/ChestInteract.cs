using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInteract : Interactable
{
    [SerializeField] GameObject chest_close;
    [SerializeField] GameObject chest_open;
    [SerializeField] bool opened;

    public override void Interact(Character character)
    {
        if (opened == false)
        {
            opened = true;
            chest_close.SetActive(false);
            chest_open.SetActive(true);

        }
        else
        {
            opened = false;
            chest_close.SetActive(true);
            chest_open.SetActive(false);
        }        
    }
}
