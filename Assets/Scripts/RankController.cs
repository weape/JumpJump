using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;

public class RankController : MonoBehaviour
{
    private Text ScoreTitle, RankTitle;

    private Slider Level;
    private Text LevelValue;

    private Queue Texts = new Queue();
    // Start is called before the first frame update
    void Start()
    {
        // PlayerPrefs.SetString("Score", "{}"); // clear all records
        GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0); // place the content object to the correct position
        RankTitle = GameObject.Find("RankTitle").GetComponent<Text>();
        ScoreTitle = GameObject.Find("ScoreTitle").GetComponent<Text>();
        LevelValue = GameObject.Find("LevelValue").GetComponent<Text>();
        Level = GameObject.Find("Level").GetComponent<Slider>();
        int level = (int)Level.value;
        LevelValue.text = level.ToString();
        DisplayScore(level);
    }

    void DisplayScore(int level)
    {
        int count = Texts.Count;
        for (int i = 0; i < count; i++)
        {
            Destroy((GameObject)Texts.Dequeue());
        }
        string record = PlayerPrefs.GetString("Score" + level, "{}");
        JSONNode Nodes = JSON.Parse(record);
        GameObject newRank = GameObject.Find("RankTitle");
        GameObject newScore = GameObject.Find("ScoreTitle");
        for (int i = 0; i < Nodes["Score"].AsArray.Count; i++)
        {
            Vector3 pos = new Vector3(0.0F, -LayoutUtility.GetPreferredHeight((RectTransform)RankTitle.transform) / 2, 0.0F);
            newRank = Instantiate(newRank, newRank.transform.position + pos, newRank.transform.rotation, transform);
            newRank.GetComponent<Text>().text = "   " + (i + 1).ToString();
            // newRank.transform.parent = transform;
            Texts.Enqueue(newRank);
            newScore = Instantiate(newScore, newScore.transform.position + pos, newScore.transform.rotation, transform);
            newScore.GetComponent<Text>().text = "                       " + (Nodes["Score"][i]).ToString();
            // newScore.transform.parent = transform;
            Texts.Enqueue(newScore);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnLevelValueChanged()
    {
        int level = (int)Level.value;
        LevelValue.text = level.ToString();
        DisplayScore(level);
    }
}
