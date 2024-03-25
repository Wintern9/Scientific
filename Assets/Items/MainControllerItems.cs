using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class MainControllerItems : MonoBehaviour
{
    public List<Items> inventory;
    public List<Items> chest;
    public List<ItemsLobby> Lobby;
    public List<GameObject> LobbyItem;

    public List<Sprite> Sprites;

    private static MainControllerItems instance;

    public Sprite[] CardNum;

    public GameObject[] ObjectMass;
    public GameObject[] LuckyMassive;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // Если уже есть другой MusicManager, уничтожаем этот
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Сохраняем объект при смене сцены
        }
    }

    public void StartLate()
    {
        MouseHover[] mouseHover = FindObjectsOfType<MouseHover>();
        foreach(var mouse in mouseHover)
        {
            mouse.sprites = CardNum;
        }

        bool of = false;
        foreach(Items item in inventory)
        {
            if(item.tag == "Stone")
            {
                of = true;
            }
        }
        Debug.Log(of);
        if ((SceneManager.GetActiveScene().name == "Lobby" || SceneManager.GetActiveScene().name == "LobbyS"))
        {
            if (LobbyItem[0] == null)
            {
                LobbyItem[0] = GameObject.FindGameObjectWithTag("Stone");
            }
            if (Lobby != null)
            {
                Debug.Log(Lobby.Count);
                for (int i = 0; i < Lobby.Count; i++)
                {
                    if (!of && Lobby[i].Delete == 0)
                    {
                        continue;
                    }
                    LobbyItem[Lobby[i].Delete].SetActive(false);

                }
            }
        }
        if (inventory != null)
        {
            BackpackIn();
        }
    }

    Backpack backpack;

    private void BackpackIn()
    {
        backpack = FindFirstObjectByType<Backpack>();
        backpack.inventSet = inventory;

    }//Инвентарь загрузка

    public void ObjDisable(int num)
    {
            if (!Serialization.connection.Table<ItemsLobby>().Any(item => item.Delete == num))
                Serialization.connection.Insert(new ItemsLobby { Delete = num });
    }
}
