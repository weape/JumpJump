using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float force = 350.0F;

    private Vector2 forceDirection = new Vector2(0.0F, 1.0F);

    private bool isOnGround = false;

    private Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
        if (isOnGround && Input.GetKeyDown(KeyCode.Space)) {
            rigidbody.AddForce(forceDirection * force);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.tag == "Ground") {
            isOnGround = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision) {
        if (collision.collider.tag == "Ground") {
            isOnGround = false;
        }
    }
}
