using UnityEngine;
using System.Collections;

public class ChaseEnemy : MonoBehaviour
{
    private Transform player;
    private Vector3 initialPosition;

    [SerializeField] private float speed = 2.0f;
    [SerializeField] private Vector2 attackSize = Vector2.one;
    [SerializeField] private int damage = 3;
    [SerializeField] private float timeToAttack = 2f;
    [SerializeField] private float detectionRange = 10f;
    [SerializeField] private float roamingRange = 5f;

    private float attackTimer;
    private bool isRoaming = true;

    private void Start()
    {
        player = GameManager.Instance.m_PlayerController.transform;
        initialPosition = transform.position;
        attackTimer = Random.Range(0, timeToAttack);
        StartCoroutine(MoveToPlayerCoroutine());
    }

    private void Update()
    {
        Attack();
    }

    IEnumerator MoveToPlayerCoroutine()
    {
        while (true)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            Debug.Log("Distance to player: " + distanceToPlayer);

            if (distanceToPlayer <= detectionRange)
            {
                // Phát hiện người chơi, dừng roaming và di chuyển về phía người chơi
                Debug.Log("Detected player, moving towards player");
                isRoaming = false;
                MoveToPlayer(player);
            }
            else if (!isRoaming)
            {
                // Không phát hiện người chơi và đang dừng roaming, bắt đầu roaming lại
                Debug.Log("Player lost, start roaming");
                isRoaming = true;
            }

            if (isRoaming)
            {
                // Roaming trong phạm vi xác định nếu không phát hiện người chơi
                Vector3 newRoamingPosition = GetNewRoamingPosition();
                Debug.Log("Roaming to new position: " + newRoamingPosition);
                yield return Roam(newRoamingPosition);
            }
           /* else
            {
                // Đợi 2 giây trước khi kiểm tra lại
                yield return new WaitForSeconds(2.0f);
            }*/
        }
    }

    private Vector3 GetNewRoamingPosition()
    {
        Vector3 randomOffset;
        Vector3 newRoamingPosition;

        do
        {
            randomOffset = new Vector3(
                Random.Range(-roamingRange, roamingRange),
                Random.Range(-roamingRange, roamingRange),
                0f
            );
            newRoamingPosition = initialPosition + randomOffset;
        } while (Vector3.Distance(initialPosition, newRoamingPosition) > roamingRange);

        return newRoamingPosition;
    }

    private IEnumerator Roam(Vector3 newRoamingPosition)
    {
        while (Vector3.Distance(transform.position, newRoamingPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, newRoamingPosition, speed * Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(2.0f);
    }

    private void MoveToPlayer(Transform playerTransform)
    {
        Debug.Log("Current Position: " + transform.position);
        Debug.Log("Target Position: " + playerTransform.position);

        transform.position = Vector3.MoveTowards(
            transform.position,
            playerTransform.position,
            speed * Time.deltaTime
        );

        Debug.Log("New Position: " + transform.position);
    }

    private void Attack()
    {
        attackTimer -= Time.deltaTime;
        if (attackTimer > 0f)
        {
            return;
        }
        attackTimer = timeToAttack;
        Collider2D[] targets = Physics2D.OverlapBoxAll(transform.position, attackSize, 0f);

        for (int i = 0; i < targets.Length; i++)
        {
            Damageable player = targets[i].GetComponent<Damageable>();

            if (player != null)
            {
                player.TakeDamage(damage);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, attackSize);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(initialPosition, roamingRange);
    }
}
