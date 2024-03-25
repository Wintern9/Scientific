using UnityEngine;
using TMPro; // ���������, ��� �������� using ��� TextMeshPro

public class TypeLevel : MonoBehaviour
{
    private TextMeshProUGUI textMeshProUI;
    public GameObject gameDisable;

    static public string type = "��������";

    private string Stype = "��������";
    private string Stype2 = "Destruction";

    void Start()
    {
        textMeshProUI = GetComponent<TextMeshProUGUI>();
        ChangeText(type);
        if(type != Stype)
        {
            gameDisable.SetActive(false);
        }
    }

    void ChangeText(string newText)
    {
        // ������������� ����� ����� ��� ���������� TextMeshProUGUI
        if (textMeshProUI != null)
        {
            textMeshProUI.text = "���: " + newText;
        }
        else
        {
            Debug.LogError("�� ������ ��������� TextMeshProUGUI. ���������, ��� �� ���������� � ������� � ������ � ���� ��������.");
        }
    }
}
