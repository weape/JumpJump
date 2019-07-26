using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using System;

public class GameEndController : MonoBehaviour
{

    private Text Score;
    private Text Rank;

    private Text Hint;
    // Start is called before the first frame update
    void Start()
    {
        Score = GameObject.Find("Score").GetComponent<Text>();
        Rank = GameObject.Find("Rank").GetComponent<Text>();
        Hint = GameObject.Find("Hint").GetComponent<Text>();

        if (PlayerController.hasPassed)
        {
            PlayerController.score += 50000;
        }

        string record = PlayerPrefs.GetString("Score", "{}");
        JSONNode Nodes = JSON.Parse(record);
        Nodes["Score"][-1].AsFloat = PlayerController.score;
        float[] floatArray = new float[Nodes["Score"].AsArray.Count];
        for (int i = 0; i < Nodes["Score"].AsArray.Count; i++)
        {
            floatArray[i] = Nodes["Score"][i].AsFloat;
        }
        Array.Sort(floatArray);
        Array.Reverse(floatArray);
        for (int i = 0; i < Nodes["Score"].AsArray.Count; i++)
        {
            Nodes["Score"][i] = floatArray[i];
            if (Math.Abs(floatArray[i] - PlayerController.score) < 0.00001)
            {
                Rank.text = (i + 1).ToString();
            }
        }
        PlayerPrefs.SetString("Score", Nodes.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        Score.text = PlayerController.score.ToString();
        if (PlayerController.hasPassed)
            Hint.text = "Congratulations!";
        else
            Hint.text = "Game Over!";
    }
}
