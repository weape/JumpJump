using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawController : MonoBehaviour
{
    private Vector2 speed = new Vector2(8.5F, 0.0F);

    private Vector3 rotation = new Vector3(0.0F, 0.0F, -360.0F);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotation * Time.deltaTime, Space.Self);
        transform.Translate(speed * Time.deltaTime, Space.World);
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.gameObject.name == "Player")
        {
            Application.LoadLevel("GameEnd");
        }
    }
}
