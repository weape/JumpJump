using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    public GameObject grass;

    public GameObject chest;

    public static long distance = 0;

    private PlayerController playerController;

    private Vector2 minSpeed = new Vector2(-7.0F, 0.0F);

    private Vector2 energySpeedFactor = new Vector2(-0.3F, 0.0F);

    private int groundLength = 75;

    private int templateCount = 20;

    private Vector3 posDelta = new Vector3(5.0F, 0.0F, 0.0F);

    // Start is called before the first frame update
    void Start()
    {
        float totalTemplateLength = 15;
        System.Random rand = new System.Random();
        // load all game templates
        Object[] Templates = Resources.LoadAll("template");

        grass = Instantiate(grass, transform);
        for (int i = 0; i < groundLength; i++)
        {
            grass = Instantiate(grass, grass.transform.position + posDelta, grass.transform.rotation, transform);
        }

        chest = Instantiate(chest, grass.transform.position + new Vector3(0.0F, 2.0F, 0.0F), grass.transform.rotation, transform);

        // set game template into scene
        GameObject preTemplate, template;
        preTemplate = (GameObject)Instantiate(Templates[rand.Next(0, Templates.Length)], new Vector3(rand.Next(10, 30), -3.0F, 0.0F), transform.rotation, transform);
        for (int i = 0; i < templateCount - 1; i++)
        {
            Vector3 pos = new Vector3(preTemplate.GetComponent<BoxCollider2D>().size.x, 0.0F, 0.0F);
            totalTemplateLength += preTemplate.GetComponent<BoxCollider2D>().size.x;
            template = (GameObject)Templates[rand.Next(0, Templates.Length)]; // choose one template by random
            if (totalTemplateLength + template.GetComponent<BoxCollider2D>().size.x < grass.transform.position.x)
                preTemplate = Instantiate(template, preTemplate.transform.position + pos, transform.rotation, transform);
            else
                break;
        }

        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 totalSpeed = minSpeed + energySpeedFactor * playerController.GetEnergy();
        transform.Translate(totalSpeed * Time.deltaTime);
        distance -= (int)(totalSpeed * Time.deltaTime).x;
    }
}
