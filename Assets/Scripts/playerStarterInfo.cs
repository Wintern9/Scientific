using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStarterInfo : MonoBehaviour
{
    public GameObject InfoObject;
    public GameObject DilerWindow;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Stone.Take = false;
        if (collision.CompareTag("Player"))
        {
            if (InfoObject != null)
            {
                InfoObject.SetActive(true);
            }
        }
    }

    public Collider2D collision0;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (InfoObject != null)
            {
                InfoObject.SetActive(false);
            }
            if (DilerWindow != null)
            {
                DilerWindow.SetActive(false);
                gameObject.GetComponent<CanvasChanger>().ClickBack();
            }
        }
        collision0 = null;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        collision0 = collision;
    }

    private void Update()
    {
        if (collision0 != null)
        {
            if (collision0.CompareTag("Player") && DilerWindow != null)
            {
                if (Stone.Take)
                {
                    if (DilerWindow != null)
                    {
                        TopDownCharacterController.MoveAgr = false;
                        DilerWindow.SetActive(true);
                        gameObject.GetComponent<CanvasChanger>().Click();
                    }
                    Stone.Take = false;
                }
            }
        }
    }
}
