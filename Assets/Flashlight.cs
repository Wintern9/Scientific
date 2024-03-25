using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    void Start()
    {
        Invoke("StartLate", 0.1f);
    }

    public void StartLate()
    {
        Player itemToUpdate = Serialization.connection.Table<Player>().FirstOrDefault();
        if (itemToUpdate.light == 1)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
