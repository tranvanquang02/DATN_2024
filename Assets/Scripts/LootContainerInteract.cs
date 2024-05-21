using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootContainerInteract : Interacable
{
    [SerializeField] GameObject OpenChest;
    [SerializeField] GameObject CloseChest;
    [SerializeField] bool Opened;

    public override void Interact(Player Player)
    {
        if(Opened == false)
        {
            Opened = true;
            OpenChest.SetActive(true); CloseChest.SetActive(false);
        }
    }
}
