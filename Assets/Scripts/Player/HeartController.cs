using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartController : MonoBehaviour
{
    [SerializeField] private int n;
    HeartScript[] heartScripts;

    void Start()
    {
        heartScripts = GetComponentsInChildren<HeartScript>();
        n = TopDownCharacterController.hp;
        foreach (HeartScript heart in heartScripts)
        {
            int s;
            if (n - 3 >= 0)
            {
                s = 3;
                n -= 3;
            }
            else if (n - 2 >= 0)
            {
                s = 2;
                n -= 2;
            }
            else if (n - 1 >= 0)
            {
                s = 1;
                n -= 1;
            }
            else
            {
                s = 0;
            }
            heart.heartCount = s;
        }
        n = TopDownCharacterController.hp;
    }

    private void Update()
    {
        if (TopDownCharacterController.hp < n)
        {
            foreach (HeartScript heart in heartScripts)
            {
                if (TopDownCharacterController.hp > 0)
                {
                    int s;
                    if (n - 3 > 0)
                    {
                        s = 3;
                        n -= 3;
                    }
                    else if (n - 2 > 0)
                    {
                        s = 2;
                        n -= 2;
                    }
                    else if (n - 1 > 0)
                    {
                        s = 1;
                        n -= 1;
                    }
                    else
                    {
                        s = 0;
                    }
                    //Debug.Log(s);
                    heart.heartCount = s;
                } else
                {
                    heart.heartCount = 0;
                }
            }
            n = TopDownCharacterController.hp;
        }
    }
}
