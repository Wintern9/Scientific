using UnityEngine;
using TMPro;

public class TextInput : MonoBehaviour
{
    public TMP_InputField inputField;
    public TMP_Text displayText;

    private void Start()
    {
        // ƒобавл€ем слушател€ событи€ изменени€ текста
        inputField.onValueChanged.AddListener(UpdateDisplayText);
    }

    private void UpdateDisplayText(string text)
    {
        // ќбновл€ем отображаемый текст
        displayText.text = text;
    }
}
