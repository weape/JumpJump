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
        string record = PlayerPrefs.GetString("Score", "{}");
        JSONNode Nodes = JSON.Parse(record);
        Nodes["Score"][-1].AsFloat = PlayerController.score;
        float[] floatArray = new float[Nodes["Score"].AsArray.Count];
        int i = 0;
        foreach (JSONNode item in Nodes["Score"])
        {
            floatArray[i] = item.AsFloat;
            i++;
        }
        Array.Sort(floatArray);
        Array.Reverse(floatArray);
        i = 0;
        foreach (float item in floatArray)
        {
            Nodes["Score"][i] = item;
            if (Math.Abs(item - PlayerController.score) < 0.001)
            {
                Rank.text = (i + 1).ToString();
                break;
            }
            i++;
        }
        PlayerPrefs.SetString("Score", Nodes.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        Score.text = PlayerController.score.ToString();
    }
}
