using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private int health;

    private int energy;

    private Texture2D blankImage;

    private Texture2D healthImage;

    private Texture2D energyImage;

    private Rigidbody2D rb;

    private Vector2 force = new Vector2(0.0F, 1.0F) * 700.0F;

    private bool isOnGround = false;

    private bool isJumpPressed = false;

    private bool isHighJumpPressed = false;

    private float lastTime = 0.0F;

    private Text scoreText;

    public int GetHealth()
    {
        return health;
    }

    public int GetEnergy()
    {
        return energy;
    }

    public void Damage()
    {
        health--;
        if (health <= 0)
        {
            Application.LoadLevel("GameEnd");
        }
    }

    public void Recharge()
    {
        energy += 2;
        if (energy > 10)
        {
            energy = 10;
        }
        lastTime = Time.time;
    }

    // Start is called before the first frame update
    void Start()
    {
        health = 10; energy = 10;
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 4;
        rb.freezeRotation = true; // avoid rotation while collising
        blankImage = Resources.Load<Texture2D>("Blank");
        healthImage = Resources.Load<Texture2D>("Health");
        energyImage = Resources.Load<Texture2D>("Energy");
        scoreText = GameObject.Find("Score").GetComponent<Text>();
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
        isJumpPressed = isJumpPressed || Input.GetKeyDown(KeyCode.Space);
        isHighJumpPressed = isHighJumpPressed || Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift);
        DecreaseEnergy();
        scoreText.text = ((long)((-GameObject.Find("Grass(Clone)").transform.position.x) * 100)).ToString();
    }

    void FixedUpdate()
    {
        if (isOnGround && isJumpPressed)
        {
            if (isHighJumpPressed)
            {
                rb.AddForce(force * 1.5F);
                isHighJumpPressed = false;
            }
            else
            {
                rb.AddForce(force);
            }
            isJumpPressed = false;
            isOnGround = false;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        isOnGround = true;
    }

    void DecreaseEnergy()
    {
        if (lastTime == 0.0F)
        {
            lastTime = Time.time;
        }
        else if (Time.time - lastTime >= 5)
        {
            if (energy > 5 && health < 10)
            {
                health++;
            }
            if (energy > 0)
            {
                energy--;
            }
            lastTime = Time.time;
        }
    }
}
