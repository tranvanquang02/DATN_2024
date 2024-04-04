using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{


    [SerializeField] private float m_speed;

    private Vector2 moveDir;
    private Rigidbody2D m_Rigidbody2D;
    void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        m_Rigidbody2D.MovePosition(m_Rigidbody2D.position + moveDir * (m_speed * Time.deltaTime));
    }
    public void MoveTo(Vector2 roamingPosition)
    {
        moveDir = roamingPosition;
    }
}
