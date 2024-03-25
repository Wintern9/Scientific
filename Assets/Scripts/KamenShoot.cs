using UnityEngine;

public class StoneProjectile : MonoBehaviour
{
    static public float speed = 5f; // Скорость полета камня
    private bool hasCollided = false; // Флаг, указывающий, столкнулся ли камень
    private bool ange = true; // Флаг, указывающий, столкнулся ли камень
    private bool DestroyBool = true;

    public int attack = 10;

    private void Start()
    {
        speed = 5f;
    }

    void Update()
    {
        if (!hasCollided)
        {
            transform.Translate(Vector2.right * speed * 0.008f);
            if (ange)
            {
                speed *= 0.99f;
            }
            else
            {
                speed *= 0.8f;
            }

            if (speed < 0.1f)
            {
                speed = 0;
                DestroyBool = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Проверяем, сталкиваемся ли с другим объектом, который тоже является триггером
        if (other.isTrigger)
        {
            //Vector2 direction = (other.transform.position - transform.position).normalized;
            //Vector2 reflectedDirection = Vector2.Reflect(direction, other.transform.up);
            //float angle = Vector2.Angle(Vector2.right, reflectedDirection);
            //if (reflectedDirection.y < 0)
            //{
            //    angle = 360 - angle;
            //}
            //Debug.Log("Угол отражения: " + angle);


            if (other.CompareTag("DeathBox") && DestroyBool)
            {
                Debug.Log(other.GetComponent<ObjectDestroyer>().hp + " " + attack);
                other.GetComponent<ObjectDestroyer>().hp -= attack;
                
                if (other.GetComponent<ObjectDestroyer>().hp <= 0)
                {
                    other.gameObject.SetActive(false);
                }
            }

            if ((other.CompareTag("Collision") || other.CompareTag("Collision2")) && DestroyBool)
            {
                // Получаем вектор направления объекта и нормали к поверхности
                Vector2 incidentDirection = transform.up;
                Vector2 surfaceNormal = other.transform.up;

                // Вычисляем угол между направлением и нормалью
                float angle = Vector2.Angle(surfaceNormal, incidentDirection);
                Vector2 reflectedDirection;
                // Отражаем вектор направления относительно нормали
                if (other.CompareTag("Collision"))
                {
                    reflectedDirection = Vector2.Reflect(incidentDirection, surfaceNormal);
                }else
                {
                    reflectedDirection = Vector2.Reflect(-incidentDirection, surfaceNormal);
                }
                // Применяем отраженное направление
                // В этом месте вы можете использовать reflectedDirection для управления движением объекта
                Debug.Log("Угол соприкосновения: " + angle);
                Debug.Log("Отраженное направление: " + reflectedDirection);
                transform.up = reflectedDirection;
                ange = false;
            }
        }
    
    }
}
