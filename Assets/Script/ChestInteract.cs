using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInteract : Interactable
{
    [SerializeField] GameObject chest_close;
    [SerializeField] GameObject chest_open;
    [SerializeField] bool opened;
    [SerializeField] AudioClip onOpenAudio;
    [SerializeField] AudioClip onCloseAudio;

    public override void Interact(Character character)
    {
        Trading trading = character.GetComponent<Trading>();

        if (trading == null) { return; }

        if (opened == false)
        {
            opened = true;
            chest_close.SetActive(false);
            chest_open.SetActive(true);
            trading.BeginTrading(this);

            AudioManager.instance.Play(onOpenAudio);
        }
        else
        {
            opened = false;
            chest_close.SetActive(true);
            chest_open.SetActive(false);
            AudioManager.instance.Play(onCloseAudio);
        }

       

        
    }
}
