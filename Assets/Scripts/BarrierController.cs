using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierController : MonoBehaviour
{
    private bool isTriggered = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        lock (this)
        {
            if (!isTriggered)
            {
                isTriggered = true;
                GameObject.Destroy(gameObject);
                if (collider.gameObject.name == "Player")
                {
                    collider.gameObject.GetComponent<PlayerController>().Damage();
                }
            }
        }
    }
}
