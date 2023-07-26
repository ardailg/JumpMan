using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rgb;
    Vector3 velocity;

    public float moveSpeed;
    public float jumpAmount;
    public float gravityMultiplier; // Yerçekimi kuvvetini artırmak için çarpan

    private bool isGrounded = false; // Yere temas kontrolü
    private bool canDoubleJump = false; // Çift zıplama izni
    private int jumpCount = 0; // Zıplama sayacı

    public bool canMove = true;

    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (canMove)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            velocity = new Vector3(horizontalInput, 0f);
            transform.position += velocity * moveSpeed * Time.deltaTime;

            // Yere temas kontrolü
            if (Mathf.Approximately(rgb.velocity.y, 0))
            {
                isGrounded = true;
                jumpCount = 0; // Yere temas varsa zıplama sayacını sıfırla
            }
            else
            {
                isGrounded = false;
            }

            // Zıplama kontrolü
            if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
            {
                if (isGrounded) // Yere temas varsa
                {
                    // Yere temas varken zıplama
                    rgb.AddForce(Vector3.up * jumpAmount, ForceMode2D.Impulse);
                    canDoubleJump = true; // Çift zıplama izni aç
                }
                else if (canDoubleJump && jumpCount < 1) // Havadayken çift zıplama
                {
                    rgb.velocity = new Vector2(rgb.velocity.x, 0f); // Yatay hızı korumak için y eksenini sıfırladı
                    rgb.AddForce(Vector3.up * jumpAmount, ForceMode2D.Impulse);
                    jumpCount++; // Zıplama sayacını artır
                    if (jumpCount >= 1)
                    {
                        canDoubleJump = false; // Çift zıplama'yı kapatıyorum
                    }
                }
            }

            // Yerçekimi kuvvetini artırarak daha hızlı düşme
            rgb.AddForce(Vector3.down * Physics2D.gravity.y * gravityMultiplier * Time.deltaTime);
        }
        else
        {
            // Stop the player's movement and jumping
            rgb.velocity = Vector2.zero;
        }
    }
}
