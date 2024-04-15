using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemManager : MonoBehaviour
{
    [SerializeField]private Collectable[] m_collectables;
    
    private Dictionary<CollectableType,Collectable> m_collectedableItemDic = new Dictionary<CollectableType,Collectable>();

    private void Awake()
    {
        foreach (Collectable item in m_collectables)
        {
            AddItem(item);
        }
    }
    private void AddItem(Collectable item)
    {
        if (!m_collectedableItemDic.ContainsKey(item.m_type))
        {
            m_collectedableItemDic.Add(item.m_type, item);
        }
    }
    public Collectable GetCollectableByType(CollectableType type)
    {
        if (m_collectedableItemDic.ContainsKey(type))
        {
            return m_collectedableItemDic[type];
        }
        return null;
    }

}
