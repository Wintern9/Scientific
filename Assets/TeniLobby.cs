using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class TeniLobby : MonoBehaviour
{
    SpriteRenderer sprite;
    static public bool TeniBool = false;
    Color currentColor;
    float reducedAlpha;
    void StartLate()
    {
        if (!TeniBool)
        {
            gameObject.SetActive(true);
        }

        sprite = GetComponent<SpriteRenderer>();
        currentColor = sprite.color;
        reducedAlpha = currentColor.a;
    }

    IEnumerator StartLateCoroutine()
    {
        yield return null; // Ждем один кадр
        StartLate();
    } //Запуск через кадр

    void Start()
    {
        StartCoroutine(StartLateCoroutine());
    } 

    void Update()
    {
        if (TeniBool) {
            reducedAlpha /= 1.1f;
            sprite.color = new Color(currentColor.r, currentColor.g, currentColor.b, reducedAlpha);
        }
        if (reducedAlpha < 1f)
        {
            gameObject.SetActive (false);
        }
    }
}
