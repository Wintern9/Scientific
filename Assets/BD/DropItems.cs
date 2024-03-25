using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DropItem : MonoBehaviour
{
    private Backpack backpack;
    private Shooting shooting;

    static public bool drop = false;

    void Start()
    {
        backpack = gameObject.GetComponent<Backpack>();
        shooting = FindFirstObjectByType<Shooting>();
    }

    void Update()
    {
        if (drop)
        {
            Debug.Log("Q - Click");
            shooting.DropCurrentItem();
        }

        drop = false;
    }
    //Реализован в shooting
}
