using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject canvasPause;
    public GameObject canvasPauseDis;
    public void Pauses()
    {
        Time.timeScale = 0f;
        if(canvasPause != null )
            canvasPause.SetActive(true);
        canvasPauseDis.SetActive(false);
    }

    public void NoPauses()
    {
        Time.timeScale = 1f;
        if (canvasPause != null)
            canvasPause.SetActive(false);
        canvasPauseDis.SetActive(true);
    }
}
