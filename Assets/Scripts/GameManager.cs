﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager> 
{
    public PlayerController m_PlayerController;
    public ItemContainer Inventory;
    public ItemDragAndDropController DragAndDropController;

}
