using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject weapon;
    static public bool SetActive = false;

    private Animator animator;

    static public int weaponID = 0; //0 - камень


    static public bool ShootingActive = true;
    public bool LuckyTime = false;
    public bool ShootActive = true;

    private Backpack activitiObject;

    private void Start()
    {
        animator = GetComponent<Animator>();
        ShootingActive = true;
        activitiObject = FindFirstObjectByType<Backpack>();
    }

    public Vector2 direction;

    public bool input = false;

    float angle;

    void Update()
    {
        
        if (Backpack.inventoryIndex == 10)
        {
            ShootingActive = false;
        }
        else if (activitiObject.tags[Backpack.inventoryIndex].Tag == "Stone")
        {
            ShootingActive = true;
        }
        else
        {
            ShootingActive = false;
        }

        if (Backpack.inventoryIndex == 10)
        {
            LuckyTime = false;
        }
        else if (activitiObject.tags[Backpack.inventoryIndex].Tag == "LuckyBox")
        {
            LuckyTime = true;
        }
        else
        {
            LuckyTime = false;
        }

        if (SceneManager.GetActiveScene().name == "Lobby" || SceneManager.GetActiveScene().name == "LobbyS")
        {
            ShootingActive = false;
        }


        // ќпределение направлени€ от позиции персонажа к позиции касани€
        if (Input.touchCount != 0)
        {
            //Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            //Vector2 direction = (Vector2)(touchPosition - transform.position);

            // Ќормализаци€ вектора направлени€ дл€ получени€ единичного вектора
            //direction.Normalize();

            // –асчет угла в радианах от вектора направлени€
            
            if (direction != Vector2.zero)
            {
                angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            }
            Debug.Log("Angle"+angle);

            // ”становка угла вращени€ персонажа
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

            // —трельба при касании экрана
            if (input && ShootingActive)
            {
                Debug.Log("Fire");
                Shoot(angle);
            }
            
            if (input && LuckyTime)
            {
                RandomBox();
            }
        }

        if (SetActive == true)
        {
            SetActive = false;
        }
    }


    void Shoot(float angle)
    {
        if(angle < 0)
        {
            if (TopDownCharacterController.horizontalInput > 0)
                animator.Play("Attack");
            else
                animator.Play("Attack0");
        } else
        {
            if (TopDownCharacterController.horizontalInput > 0)
                animator.Play("Attack");
            else
                animator.Play("Attack0");
        }

        Instantiate(bulletPrefab, new Vector3(firePoint.position.x, firePoint.position.y, 0), transform.rotation);

        activitiObject.tags[Backpack.inventoryIndex].Tag = "";

        if (weapon != null)
        {
            weapon.GetComponent<SpriteRenderer>().sprite = null;
        }

        if(weaponID == 0)
        {
            ShootingActive = false;
        }

        Items itemToUpdate = Serialization.connection.Table<Items>().FirstOrDefault(item => item.Id == Backpack.inventoryIndex+1);

        if (itemToUpdate != null)
        {
            itemToUpdate.Sprite = 0;
            itemToUpdate.tag = null;
            itemToUpdate.attack = 0;
            itemToUpdate.oblast = 0;

            Serialization.connection.Update(itemToUpdate);
            
            Serialization mainCon = FindFirstObjectByType<Serialization>();

            activitiObject.inventory[Backpack.inventoryIndex].GetComponent<Image>().sprite = null;

            mainCon.UploItems();
        }
        else
        {
            Debug.LogError("Item with Id " + 1 + " not found.");
        }


    }

    public void RandomBox()
    {
        int m = FindFirstObjectByType<MainControllerItems>().LuckyMassive.Length;
        int num;
        if (m > 0)
        {
            num = Random.Range(0, m-1); 
            
            if (Backpack.inventoryIndex < 9)
            {
                Items itemToUpdate = Serialization.connection.Table<Items>().FirstOrDefault(item => item.Id == Backpack.inventoryIndex + 1);

                if (itemToUpdate.tag != null)
                {
                    Instantiate(FindFirstObjectByType<MainControllerItems>().LuckyMassive[num], new Vector3(firePoint.position.x, firePoint.position.y, 0), Quaternion.identity);

                    activitiObject.tags[Backpack.inventoryIndex].Tag = "";


                    weapon.GetComponent<SpriteRenderer>().sprite = null;


                    if (itemToUpdate != null)
                    {
                        Items DroppenItem = new Items { Sprite = itemToUpdate.Sprite, tag = itemToUpdate.tag, attack = itemToUpdate.attack, oblast = itemToUpdate.oblast };
                        itemToUpdate.Sprite = 0;
                        itemToUpdate.tag = null;
                        itemToUpdate.attack = 0;
                        itemToUpdate.oblast = 0;

                        Serialization.connection.Update(itemToUpdate);

                        Serialization mainCon = FindFirstObjectByType<Serialization>();

                        activitiObject.inventory[Backpack.inventoryIndex].GetComponent<Image>().sprite = null;

                        mainCon.UploItems();
                    }
                }
            }
        }

       
    }

    public void DropCurrentItem()
    {
        if (Backpack.inventoryIndex < 9)
        {
            Items itemToUpdate = Serialization.connection.Table<Items>().FirstOrDefault(item => item.Id == Backpack.inventoryIndex + 1);

            if (itemToUpdate.tag != null)
            {
                Instantiate(FindFirstObjectByType<MainControllerItems>().ObjectMass.FirstOrDefault(item => item.GetComponent<TagInfo>().Tag == itemToUpdate.tag), new Vector3(firePoint.position.x, firePoint.position.y, 0), Quaternion.identity);

                activitiObject.tags[Backpack.inventoryIndex].Tag = "";


                weapon.GetComponent<SpriteRenderer>().sprite = null;


                if (itemToUpdate != null)
                {
                    Items DroppenItem = new Items { Sprite = itemToUpdate.Sprite, tag = itemToUpdate.tag, attack = itemToUpdate.attack, oblast = itemToUpdate.oblast };
                    itemToUpdate.Sprite = 0;
                    itemToUpdate.tag = null;
                    itemToUpdate.attack = 0;
                    itemToUpdate.oblast = 0;

                    Serialization.connection.Update(itemToUpdate);

                    Serialization mainCon = FindFirstObjectByType<Serialization>();

                    activitiObject.inventory[Backpack.inventoryIndex].GetComponent<Image>().sprite = null;

                    mainCon.UploItems();
                }
            }
        }
    }
}
