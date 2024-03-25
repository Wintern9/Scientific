using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetAttack : MonoBehaviour
{
    public GameObject object0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        MonsterCollider scriptAComponent = object0.GetComponent<MonsterCollider>();
        if (collision.CompareTag("Player"))
        {
            scriptAComponent.playerInsideCollider = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        MonsterCollider scriptAComponent = object0.GetComponent<MonsterCollider>();
        if (collision.CompareTag("Player"))
        {
            scriptAComponent.playerInsideCollider = false;
        }
    }
}