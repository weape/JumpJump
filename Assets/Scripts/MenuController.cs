using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public void OnBackClicked()
    {
        Application.LoadLevel("Menu");
    }

    public void OnPlayClicked()
    {
        Application.LoadLevel("Game");
    }

    public void OnQuitClicked()
    {
        Application.Quit();
    }

    public void OnRankingClicked()
    {
        Application.LoadLevel("Rank");
    }
}
