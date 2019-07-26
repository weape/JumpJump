using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;

public class RankController : MonoBehaviour
{
    private Text ScoreTitle, RankTitle;
    // Start is called before the first frame update
    void Start()
    {
        // PlayerPrefs.SetString("Score", "{}"); // clear all records
        RankTitle = GameObject.Find("RankTitle").GetComponent<Text>();
        ScoreTitle = GameObject.Find("ScoreTitle").GetComponent<Text>();
        string record = PlayerPrefs.GetString("Score", "{}");
        JSONNode Nodes = JSON.Parse(record);
        GameObject newRank = GameObject.Find("RankTitle");
        GameObject newScore = GameObject.Find("ScoreTitle");
        for (int i = 0; i < Nodes["Score"].AsArray.Count; i++)
        {
            Vector3 pos = new Vector3(0.0F, -LayoutUtility.GetPreferredHeight((RectTransform)RankTitle.transform) / 2, 0.0F);
            newRank = Instantiate(newRank, newRank.transform.position + pos, newRank.transform.rotation, newRank.transform);
            newRank.GetComponent<Text>().text = "   " + (i + 1).ToString();
            newRank.transform.parent = transform;
            newScore = Instantiate(newScore, newScore.transform.position + pos, newScore.transform.rotation, newScore.transform);
            newScore.GetComponent<Text>().text = "                       " + (Nodes["Score"][i]).ToString();
            newScore.transform.parent = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
