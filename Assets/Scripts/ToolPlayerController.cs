using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolPlayerController : MonoBehaviour
{
    private PlayerController player;
    private Rigidbody2D rb;
    [SerializeField] float OffsetDistance = 1.0f;
    [SerializeField] float SizeOfInteracableArea = 1.2f;

    private void Awake()
    {
        player = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            UseTool();
        }
    }

    private void UseTool()
    {
        Vector2 position = rb.position + player.LastMotionVector * OffsetDistance;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, SizeOfInteracableArea);

        foreach (Collider2D item in colliders)
        {
            ToolHit hit = item.GetComponent<ToolHit>();
            if(hit != null)
            {
                hit.Hit();
                break;
            }
                
        }
    }
}
