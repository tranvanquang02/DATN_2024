using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager> 
{ 

    public ItemManager m_itemManager;

    private void Start()
    {
        m_itemManager = GetComponent<ItemManager>();
    }
    void Update()
    {
        
    }
}
