using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    public GameObject grass;

    public GameObject spike;

    public GameObject chest;

    public GameObject energyCoin;

    private PlayerController playerController;

    private Vector2 minSpeed = new Vector2(-7.0F, 0.0F);

    private Vector2 energySpeedFactor = new Vector2(-0.3F, 0.0F);

    private int spikeCount = 100;

    private int groundLength = 200;

    private int energyCoinCount = 40;

    private Vector3 posDelta = new Vector3(5.0F, 0.0F, 0.0F);

    // Start is called before the first frame update
    void Start()
    {
        System.Random rand = new System.Random();
        grass = Instantiate(grass, transform);
        for (int i = 0; i < groundLength; i++)
        {
            grass = Instantiate(grass, grass.transform.position + posDelta, grass.transform.rotation, transform);
        }

        chest = Instantiate(chest, grass.transform.position + new Vector3(0.0F, 2.0F, 0.0F), grass.transform.rotation, transform);

        
        spike = Instantiate(spike, transform);
        for (int i = 0; i < spikeCount; i++)
        {
            Vector3 pos = new Vector3(rand.Next(10, 20), 0.0F, 0.0F);
            spike = Instantiate(spike, spike.transform.position + pos, spike.transform.rotation, transform);
        }

        energyCoin = Instantiate(energyCoin, new Vector3(rand.Next(50, 100), 2.0F, 0.0F), transform.rotation, transform);
        for (int i = 0; i < energyCoinCount; i++)
        {
            Vector3 pos = new Vector3(rand.Next(30, 60), 0.0F, 0.0F);
            energyCoin  = Instantiate(energyCoin, energyCoin.transform.position + pos, transform.rotation, transform);
        }


        // monster = Instantiate(monster, transform);
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 totalSpeed = minSpeed + energySpeedFactor * playerController.GetEnergy();
        transform.Translate(totalSpeed * Time.deltaTime);
    }
}
