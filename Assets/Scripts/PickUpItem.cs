using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    Transform player;
    [SerializeField] float Speed = 5;
    [SerializeField] float TimeToLive = 10f;
    [SerializeField] float PickupDistance = 1.5f;
    private float DistanceToPlayer;
        
    private void Start()
    {
        player = GameManager.Instance.m_PlayerController.transform;
    }

    private void Update()
    {
        TimeToLive -= Time.deltaTime;
        if (TimeToLive < 0)
        {
            Destroy(gameObject);
        }
        DistanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (DistanceToPlayer > PickupDistance)
        {
            return;
        }
        transform.position = Vector3.MoveTowards(
            transform.position, player.position,
            Speed * Time.deltaTime);

        if (DistanceToPlayer < 0.1f)
        {
            Destroy(gameObject);
        }
    }
}

