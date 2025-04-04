using UnityEngine;

public class KukerController : MonoBehaviour
{
    [SerializeField] private BaseKuker kukerData;
    private HealthSystem health;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        health = GetComponent<HealthSystem>();
        GameManager.Instance.activeKukers.Add(this);
    }

    void Update()
    {
        HandleMovement();
        if (Input.GetKeyDown(KeyCode.Space)) Attack();
    }

    void HandleMovement()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.linearVelocity = moveInput.normalized * kukerData.speed;
    }

    public void MoveToPosition(Vector2 targetPosition)
    {
        transform.position = targetPosition;
    }

    public void Attack()
    {
        // Implement sound wave attack
    }

    void OnDestroy()
    {
        GameManager.Instance.activeKukers.Remove(this);
    }
}
