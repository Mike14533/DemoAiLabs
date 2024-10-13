using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int startSceneID;
    

    public void StartGame() {
        //Load the Scene with the Start Scene ID
        SceneManager.LoadScene(startSceneID);
    }

     public void QuitGame() {
        //Load the Scene with the Start Scene ID
        Application.Quit();
    }
}
