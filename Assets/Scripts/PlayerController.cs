using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Movement m_movement;
    public Inventory m_inventory;

    private PlayerControll m_Input;
    private Vector2 m_MoveInputValue;

    private Animator m_Animator;

    private void OnEnable()
    {
        m_inventory = new Inventory(21);

        m_Animator = GetComponent<Animator>();
        m_movement = GetComponent<Movement>();
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
        m_movement.Move(m_MoveInputValue);
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
        m_Animator.SetBool("isWalking", false);
        m_Animator.SetTrigger("Attack");
    }
    public void DropItem(Collectable item)
    {
        Vector2 SpawLocation = transform.position; ;



        Vector2 SpawOffset = UnityEngine.Random.insideUnitCircle * 1.25f;

        Collectable DropItem =  Instantiate(item, SpawLocation + SpawOffset, Quaternion.identity);

        DropItem.m_Rigidbody.AddForce(SpawOffset * 2f, ForceMode2D.Impulse);
    }
}
