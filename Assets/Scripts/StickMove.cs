using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickMove : MonoBehaviour
{
 
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Получаем позицию, на которую было произведено нажатие мышью
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Получаем все коллайдеры в точке нажатия мыши
            Collider2D[] hitColliders = Physics2D.OverlapPointAll(mousePosition);

            // Перебираем найденные коллайдеры
            foreach (Collider2D col in hitColliders)
            {
                // Проверяем тег коллайдера
                if (col.CompareTag("Sticks"))
                {
                    Vector3 targetPosition = GetMouseWorldPosition();

                    // Перемещаем объект в указанную позицию
                    transform.position = targetPosition;
                }
            }
        }
        
    }

    private Vector3 GetMouseWorldPosition()
    {
        // Получаем позицию мыши в экранных координатах
        Vector3 mouseScreenPosition = Input.mousePosition;

        // Добавляем расстояние от камеры до объекта, чтобы получить координаты в мировом пространстве
        mouseScreenPosition.z = -Camera.main.transform.position.z;

        // Переводим экранные координаты в мировые координаты
        return Camera.main.ScreenToWorldPoint(mouseScreenPosition);
    }
}
