using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    public Transform target; // ����, �� ������� ����� ������� ������
    public float smoothSpeed = 5f; // �������� ����������
    public float ppu = 1f; // �������� � �����
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

            // ��������� ������������� �����
            Vector3 snappedPosition = Snap(target.position);

            // ���������� SmoothDamp ��� �������� ���������� ������
            Vector3 smoothedPosition = Vector3.Lerp(currentPosition, snappedPosition, smoothSpeed * Time.deltaTime);

            // ������������� ����� ������� ������
            transform.position = smoothedPosition;
        }
    }

    // �������������� ��������� �� ������������� �����
    private Vector3 Snap(Vector3 pos)
    {
        return new Vector3(pos.x - nfmod(pos.x, step), pos.y - nfmod(pos.y, step), -10);
    }

    // ������� ������������ ������� �� �������, �� ��������� �� �����
    private float nfmod(float a, float b)
    {
        return a - b * Mathf.Floor(a / b);
    }
}
