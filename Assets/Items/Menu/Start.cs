using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start : MonoBehaviour
{
    public GameObject gameObj;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObj.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        gameObj.SetActive(false);
    }
}
