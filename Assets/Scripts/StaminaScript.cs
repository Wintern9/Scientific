using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaScript : MonoBehaviour
{
    private float values = 1;
    static public float valuesInfo = 1;
    private float StaminaValue = 2f;
    private Slider slider;

    static public bool Jumping = false;

    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = values;
    }

    void Update()
    {
        if (TopDownCharacterController.StaminaBool == true)
        {
            slider.value -= Time.deltaTime / StaminaValue;
        } else
        {
            slider.value += Time.deltaTime / (StaminaValue * StaminaValue);
        }
        valuesInfo = slider.value;

        if (Jumping)
        {
            Jump();
            Jumping = false;
        }
    }

    private void Jump()
    {
        //Debug.Log("Jump");
        slider.value -= 0.4f;
    }
}
