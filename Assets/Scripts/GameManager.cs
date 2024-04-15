using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager m_instance;

    public ItemManager m_itemManager;

    private void Awake()
    {
        if(m_instance != null && m_instance != this)
        {
            Destroy(m_instance);
        }
        else
        {
            m_instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
        m_itemManager = GetComponent<ItemManager>();
    }
    void Update()
    {
        
    }
}
