using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public void OnBackCLicked()
    {
        Application.LoadScene("Menu");
    }

    public void OnPlayClicked()
    {
        Application.LoadScene("Game");
    }

    public void OnQuitClicked()
    {
        Application.Quit();
    }
}
