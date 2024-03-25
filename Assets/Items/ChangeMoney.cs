using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeMoney : Money
{
    TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        if (nM > 0)
            text.text = "+" + (nM).ToString();
        else
            text.text = (nM).ToString();
    }
}
