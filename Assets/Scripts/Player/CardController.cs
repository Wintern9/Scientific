using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    public GameObject Circ1;
    public GameObject Circ2;
    public GameObject Circ3;

    public bool isMouse = false;

    public int nus = 0;

    public void Change(int num)
    {
        if(num == 1) {
            Circ1.SetActive(true);
            Circ2.SetActive(false);
            Circ3.SetActive(false);
        } if(num == 2) {
            Circ1.SetActive(false);
            Circ2.SetActive(true);
            Circ3.SetActive(false);
        } if (num == 3)
        {
            Circ1.SetActive(false);
            Circ2.SetActive(false);
            Circ3.SetActive(true);
        }
    }

    public void numChange(int num)
    {
        nus = num;
        isMouse = true;
        
    }
}
