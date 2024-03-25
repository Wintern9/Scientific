using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float moveSpeed = 0.5f; // Скорость движения объекта

    public GameObject[] players;
    public Transform player;
    private float randomAngle;

    void Start()
    {
        randomAngle = Random.Range(-30f, 30f);
        players = GameObject.FindGameObjectsWithTag("Player");
        player = players[0].GetComponent<Transform>();
    }

    void Update()
    {
        Vector3 currentPosition = transform.position;
        Vector3 directionToPlayer = transform.position - player.position;
        float angleToPlayer = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg-45;
        float finalAngle = angleToPlayer + randomAngle;

        float angleInRadians = Mathf.Deg2Rad * (transform.eulerAngles.z+45);
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, finalAngle));

        // Вычисляем новую позицию, двигая объект вперед по диагонали
        Vector3 newPosition = currentPosition + new Vector3(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians), 0f) * moveSpeed * Time.deltaTime;

        // Проверяем наличие препятствия перед объектом
        RaycastHit2D hit = Physics2D.Raycast(currentPosition, newPosition - currentPosition, Vector3.Distance(currentPosition, newPosition));

        if (hit.collider != null && hit.collider.tag == "Collision")
        {
            // Если есть столкновение с объектом "Collision", останавливаем движение
            //Debug.Log("Столкновение с объектом 'Collision'");
        }
        else
        {
            // Если нет столкновения, двигаем объект
            transform.position = newPosition;
        }
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
