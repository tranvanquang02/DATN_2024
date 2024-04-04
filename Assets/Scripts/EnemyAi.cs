using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    private enum State {
        roaming
    }
    private State state;
    private EnemyPath m_path;

    private void Awake()
    {
        m_path = GetComponent<EnemyPath>();
        state = State.roaming;
    }
    private void Start()
    {
        StartCoroutine(RoamingRoutine());
    }
    private IEnumerator RoamingRoutine()
    {
        while(state == State.roaming)
        {
            Vector2 RoamingPosition = GetRoamingPosition();
            m_path.MoveTo(RoamingPosition);
            yield return new WaitForSeconds(3f);
        }
    }
    private Vector2 GetRoamingPosition()
    {
        return new Vector2(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f)).normalized;
    }
}
