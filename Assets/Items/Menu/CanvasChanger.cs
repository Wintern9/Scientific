using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasChanger : MonoBehaviour
{
    public GameObject g1;
    public GameObject g2;
    public void Click()
    {
        if (g1 != null)
            g1.SetActive(false);
        if(g2 != null)
            g2.SetActive(true);
    }

    public void ClickBack()
    {
        if (g2 != null)
            g2.SetActive(false);
        if (g1 != null)
            g1.SetActive(true);
    }

    public string nameScene;

    public void SceneLoad()
    {
        SceneManager.LoadScene(nameScene);
    }

    public void SceneExit()
    {
        SceneManager.LoadScene(nameScene);
        Time.timeScale = 1f;
    }

    public GameObject game;

    public void Obj()
    {
        game.SetActive(true);
    }
}
