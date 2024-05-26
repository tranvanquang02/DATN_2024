using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCutable : ToolHit
{
    [SerializeField] GameObject DropItem;
    
    [SerializeField] float Spread = 5f;

    [SerializeField] int itemCountInOneDrop;

    [SerializeField] Item item;
    [SerializeField] int DropCount = 5;
    public override void Hit()
    {
        while (DropCount > 0)
        {
            DropCount--;

            Vector3 position = transform.position;
            position.x += Spread * Random.value - Spread / 2;
            position.y += Spread * Random.value - Spread / 2;
            
            ItemSpawManager.Instance.SpawnItem(position, item, itemCountInOneDrop);
        }
        Destroy(gameObject);
    }

}
