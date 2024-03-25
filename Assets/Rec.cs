using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rec : MonoBehaviour
{
    double i = 0;

    AudioSource audio;
    public AudioClip[] resource;

    public int fore;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    bool joi = false;
    bool joi2 = false;

    void Update()
    {
        if (fore == 0)
        {
            Player itemToUpdate = Serialization.connection.Table<Player>().FirstOrDefault();
            if (itemToUpdate.SEValue != i)
            {
                i = itemToUpdate.SEValue;
                audio.volume = (float)i;
            }
            Debug.Log(i);
        } 
            else if( fore == 1)
        {
            Player itemToUpdate = Serialization.connection.Table<Player>().FirstOrDefault();
            if (itemToUpdate.SEValue != i)
            {
                i = itemToUpdate.SEValue;
                audio.volume = (float)i;
            }

            if(TopDownCharacterController.movee == true && !TopDownCharacterController.rune)
            {
                //audio.resource = resource[0];

                audio.volume = (float)i;
            } else
            {
                audio.volume = 0;
            }
        }

        else if (fore == 2)
        {
            Player itemToUpdate = Serialization.connection.Table<Player>().FirstOrDefault();
            if (itemToUpdate.SEValue != i)
            {
                i = itemToUpdate.SEValue;
                audio.volume = (float)i;
            }

            if (TopDownCharacterController.rune)
            {
                //audio.resource = resource[0];

                audio.volume = (float)i;
            }
            else
            {
                audio.volume = 0;
            }
        }
    }
}
