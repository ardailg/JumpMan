using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rgb;
    Vector3 velocity;
    
    public float speedAmount;
    public float jumpAmount;

    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        velocity = new Vector3(Input.GetAxis("Horizontal"), 0f);
        transform.position += velocity * speedAmount * Time.deltaTime;

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && Mathf.Approximately(rgb.velocity.y, 0))
        { //Mathf fonksiyonuyla karakterin yere düşmeden tekrar zıplaması engellendi, yere temas ettikten sonra zıplayabiliyor
            rgb.AddForce(Vector3.up * jumpAmount, ForceMode2D.Impulse);
        }
    }
}
