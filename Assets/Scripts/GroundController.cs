using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    public GameObject grass;

    public GameObject spike;

    public GameObject monster;

    private PlayerController playerController;

    private float speed = 5F;

    private Vector2 moveDirection = new Vector2(-1.0F, 0.0F);

    private Vector2 energySpeedFactor = new Vector2(-0.5F, 0.0F);

    private int spikeCount = 30;

    private int groundLength = 100;

    private Vector3 posDelta = new Vector3(5.0F, 0.0F, 0.0F);

    // Start is called before the first frame update
    void Start()
    {
        grass = Instantiate(grass, transform);
        for (int i = 0; i < groundLength; i++)
        {
            grass = Instantiate(grass, grass.transform.position + posDelta, grass.transform.rotation, transform);
        }

        spike = Instantiate(spike, transform);
        for (int i = 0; i < spikeCount; i++)
        {
            spike = Instantiate(spike, spike.transform.position + posDelta * 2, spike.transform.rotation, transform);
        }

        // monster = Instantiate(monster, transform);
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 totalSpeed = moveDirection * speed + energySpeedFactor * playerController.GetEnergy();
        transform.Translate(totalSpeed * Time.deltaTime);
    }
}
