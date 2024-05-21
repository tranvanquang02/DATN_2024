using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCutable : ToolHit
{
    [SerializeField] GameObject DropItem;
    [SerializeField] int DropCount = 5;
    [SerializeField] float Spread = 0.7f;
    public override void Hit()
    {
        while (DropCount > 0)
        {
            DropCount--;

            Vector3 position = transform.position;
            position.x += Spread * Random.value - Spread / 2;
            position.y += Spread * Random.value - Spread / 2;
            GameObject go = Instantiate(DropItem);

            go.transform.position = position;
        }
        Destroy(gameObject);
    }

}
