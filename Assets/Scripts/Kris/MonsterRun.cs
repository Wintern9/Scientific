using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MonsterRun : MonoBehaviour
{
    public float moveSpeed = 5f;
    public bool Running = false;
    public Transform player;
    public GameObject[] Player;
    private Transform transform;
    private Vector3 Scale = new Vector3();

    public bool OnDeath = false;

    public Animator Death;

    private void Start()
    {
        Death = GetComponent<Animator>();
        Player = GameObject.FindGameObjectsWithTag("Player");
        player = Player[0].transform;
        transform = GetComponent<Transform>();
        Scale = GetComponent<Transform>().localScale;

            SpriteRenderer renderer = GetComponent<SpriteRenderer>();

            // Создаем новый цвет (белый)
            Color newColor = Color.white;

            // Устанавливаем цвет объекта
            renderer.material.color = newColor;

    }

    void Update()
    {
        if (Running && !OnDeath)
            {
                // Найдем направление к игроку
                Vector3 directionToPlayer = (player.position - transform.position).normalized;
                if(directionToPlayer.x < 0)
                {
                    Scale.x = -1.0f;
                    transform.localScale = Scale;
                } else
                {
                    Scale.x = 1.0f;
                    transform.localScale = Scale;
                }

                    transform.Translate(directionToPlayer * moveSpeed * Time.deltaTime);
            }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Running = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Running = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Running = false;
    }


}
