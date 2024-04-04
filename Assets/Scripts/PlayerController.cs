using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float m_speed;


    private PlayerControll m_Input;
    private Vector2 m_MoveInputValue;
    private bool m_AttackInputValue;

    private Animator m_Animator;

    private void OnEnable()
    {
        m_Animator = GetComponent<Animator>();
        m_Input = new PlayerControll();
        m_Input.Enable();
    }
    private void OnDisable()
    {
        m_Input.Disable();
    }
    private void Update()
    {
        m_MoveInputValue = m_Input.Player.Move.ReadValue<Vector2>();
        m_Input.Player.Attack.started += _ => Attack();
    }

    private void FixedUpdate()
    {
        transform.Translate(m_MoveInputValue * Time.deltaTime * m_speed);
        AnimatorMovement(m_MoveInputValue);
    }
    void AnimatorMovement(Vector2 direction)
    {
        if (m_Animator != null)
        {
            if (direction.magnitude > 0)
            {
                m_Animator.SetFloat("horizontal", direction.x);
                m_Animator.SetFloat("vertical", direction.y);
                m_Animator.SetBool("isWalking", true);
            }
            else
            {
                m_Animator.SetBool("isWalking", false);
            }
        }
    }
    private void Attack()
    {
        m_Animator.SetTrigger("Attack");
    }
}
