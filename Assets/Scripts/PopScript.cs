using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PopScript : MonoBehaviour
{
    public float minForce = 1f;       // Minimum force applied to the cube
    public float maxForce = 5f;      // Maximum force applied to the cube
    public float waitTime = 2f;       // Time to wait before popping again
    public float life = 3;
    private Rigidbody rb;             // Reference to the Rigidbody component
    private bool isWaiting = true;   // Flag to check if the cube is waiting to pop

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isWaiting)
            return;

        // Check if the cube has nearly stopped moving
        if (rb.velocity.magnitude < 0.1f)
        {
            isWaiting = true;
            Invoke("Pop", waitTime); // Wait for a few seconds before popping again
        }
    }

    void Pop()
    {
        // Apply a random force to the cube to make it "pop"
        Vector3 randomDirection = new Vector3(
            Random.Range(-5f, 5f),
            5f,
            Random.Range(-5f, 5f)
        ).normalized;

        float randomForce = Random.Range(minForce, maxForce);
        rb.AddForce(randomDirection * randomForce, ForceMode.Impulse);

        isWaiting = false;
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Player")
        {
            Destroy(col.gameObject);
        }
    }
    private void Awake()
    {
        Destroy(gameObject, life);
    }
}
