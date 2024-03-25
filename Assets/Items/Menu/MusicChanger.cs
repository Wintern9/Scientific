using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MusicChanger : MonoBehaviour
{
    Slider slider;

    static public float Volume; //se
    static public float Volume2; //music

    public int ik;

    void LateStart()
    {
        slider = GetComponent<Slider>();
        slider.value = Volume2;
    }

    void LateStart2()
    {
        slider = GetComponent<Slider>();
        slider.value = Volume;
    }

    bool on = true;

    void Update()
    {
        if (ik == 0)
        {
            if (on)
            {
                LateStart();
                on = false;
            }
            if (Volume2 != slider.value)
            {
                Player itemToUpdate = Serialization.connection.Table<Player>().FirstOrDefault();
                itemToUpdate.MusicValue = slider.value;
                Serialization.connection.Update(itemToUpdate);
                Volume2 = slider.value;
            }
        } else if (ik == 1)
        {
            if (on)
            {
                LateStart2();
                on = false;
            }
            if (Volume != slider.value)
            {
                Player itemToUpdate = Serialization.connection.Table<Player>().FirstOrDefault();
                itemToUpdate.SEValue = slider.value;
                Serialization.connection.Update(itemToUpdate);
                Volume = slider.value;
            }
        }
    }
}
