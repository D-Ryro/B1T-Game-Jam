using UnityEngine;

public class GhostController : MonoBehaviour
{
    [SerializeField] private BaseGhost ghostData;
    private HealthSystem health;
    private Rigidbody2D rb;
    private float lastAttackTime;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        health = GetComponent<HealthSystem>();
        GameManager.Instance.activeGhosts.Add(this);
    }

    void Update()
    {
        ChaseNearestKuker();
    }

    void ChaseNearestKuker()
    {
        if (GameManager.Instance.activeKukers.Count == 0) return;

        Transform target = GameManager.Instance.activeKukers[0].transform;
        rb.linearVelocity = (target.position - transform.position).normalized * ghostData.speed;

        if (Vector2.Distance(transform.position, target.position) < 1.5f &&
            Time.time > lastAttackTime + ghostData.attackCooldown)
        {
            Attack(target);
        }
    }

    void Attack(Transform target)
    {
        target.GetComponent<HealthSystem>().TakeDamage(ghostData.damage);
        lastAttackTime = Time.time;
    }

    void OnDestroy()
    {
        GameManager.Instance.activeGhosts.Remove(this);
        GameManager.Instance.GhostKilled();
    }
}