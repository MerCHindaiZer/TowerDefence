using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManagment : MonoBehaviour
{
   public void GoToGame()
    {
        SceneManager.LoadScene("GamePlay");
    }
    public void GoOut()
    {
        Application.Quit();
    }
}
