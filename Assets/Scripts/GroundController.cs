using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    private GameObject grass;

    private float speed = 0.2F;

    private Vector2 moveDirection = new Vector2(-1.0F, 0.0F);

    private int groundLength = 100;

    private Vector3 posDelta = new Vector3(5.0F, 0.0F, 0.0F);

    // Start is called before the first frame update
    void Start()
    {
        grass = GameObject.Find("Grass");
        for (int i = 0; i < groundLength; i++)
        {
            grass = Instantiate(grass, grass.transform.position + posDelta, grass.transform.rotation, transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection * speed);
    }
}
