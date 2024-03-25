using UnityEngine;
using TMPro;

public class TextInput : MonoBehaviour
{
    public TMP_InputField inputField;
    public TMP_Text displayText;

    private void Start()
    {
        // ��������� ��������� ������� ��������� ������
        inputField.onValueChanged.AddListener(UpdateDisplayText);
    }

    private void UpdateDisplayText(string text)
    {
        // ��������� ������������ �����
        displayText.text = text;
    }
}
