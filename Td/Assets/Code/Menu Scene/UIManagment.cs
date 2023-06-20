using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
public class UIManagment : MonoBehaviour
{
    public int level;
   public void GoToLevelSelection()
    {
        SceneManager.LoadScene("LevelSelection");
    }
    public void GoOut()
    {
        Application.Quit();
    }
    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }
    public void GoToPlay()
    {
        SceneManager.LoadScene("Level " + level.ToString());
    }
    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
