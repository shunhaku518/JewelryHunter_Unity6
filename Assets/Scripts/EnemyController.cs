using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("�܂�Ԃ�")]
    public GameObject sencer;

    [Header("��{�ݒ�")]
    public float speed = 1.0f;
    public bool isRight;

    Rigidbody2D rbody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();

        if (isRight)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isRight)
        {
            rbody.linearVelocity = new Vector2(speed, rbody.linearVelocity.y);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            rbody.linearVelocity = new Vector2(-speed, rbody.linearVelocity.y);
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Ground"))
        {
            isRight = !isRight;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isRight = !isRight;
        }
    }
}
