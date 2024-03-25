using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    private GameObject[] RandomTarget;
    private List<int> RanNum = new List<int>();
    public GameObject[] MonsterSpawn;
    public int CountMon = 5;
    public int MaxMon = 6;

    //—генерировать n поинта
    //—генерировать n монстра

    void Start()
    {
        RandomTarget = GameObject.FindGameObjectsWithTag("RandomPoint");
        int nPoint;
        int mCount;

        for (int i = 0; i < CountMon; i++)
        {
            nPoint = Random.Range(0, RandomTarget.Length - 1);
            mCount = Random.Range(0, MonsterSpawn.Length - 1);

            if (!IsNumberInArray(RanNum, nPoint))
            {
                RanNum.Add(nPoint);
                Instantiate(MonsterSpawn[mCount], RandomTarget[nPoint].transform.position, Quaternion.identity);
            } else
            {
                i--;
            }
        }
        
    }

    private bool IsNumberInArray(List<int> array, int number)
    {
        if (array != null)
        {
            foreach (int element in array)
            {
                if (element == number)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
