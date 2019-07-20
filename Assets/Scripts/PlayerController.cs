using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int health;

    private int energy;

    private Texture2D blankImage;

    private Texture2D healthImage;

    private Texture2D energyImage;

    private Rigidbody2D rb;

    private Vector2 force = new Vector2(0.0F, 1.0F) * 350.0F;

    private bool isOnGround = false;

    public void Damage()
    {
        health--;
    }

    // Start is called before the first frame update
    void Start()
    {
        health = 10; energy = 10;
        rb = GetComponent<Rigidbody2D>();
        blankImage = Resources.Load<Texture2D>("Blank");
        healthImage = Resources.Load<Texture2D>("Health");
        energyImage = Resources.Load<Texture2D>("Energy");
    }

    void OnGUI()
    {
        for (int i = 0; i < health; i++)
        {
            GUI.DrawTexture(new Rect(10 + i * 11, 10, 10, 20), healthImage);
        }

        for (int i = 9; i >= health; i--)
        {
            GUI.DrawTexture(new Rect(10 + i * 11, 10, 10, 20), blankImage);
        }

        for (int i = 0; i < energy; i++)
        {
            GUI.DrawTexture(new Rect(10 + i * 11, 40, 10, 20), energyImage);
        }

        for (int i = 9; i >= energy; i--)
        {
            GUI.DrawTexture(new Rect(10 + i * 11, 40, 10, 20), blankImage);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (isOnGround && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(force);
            isOnGround = false;
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        isOnGround = true;
    }
}
