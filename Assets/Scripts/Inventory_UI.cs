using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_UI : MonoBehaviour
{
    [SerializeField]public GameObject m_inventory;
    [SerializeField]private PlayerController m_player;

    [SerializeField]
    List<Slot_UI> slots = new List<Slot_UI>();
    
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleInventory();
        }
        Refresh();
    }
    public void ToggleInventory()
    {
        if (!m_inventory.activeSelf)
        {
            m_inventory.SetActive(true);
            m_player.m_Animator.enabled = false;
        }
        else
        {
            m_inventory.SetActive(false);
            m_player.m_Animator.enabled = true;
        }
    }
    public void Refresh()
    {
        if (this.slots.Count == m_player.m_inventory.slots.Count)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if (m_player.m_inventory.slots[i].m_type != CollectableType.none)
                {
                    slots[i].setItem(m_player.m_inventory.slots[i]);
                }
                else {
                    slots[i].setEmpty();
                }
            }
        }
        
    }
    public void Remove_FromUi(int slotID)
    {
        Collectable itemToDrop = GameManager.Instance.m_itemManager.GetCollectableByType(m_player.m_inventory.slots[slotID].m_type);
        
        if (itemToDrop != null)
        {
            m_player.DropItem(itemToDrop);
            m_player.m_inventory.remove(slotID);
            Refresh();

        }
    }
}
