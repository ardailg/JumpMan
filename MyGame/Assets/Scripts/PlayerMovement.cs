using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rgb;
    Vector3 velocity;
    public float speedAmount;
    void Start()
    {
        rgb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        velocity = new Vector3(Input.GetAxis("Horizontal"), 0f);
        transform.position += velocity * speedAmount * Time.deltaTime;
    }
}
