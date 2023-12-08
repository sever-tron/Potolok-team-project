using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Application.LoadLevel("Locations");
    }

    public void LoadGame()
    {
        
    }

    public void Settings()
    {
        Application.LoadLevel("Settings");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
