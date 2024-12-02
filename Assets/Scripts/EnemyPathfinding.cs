using UnityEngine;

public class EnemyPathfinding : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;

    private Rigidbody2D rb;
    private Vector2 moveDir;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        rb.MovePosition(rb.position + moveDir * (moveSpeed * Time.fixedDeltaTime)); // Bergerak ke arah moveDir
    }

    public void MoveTo(Vector2 targetPosition) {
        moveDir = (targetPosition - rb.position).normalized; // Hitung arah normalisasi ke target
    }
}
