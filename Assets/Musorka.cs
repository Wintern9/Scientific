using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Musorka : MonoBehaviour
{
    public Transform Prefab;
    public Transform Prefab2;
    public GameObject[] GameObjects;
    public GameObject GameObjectMessenge;

    float Times = 0f;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Stone.Take)
            {
                if (Times < 0)
                {
                    Debug.Log("Musor");
                    int z = Random.Range(0, 10);
                    if (z == 1)
                    {
                        int i = Random.Range(0, GameObjects.Length);
                        //Instantiate(GameObjects[i], m_Prefab.transform);
                        Instantiate(GameObjects[i], new Vector3(Prefab.position.x, Prefab.position.y, 0), Quaternion.identity);
                        Debug.Log("Musor Create");
                    } else
                    {
                        Instantiate(GameObjectMessenge, Prefab2);
                    }
                    Times = 0f;
                }
                Debug.Log("Musor" + Times);
                Stone.Take = false;
            }
        }
    }

    private void Update()
    {
        Times -= Time.deltaTime;

        Debug.Log(Stone.Take + "Boool");
    }
}
