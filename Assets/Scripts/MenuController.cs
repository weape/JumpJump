using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    private Slider Level;
    private Text LevelValue;

    private Slider Volume;
    private Text VolumeValue;

    public void OnBackClicked()
    {
        Application.LoadLevel("Menu");
    }

    public void OnPlayClicked()
    {
        Application.LoadLevel("Game");
    }

    public void OnNextLevelClicked()
    {
        float level = PlayerPrefs.GetFloat("Level", 1.0F);
        if (level < 3.0F)
        {
            level++;
        }
        PlayerPrefs.SetFloat("Level", level);
        OnPlayClicked();
    }

    public void OnQuitClicked()
    {
        Application.Quit();
    }

    public void OnRankingClicked()
    {
        Application.LoadLevel("Rank");
    }

    public void OnLevelValueChanged()
    {
        LevelValue.text = Level.value.ToString();
        PlayerPrefs.SetFloat("Level", Level.value);
    }

    public void OnVolumeValueChanged()
    {
        VolumeValue.text = Volume.value.ToString();
        PlayerPrefs.SetFloat("Volume", Volume.value);
    }

    private void Start()
    {
        if (GameObject.Find("Level") != null)
        {
            Level = GameObject.Find("Level").GetComponent<Slider>();
            LevelValue = GameObject.Find("LevelValue").GetComponent<Text>();
            Level.value = PlayerPrefs.GetFloat("Level", 1.0F);
            LevelValue.text = Level.value.ToString();

            Volume = GameObject.Find("Volume").GetComponent<Slider>();
            VolumeValue = GameObject.Find("VolumeValue").GetComponent<Text>();
            Volume.value = PlayerPrefs.GetFloat("Volume", 0.0F);
            VolumeValue.text = Volume.value.ToString();
        }
    }
}
