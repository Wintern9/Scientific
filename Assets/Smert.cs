using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class Smert : MonoBehaviour
{
    public bool Infinity = false;

    private string databaseName = "Save.db";

    public GameObject objecto;

    private void OnDisable()
    {
        if (!Infinity && TopDownCharacterController.hp <= 0)
        {

            InsertFirstData();
        }
        objecto.SetActive(true);
    }

    private void InsertFirstData()
    {
        Debug.Log("FirstStart");
        //Serialization.connection.DeleteAll<Player>();
        //Serialization.connection.DeleteAll<Items>();

        //Serialization.connection.Insert(new Player { DoscaOpen = 0, inventOpen = 2, hp = 1, FPSValue = 1, MusicValue = 0.5, money = 0 });

        Player itemToUpdate = Serialization.connection.Table<Player>().FirstOrDefault();

        itemToUpdate.hp = 1;
        itemToUpdate.DoscaOpen = 0;
        itemToUpdate.light = 0;
        itemToUpdate.inventOpen = 2;
        itemToUpdate.money = itemToUpdate.money * 9 / 10;
        TopDownCharacterController.hp = 1;

        Serialization.connection.Update(itemToUpdate);

        Serialization.connection.DeleteAll<Items>();

        for (int i = 0; i < 8; i++)
        {
            Serialization.connection.Insert(new Items { Id = i+1, Sprite = 0, tag = null, attack = 0, oblast = 0 });
        }
        //Serialization.connection.Update(items);
    }
}
