using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootContainerInteract : Interacable
{
    [SerializeField] GameObject OpenChest;
    [SerializeField] GameObject CloseChest;
    [SerializeField] bool Opened;
    [SerializeField] AudioClip onOpenAudio;
    [SerializeField] ItemContainer itemContainer;

    public override void Interact(Player player)
    {
        if(Opened == false)
        {
            Open(player);
        }
        else
        {
            Close(player);
        }
    }
    public void Open(Player Player)
    {
        Opened = true;
        OpenChest.SetActive(true);
        CloseChest.SetActive(false);

        AudioManager.Instance.Play(onOpenAudio);
        Player.GetComponent<ItemContainerInteractController>().Open(itemContainer, transform);
    }
    public void Close(Player Player)
    {
        Opened = false;
        OpenChest.SetActive(false);
        CloseChest.SetActive(true);

        AudioManager.Instance.Play(onOpenAudio);

        Player.GetComponent<ItemContainerInteractController>().Close();
    }
}
