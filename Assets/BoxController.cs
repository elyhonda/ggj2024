using UnityEngine;

public class BoxController : MonoBehaviour
{
    public float moveSpeed = 10f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        Vector2 movement = new Vector2(horizontalInput, 0f) * moveSpeed * Time.deltaTime;

        // Adicione uma condição para verificar se a caixa está no chão antes de mover
        if (IsGrounded())
        {
            rb.MovePosition(rb.position + movement);
        }
    }

    bool IsGrounded()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.1f);

        foreach (Collider2D collider in colliders)
        {
            if (collider != null && collider.CompareTag("Ground"))
            {
                // Adicione uma verificação para garantir que a caixa está acima do chão
                float overlapThreshold = 0.1f; // Ajuste conforme necessário
                if (transform.position.y > collider.bounds.max.y - overlapThreshold)
                {
                    return true;
                }
            }
        }

        return false;
    }
}
