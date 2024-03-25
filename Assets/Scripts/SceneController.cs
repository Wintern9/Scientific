using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void ChangeScene(string Name)
    {
        Debug.Log(Name);
        if (Name == "Зачистка")
        {

            SceneManager.LoadScene("LevelTypeA-1");
            
        }

        else if (Name == "Лобби")
        {

            SceneManager.LoadScene("LobbyS");
            
        } else
        {
            SceneManager.LoadScene("LevelTypeA-1");
        }
    }

    public GameObject LevelComp;

    MonsterCount monsterCount;
    RandomSpawn randomSpawn;

    public void Start()
    {
        monsterCount = GameObject.FindGameObjectWithTag("MonsterCount").GetComponent<MonsterCount>();
        randomSpawn = GameObject.FindGameObjectWithTag("LevelController").GetComponent<RandomSpawn>();
    }

    private void Update()
    {
        if(monsterCount.MonDeath == randomSpawn.CountMon)
        {
            LevelComplete();
        }
    }

    public void LevelComplete()
    {
        
        LevelComp.SetActive(true);
    }
}
