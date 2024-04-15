using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    [SerializeField]public CollectableType m_type;

    public Rigidbody2D m_Rigidbody;
    public Sprite m_icon;

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        PlayerController player = collision.GetComponent<PlayerController>();

        if (player != null)
        {
            player.m_inventory.Add(this);
            Destroy(this.gameObject);
        }
    }
}
public enum CollectableType
{
    weapon, 
    food,
    seed,
    treasure,
    none
}
