using System.Collections.Generic;
using System.IO;
using UnityEngine;
using SQLite4Unity3d;
using System.Linq;
using System;
using UnityEngine.SceneManagement;

public class Serialization : MonoBehaviour
{
    [SerializeField] public Items[] inventSet;
    public List<Items> itemsList = new List<Items>();

    static public SQLiteConnection connection;
    private string databaseName = "Save.db";

    private void Start()
    {
        StartUpload();
    }

    public void StartUpload()
    {
        string dbPath = Path.Combine(Application.persistentDataPath, databaseName);
        bool FilePath = File.Exists(dbPath);
        connection = new SQLiteConnection(dbPath);
        Debug.Log(dbPath);

        if (!(SceneManager.GetActiveScene().name == "MenuS"))
        {
            Backpack backpack = FindFirstObjectByType<Backpack>();

            if (backpack != null)
            {
                backpack.LateStart();
            }
        }

        // Создаем таблицу, если ее нет
        if (!FilePath)   
        {
            connection.CreateTable<Player>();
            connection.CreateTable<Items>();
            connection.CreateTable<ItemsLobby>();

            InsertFirstData();
        }

        //Debug.Log("БД");

        // Выводим данные
        List<Player> players = connection.Table<Player>().ToList();

        if (players[0].FPSValue == 0)
        {
            Application.targetFrameRate = 120;
        }
        else if (players[0].FPSValue == 1)
        {
            Application.targetFrameRate = 60;
        }
        else if (players[0].FPSValue == 2)
        {
            Application.targetFrameRate = 30;
        }

        Debug.Log(players[0].FPSValue + " ddd " + (float)players[0].MusicValue);

        FPSChanger.value = players[0].FPSValue;
        MusicChanger.Volume = (float)players[0].SEValue;
        MusicChanger.Volume2 = (float)players[0].MusicValue;

        TopDownCharacterController.hp = players[0].hp;

        DoscaSc doscaSc = FindFirstObjectByType<DoscaSc>();

        //Debug.Log(players[0].DoscaOpen);
        if ((SceneManager.GetActiveScene().name == "Lobby" || SceneManager.GetActiveScene().name == "LobbyS"))
        {
            if (players[0].DoscaOpen != 0)
            {
                doscaSc.bol = true;
            }
            else { doscaSc.bol = false; }
            doscaSc.LateStart();
        }
        LoadItems();

        Backpack.BollS = true;
    }

    private void InsertFirstData()
    {
        Debug.Log("FirstStart");
        connection.DeleteAll<Player>();
        connection.DeleteAll<Items>();

        connection.Insert(new Player { DoscaOpen = 0, inventOpen = 2, light = 0, hp = 1, FPSValue = 1, MusicValue = 0.5, SEValue = 0.5, money = 0});

        for (int i = 0; i < 8; i++)
        {
            connection.Insert(new Items { Id = i+1,Sprite = 0, tag = null, attack = 0, oblast = 0 });
        }
    }

    private void OnDestroy()
    {
        connection?.Close();
    }

    public void LoadItems()
    {
        MainControllerItems mainController = FindFirstObjectByType<MainControllerItems>();
        List<Items> items = connection.Table<Items>().ToList();
        List<ItemsLobby> itemsLobby = connection.Table<ItemsLobby>().ToList();
        //Debug.Log(items.Count + "lIST");

        mainController.inventory = new List<Items>(items);
        
        foreach (var item in mainController.inventory)
        {
            Debug.Log($"Num: {item.Num}, Id: {item.Id}, Sprite: {item.Sprite}, Tag: {item.tag}, Attack: {item.attack}, Oblast: {item.oblast}");
        }

        mainController.Lobby = new List<ItemsLobby>(itemsLobby);

        mainController.StartLate();
    }

    public void UploItems()
    {
        MainControllerItems mainController = FindFirstObjectByType<MainControllerItems>();
        List<Items> items = new (connection.Table<Items>().ToList());

        Debug.Log(items.Count + "lIST");

        mainController.inventory = new List<Items>(items);
        Backpack.BollS = true;
        mainController.StartLate();
    }
}
