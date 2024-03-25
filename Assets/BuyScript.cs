using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class BuyScript : MonoBehaviour
{
    [SerializeField]BuyObjectSpawn point;
    public GameObject BuyObject;
    public int Price;

    void Start()
    {
        point = FindFirstObjectByType<BuyObjectSpawn>();
    }

    public void OnBuy()
    {
        Player itemToUpdate = Serialization.connection.Table<Player>().FirstOrDefault();
        if (BuyObject && itemToUpdate.money >= Price)
        {
            itemToUpdate.money -= Price;
            Money.num = itemToUpdate.money;
            point.Spawn(BuyObject);
            Serialization.connection.Update(itemToUpdate);
        }
    }
}
