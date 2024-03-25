using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    public GameObject itemPrefab; // Ссылка на префаб предмета
    public Transform spawnPoint;  // Точка, где должен быть создан предмет

    public void SpawnNewItem()
    {
        // Проверяем, есть ли ссылка на префаб и точку спауна
        if (itemPrefab != null && spawnPoint != null)
        {
            // Создаем экземпляр предмета на точке спауна
            GameObject newItem = Instantiate(itemPrefab, spawnPoint.position, Quaternion.identity);

            // Можно добавить дополнительные настройки для созданного предмета здесь
        }
        else
        {
            Debug.LogError("Пожалуйста, установите префаб предмета и точку спауна в инспекторе.");
        }
    }
}
