using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEnab : MonoBehaviour
{
    [SerializeField] GameObject game;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Stone.Take)
            {
                TopDownCharacterController.MoveAgr = false;
                game.SetActive(true);
            }
        }
    }
}
