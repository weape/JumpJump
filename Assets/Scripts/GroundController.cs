using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroundController : MonoBehaviour
{
    public GameObject grass;

    public GameObject chest;

    public static long distance = 0;

    private AudioSource audio;

    private PlayerController playerController;

    private Vector2 minSpeed = new Vector2(-7.0F, 0.0F);

    private Vector2 energySpeedFactor = new Vector2(-0.3F, 0.0F);

    private int groundLength = 75;

    private Vector3 posDelta = new Vector3(5.0F, 0.0F, 0.0F);

    // Start is called before the first frame update
    void Start()
    {
        grass = Instantiate(grass, transform);
        for (int i = 0; i < groundLength; i++)
        {
            grass = Instantiate(grass, grass.transform.position + posDelta, grass.transform.rotation, transform);
        }

        chest = Instantiate(chest, grass.transform.position + new Vector3(0.0F, 2.0F, 0.0F), grass.transform.rotation, transform);

        // Choose level.
        switch (PlayerPrefs.GetFloat("Level", 1.0F))
        {
            case 1.0F:
                SetTemplates(20, "Templates/Level1");
                break;
            case 2.0F:
                SetTemplates(20, "Templates/Level2");
                break;
            case 3.0F:
                SetTemplates(20, "Templates/Level3");
                break;
            default:
                SetTemplates(20, "Templates/Level1");
                break;
        }

        audio = gameObject.GetComponent<AudioSource>();
        audio.volume = PlayerPrefs.GetFloat("Volume", 0.0F) / 100.0F;
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 totalSpeed = minSpeed + energySpeedFactor * playerController.GetEnergy();
        transform.Translate(totalSpeed * Time.deltaTime);
        distance -= (int)(totalSpeed * Time.deltaTime).x;
    }

    /**
     * Set game templates into scene.
     */
    private void SetTemplates(int templateCount, string templateDir)
    {
        // load all game templates
        Object[] Templates = Resources.LoadAll(templateDir);

        // calculate some constants
        float extInterval = (float)groundLength / (float)templateCount;
        float maxPosition = grass.transform.position.x - grass.GetComponent<BoxCollider2D>().size.x;

        GameObject preTemplate, template;
        System.Random rand = new System.Random();

        preTemplate = (GameObject)Instantiate(
            Templates[rand.Next(0, Templates.Length)], new Vector3(rand.Next(10, 20), -3.0F, 0.0F), 
            transform.rotation, transform
        );

        for (int i = 1; i < templateCount; i++)
        {
            template = (GameObject)Templates[rand.Next(0, Templates.Length)]; // choose one template by random
            float interval = preTemplate.GetComponent<BoxCollider2D>().size.x + extInterval;
            Vector3 position = preTemplate.transform.position + new Vector3(interval, 0.0F, 0.0F);
            if (position.x + template.GetComponent<BoxCollider2D>().size.x < maxPosition)
                preTemplate = Instantiate(template, position, transform.rotation, transform);
            else
                break;
        }
    }
}
