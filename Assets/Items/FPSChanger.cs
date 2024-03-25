using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class FPSChanger : MonoBehaviour
{
    static public TMP_Dropdown dropdown;

    static public int value;
    
    void LateStart()
    {
        dropdown = GetComponent<TMP_Dropdown>();
        dropdown.value = value;
        Debug.Log(dropdown.value + " + " + value);
    }

    bool on = true;

    void Update()
    {
        if (on)
        {
            LateStart();
            on = false;
        }
        if (value != dropdown.value)
        {
            if (dropdown.value == 0)
            {
                Player itemToUpdate = Serialization.connection.Table<Player>().FirstOrDefault();
                Application.targetFrameRate = 120;
                if (itemToUpdate != null)
                {
                    itemToUpdate.FPSValue = 0;
                    Serialization.connection.Update(itemToUpdate);
                }
                else
                {
                    Debug.LogError("Item with Id " + 1 + " not found.");
                }
            }
            if (dropdown.value == 1)
            {
                Player itemToUpdate = Serialization.connection.Table<Player>().FirstOrDefault();
                Application.targetFrameRate = 60;
                if (itemToUpdate != null)
                {
                    itemToUpdate.FPSValue = 1;
                    Serialization.connection.Update(itemToUpdate);
                }
                else
                {
                    Debug.LogError("Item with Id " + 1 + " not found.");
                }
            }
            if (dropdown.value == 2)
            {
                Application.targetFrameRate = 30;
                Player itemToUpdate = Serialization.connection.Table<Player>().FirstOrDefault();

                if (itemToUpdate != null)
                {
                    itemToUpdate.FPSValue = 2;
                    Serialization.connection.Update(itemToUpdate);
                }
                else
                {
                    Debug.LogError("Item with Id " + 1 + " not found.");
                }
            }
            value = dropdown.value;
        }
    }
}
