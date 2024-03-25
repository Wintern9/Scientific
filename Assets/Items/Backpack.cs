using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Backpack : MonoBehaviour
{
    private bool bagopen = false;
    public GameObject objects;

    public List<Items> inventSet;
    public Items SetObject;
    public GameObject[] inventory;
    public GameObject[] OpInv;

    private GameObject Weapon;

    public TagInfo[] tags; 

    public void LateStart()
    {
        VisibleBag();
        bagopen = true;
        inventory = GameObject.FindGameObjectsWithTag("Inventory");
        Weapon = GameObject.FindGameObjectWithTag("WeaponPoint");

        

        for (int i = 0; i < inventory.Length; i++)
        {
            Button button = inventory[i].GetComponent<Button>();
            if (button != null)
            {
                int index = i;
                button.onClick.AddListener(() => OnButtonClick(index));
            }
        }
    }

    public void OnButtonClick(int buttonIndex)
    {
        inventoryIndex = buttonIndex;

        // Проверка, чтобы избежать выхода за границы массива
        if (inventoryIndex < inventory.Length)
        {
            spr = inventory[inventoryIndex].GetComponent<Image>().sprite;
            Weapon.GetComponent<SpriteRenderer>().sprite = spr;
            jie = true;
        }
    }

    public void VisibleBag()
    {
        Player itemToUpdate = Serialization.connection.Table<Player>().FirstOrDefault();
        for (int n = 0; n < itemToUpdate.inventOpen; n++)
        {
            OpInv[n].SetActive(true);
        }
    }

    public void OnPointerDown(PointerEventData eventData){}

    static public bool BollS = true;

    static public int inventoryIndex = 10;

    public Sprite spr;

    bool jie = false;

    void LateUpdate()
    {
        if (jie)
        {
            if (spr != inventory[inventoryIndex].GetComponent<Image>().sprite)
            {
                spr = inventory[inventoryIndex].GetComponent<Image>().sprite;
            }
        }

        Serialization.connection.Table<Items>().FirstOrDefault(item => item.Id == inventoryIndex);

        if (Input.GetKeyDown(KeyCode.I)) {
            bagopen = !bagopen;
        }

        if (bagopen)
        {
            objects.SetActive(true);
        } else
        {
            objects.SetActive(false);
        }
  
        if (BollS)
        {
            SetImages();
            BollS = false;
        }

        if (inventSet != null)
        {
            SetObject = inventSet[0];
        }
    }

    public void SetImages()
    {
        MainControllerItems mainControllerItems = FindFirstObjectByType<MainControllerItems>();
        int i = 0;
        foreach (GameObject inv in inventory) {
            inv.SetActive(true);

            if (i > inventSet.Count - 1)
            {
                inv.SetActive(false);
                continue;
            }

            if (inventSet[i].Sprite != 0)
            {
                Debug.Log(inventSet[i].Sprite - 1);
                inv.GetComponent<Image>().sprite = mainControllerItems.Sprites[inventSet[i].Sprite - 1];
                TagInfo tagInfo = tags[i];
                tagInfo.Tag = inventSet[i].tag;
                Weapon.GetComponent<SpriteRenderer>().sprite = spr;

            }
            else
            {
                inv.SetActive(false);
                TagInfo tagInfo = tags[i];
                tagInfo.Tag = "";
            }
            i++;
        }
    }
}
