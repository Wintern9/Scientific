using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    public GameObject itemPrefab; // ������ �� ������ ��������
    public Transform spawnPoint;  // �����, ��� ������ ���� ������ �������

    public void SpawnNewItem()
    {
        // ���������, ���� �� ������ �� ������ � ����� ������
        if (itemPrefab != null && spawnPoint != null)
        {
            // ������� ��������� �������� �� ����� ������
            GameObject newItem = Instantiate(itemPrefab, spawnPoint.position, Quaternion.identity);

            // ����� �������� �������������� ��������� ��� ���������� �������� �����
        }
        else
        {
            Debug.LogError("����������, ���������� ������ �������� � ����� ������ � ����������.");
        }
    }
}
