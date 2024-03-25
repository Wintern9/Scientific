using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickMove : MonoBehaviour
{
 
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // �������� �������, �� ������� ���� ����������� ������� �����
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // �������� ��� ���������� � ����� ������� ����
            Collider2D[] hitColliders = Physics2D.OverlapPointAll(mousePosition);

            // ���������� ��������� ����������
            foreach (Collider2D col in hitColliders)
            {
                // ��������� ��� ����������
                if (col.CompareTag("Sticks"))
                {
                    Vector3 targetPosition = GetMouseWorldPosition();

                    // ���������� ������ � ��������� �������
                    transform.position = targetPosition;
                }
            }
        }
        
    }

    private Vector3 GetMouseWorldPosition()
    {
        // �������� ������� ���� � �������� �����������
        Vector3 mouseScreenPosition = Input.mousePosition;

        // ��������� ���������� �� ������ �� �������, ����� �������� ���������� � ������� ������������
        mouseScreenPosition.z = -Camera.main.transform.position.z;

        // ��������� �������� ���������� � ������� ����������
        return Camera.main.ScreenToWorldPoint(mouseScreenPosition);
    }
}
