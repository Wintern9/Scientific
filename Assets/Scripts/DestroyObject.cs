using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stone : MonoBehaviour
{
    static public bool Take = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Take = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Take = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && StoneProjectile.speed == 0 && gameObject.tag == "Stone" && !(SceneManager.GetActiveScene().name == "Lobby" || SceneManager.GetActiveScene().name == "LobbyS"))
        {
            if (Take)
            {
                Debug.Log("Вызов 1");
                Items itemToUpdate = Serialization.connection.Table<Items>().FirstOrDefault(item => item.Sprite == 0);

                if (itemToUpdate != null && itemToUpdate.Id <= Serialization.connection.Table<Player>().FirstOrDefault().inventOpen)
                {
                    Debug.Log(itemToUpdate.Id + " < " + Serialization.connection.Table<Player>().FirstOrDefault().inventOpen);
                    Shooting.SetActive = true;

                    itemToUpdate.Sprite = 1;
                    itemToUpdate.tag = "Stone";
                    itemToUpdate.attack = 10;
                    itemToUpdate.oblast = 1;

                    Serialization.connection.Update(itemToUpdate);

                    Backpack backpack = FindFirstObjectByType<Backpack>();
                    Serialization mainCon = FindFirstObjectByType<Serialization>();
                    mainCon.LoadItems();
                    backpack.SetImages();

                    mainCon.UploItems();

                    Destroy(gameObject); // Уничтожаем объект "Stone" при соприкосновении с игроком
                    GameObject[] objectW = GameObject.FindGameObjectsWithTag("Weapon");
                    Shooting.SetActive = true;
                    Shooting.ShootingActive = true;
                    StoneProjectile.speed = 5f;
                }
                Take = false;
            }
        }


        if (SceneManager.GetActiveScene().name == "Lobby" || SceneManager.GetActiveScene().name == "LobbyS")
        {
            if (collision.CompareTag("Player") && gameObject.tag == "Stone")
            {
                Debug.Log("Вызов 2");
                if (Take)
                {
                    Items itemToUpdate = Serialization.connection.Table<Items>().FirstOrDefault(item => item.Sprite == 0);

                    if (itemToUpdate != null && itemToUpdate.Id <= Serialization.connection.Table<Player>().FirstOrDefault().inventOpen)
                    {
                        Debug.Log(itemToUpdate.Id + " < " + Serialization.connection.Table<Player>().FirstOrDefault().inventOpen);

                        Debug.Log("Cl2");
                        gameObject.SetActive(false); // Уничтожаем объект "Stone" при соприкосновении с игроком
                        GameObject[] objectW = GameObject.FindGameObjectsWithTag("Weapon");
                        Shooting.SetActive = true;

                        itemToUpdate.Sprite = 1;
                        itemToUpdate.tag = "Stone";
                        itemToUpdate.attack = 10;
                        itemToUpdate.oblast = 1;

                        Serialization.connection.Update(itemToUpdate);

                        Backpack backpack = FindFirstObjectByType<Backpack>();
                        Serialization mainCon = FindFirstObjectByType<Serialization>();
                        mainCon.LoadItems();
                        backpack.SetImages();


                        mainCon.UploItems();
                    }
                    Take = false;
                }
                }
            }

        void UpdateItem(int spriteId, string itemTag)
        {
            if (Take)
            {
                Items itemToUpdate = Serialization.connection.Table<Items>().FirstOrDefault(item => item.Sprite == 0);

                if (itemToUpdate != null && itemToUpdate.Id <= Serialization.connection.Table<Player>().FirstOrDefault().inventOpen)
                {
                    Debug.Log(itemToUpdate.Id + " < " + Serialization.connection.Table<Player>().FirstOrDefault().inventOpen);

                    Debug.Log("Cl2");
                    gameObject.SetActive(false); // Уничтожаем объект при соприкосновении с игроком
                    GameObject[] objectW = GameObject.FindGameObjectsWithTag("Weapon");
                    Shooting.SetActive = true;

                    itemToUpdate.Sprite = spriteId;
                    itemToUpdate.tag = itemTag;
                    itemToUpdate.attack = 0;
                    itemToUpdate.oblast = 0;

                    Serialization.connection.Update(itemToUpdate);

                    Backpack backpack = FindFirstObjectByType<Backpack>();
                    Serialization mainCon = FindFirstObjectByType<Serialization>();
                    mainCon.LoadItems();
                    backpack.SetImages();

                    mainCon.UploItems();
                }
                Take = false;
            }
        }

        // Использование метода для каждого случая
        if (collision.CompareTag("Player") && gameObject.tag == "Banka")
        {
            UpdateItem(2, "Banka");
        }

        if (collision.CompareTag("Player") && gameObject.tag == "Konserva")
        {
            UpdateItem(3, "Konserva");
        }

        if (collision.CompareTag("Player") && gameObject.tag == "LuckyBox")
        {
            UpdateItem(4, "LuckyBox");
        }

        if (collision.CompareTag("Player") && gameObject.tag == "Unicorn")
        {
            UpdateItem(5, "Unicorn");
        }

        if (collision.CompareTag("Player") && gameObject.tag == "Bag")
        {
            if (Take)
            {
                Debug.Log("Вызов 1");
                Player itemToUpdate = Serialization.connection.Table<Player>().FirstOrDefault();
                itemToUpdate.inventOpen = 4;

                Serialization.connection.Update(itemToUpdate);

                Backpack backpack = FindFirstObjectByType<Backpack>();
                backpack.VisibleBag();

                Take = false;
                Destroy(gameObject);
            }
        }

        if (collision.CompareTag("Player") && gameObject.tag == "Flashlight")
        {
            if (Take)
            {
                Debug.Log("Вызов 1");
                Player itemToUpdate = Serialization.connection.Table<Player>().FirstOrDefault();
                itemToUpdate.light = 1;

                Serialization.connection.Update(itemToUpdate);

                Take = false;
                Destroy(gameObject);
            }
        }
    }
}
