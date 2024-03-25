using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    public Transform target; // Цель, за которой будет следить камера
    public float smoothSpeed = 5f; // Скорость следования
    public float ppu = 1f; // Пикселей в юните
    private float step;

    void Start()
    {
        step = ppu / ((Screen.height * 0.5f) / Camera.main.orthographicSize);
    }

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 currentPosition = transform.position;

            // Соблюдаем сабпиксельную сетку
            Vector3 snappedPosition = Snap(target.position);

            // Используем SmoothDamp для плавного следования камеры
            Vector3 smoothedPosition = Vector3.Lerp(currentPosition, snappedPosition, smoothSpeed * Time.deltaTime);

            // Устанавливаем новую позицию камеры
            transform.position = smoothedPosition;
        }
    }

    // Преобразование координат по сабпиксельной сетке
    private Vector3 Snap(Vector3 pos)
    {
        return new Vector3(pos.x - nfmod(pos.x, step), pos.y - nfmod(pos.y, step), -10);
    }

    // Функция возвращающая остаток от деления, не зависящая от знака
    private float nfmod(float a, float b)
    {
        return a - b * Mathf.Floor(a / b);
    }
}
