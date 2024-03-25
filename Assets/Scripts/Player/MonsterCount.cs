using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MonsterCount : MonoBehaviour
{
    private TextMeshProUGUI textMeshProUI;
    private GameObject[] LevelController;

    public int MonDeath = 0;

    void Start()
    {
        textMeshProUI = GetComponent<TextMeshProUGUI>();
        LevelController = GameObject.FindGameObjectsWithTag("LevelController");
        RandomSpawn randomSpawn = LevelController[0].GetComponent<RandomSpawn>();
        randomSpawn.CountMon = Random.Range(3, randomSpawn.MaxMon);
    }

    void Update()
    {
        LevelController = GameObject.FindGameObjectsWithTag("LevelController");
        RandomSpawn randomSpawn = LevelController[0].GetComponent<RandomSpawn>();

        if (textMeshProUI != null)
        {
            textMeshProUI.text = MonDeath + "/" + randomSpawn.CountMon;
        }
    }
}
