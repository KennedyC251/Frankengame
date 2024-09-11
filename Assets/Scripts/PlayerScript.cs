using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    private float rotation;
    float speedX, speedZ;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        speedX = Input.GetAxisRaw("Horizontal") * speed;
        speedZ = Input.GetAxisRaw("Vertical") * speed;
        rb.velocity = new Vector3(speedX, -3f, speedZ);
        transform.rotation = Quaternion.Euler(0, rotation, 0);
    }
}
