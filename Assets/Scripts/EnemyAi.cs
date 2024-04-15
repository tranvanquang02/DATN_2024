using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    private enum State {
        roaming
    }
    private State state;
    Vector2 RoamingPosition;
    private Movement m_movement;

    private void Awake()
    {
        m_movement = GetComponent<Movement>();
        state = State.roaming;
    }
    private void Start()
    {
        StartCoroutine(RoamingRoutine());
    }
    private void FixedUpdate()
    {
        m_movement.Move(RoamingPosition);
    }
    private IEnumerator RoamingRoutine()
    {
        while(state == State.roaming)
        {
            RoamingPosition = GetRoamingPosition();
 
            yield return new WaitForSeconds(3f);
        }
    }
    private Vector2 GetRoamingPosition()
    {
        return new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
}
