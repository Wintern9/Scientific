using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Money : MonoBehaviour
{
    TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();

        text.text = (num).ToString();
    }

    static public int num;

    public GameObject point;
    public GameObject textChan;

    public int nM;

    // Update is called once per frame
    void Update()
    {
        Player itemToUpdate = Serialization.connection.Table<Player>().FirstOrDefault();
        if (num != itemToUpdate.money) {
            nM = itemToUpdate.money - num;
            Instantiate(textChan, point.transform);
            text.text = (itemToUpdate.money).ToString();
            num = itemToUpdate.money;
        }
        text.text = num.ToString();
    }
}
