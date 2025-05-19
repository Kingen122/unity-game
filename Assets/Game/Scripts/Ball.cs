using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform ballStartPosition;
    [SerializeField] private Transform TransformBallPosition;
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private float shootForce = 10f;
    [SerializeField] private float minHeight = -1f;
    private bool isStickingToPlayer = false;
    private Rigidbody rb;

    public bool IsStickingToPlayer => isStickingToPlayer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isStickingToPlayer)
        {
            transform.position = TransformBallPosition.position;
        }
        else
        {
            transform.position = ballStartPosition.position;

            float distanceToPlayer = Vector3.Distance(playerTransform.position, transform.position);
            if (distanceToPlayer < 0.5f)
            {
                isStickingToPlayer = true;
            }
        }

        if (transform.position.y < minHeight)
        {
            Respawn();
        }
    }

    public void Shoot(Vector3 direction)
    {
        isStickingToPlayer = false;
        rb.AddForce(direction * shootForce, ForceMode.Impulse);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goal") || other.CompareTag("BottomBarrier"))
        {
            Respawn();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayArea"))
        {
            Respawn();
        }
    }

    void Respawn()
    {
        transform.position = respawnPoint.position;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        isStickingToPlayer = false;
    }
}