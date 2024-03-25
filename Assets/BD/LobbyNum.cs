using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyNum : MonoBehaviour
{
    public int num;

    private void Start()
    {
        
    }


    private void OnDisable()
    {
        MainControllerItems mainController = FindFirstObjectByType<MainControllerItems>();
        if (mainController != null)
            mainController.ObjDisable(num); //при выключении добавить этот объект в лист и записать в БД
        Debug.Log("Dis");
    }
}
