using System;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    public GameObject objectToDestroy;
    public Animator Death;
    public GameObject[] objs;
    public Collider2D BoxCollider;

    public int hp = 10;

    private void OnDisable()
    {
        if (objectToDestroy != null)
        {
            try
            {
                MonsterCount monsterCount = GameObject.FindGameObjectsWithTag("MonsterCount")[0].GetComponent<MonsterCount>();
                RandomSpawn randomSpawn = GameObject.FindGameObjectsWithTag("LevelController")[0].GetComponent<RandomSpawn>();
                if (monsterCount.MonDeath < randomSpawn.CountMon)
                {
                    monsterCount.MonDeath++;
                }

                Player mon = Serialization.connection.Table<Player>().FirstOrDefault();
                mon.money += UnityEngine.Random.Range(0, 3);
                Serialization.connection.Update(mon);
            }
            catch (IndexOutOfRangeException e)
            {
                Debug.Log($"Произошло исключение IndexOutOfRangeException: {e.Message}, такое бывает");
            }
            
            MonsterRun monsterRun = objectToDestroy.GetComponent<MonsterRun>();
            Death.Play("Death");
            monsterRun.OnDeath = true;
           // Destroy(objectToDestroy);
        }
        BoxCollider.enabled = false;
        foreach (GameObject obj in objs)
        {
            obj.SetActive(false);
        }
    }
}
