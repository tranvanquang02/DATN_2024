using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkInteract : Interacable
{
    [SerializeField] DialogueContainer dialogueContainer;
    public override void Interact(Player Player)
    {
        GameManager.Instance.dialogueSystem.Initialize(dialogueContainer);
    }
}
