using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartScript : MonoBehaviour
{
    public Sprite[] heartsType;

    public int heartCount;
    public int LastHeartCount;

    SpriteRenderer spriteRenderer;

    public GameObject[] MiniH;

    public int AniState;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (heartCount == 3)
        {
            spriteRenderer.sprite = heartsType[0];
        } else if (heartCount == 2)
        {
            spriteRenderer.sprite = heartsType[1];
        } else if(heartCount == 1)
        {
            spriteRenderer.sprite = heartsType[2];
        }
        else
        {
            spriteRenderer.sprite = null;
            this.gameObject.SetActive(false);
        }
        LastHeartCount = heartCount;
    }

    void Update()
    {
        if (LastHeartCount != heartCount)
        {
            int LHC = LastHeartCount - heartCount;

            Debug.Log(LHC + " - " + AniState);

            if (LHC != 3)
            {
                int firstIndex = AniState == 0 ? 0 : (AniState == 1 ? 1 : 2);

                for (int i = 0; i < Mathf.Min(LHC, 3); i++)
                {
                    Debug.Log("RCL"[firstIndex + i].ToString());
                    MiniH[firstIndex + i].SetActive(true);
                }
            }
            else
            {
                Debug.Log("full");
                MiniH[0].SetActive(true);
                MiniH[1].SetActive(true);
                MiniH[2].SetActive(true);
            }

            LastHeartCount = heartCount;
        }


        if (spriteRenderer.sprite != null)
        {
            if (heartCount == 3)
            {
                spriteRenderer.sprite = heartsType[0];
                AniState = 0;
            }
            else if (heartCount == 2)
            {
                spriteRenderer.sprite = heartsType[1];
                AniState = 1;
            }
            else if (heartCount == 1)
            {
                spriteRenderer.sprite = heartsType[2];
                AniState = 2;
            }
            else if (heartCount == 0)
            {
                spriteRenderer.sprite = heartsType[3];
                AniState = 3;
            }
        }
    }
}
