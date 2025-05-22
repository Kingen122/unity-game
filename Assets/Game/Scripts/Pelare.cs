using UnityEngine;

public class Pelare: MonoBehaviour
{
    [SerializeField] private float moveDistance = 5f; 
    [SerializeField] private float speed = 2f; 
    private Vector3 startPosition; 

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        
        float newZ = startPosition.z + (-Mathf.Sin(Time.time * speed)) * moveDistance;
        transform.position = new Vector3(startPosition.x, startPosition.y, newZ);
    }
}