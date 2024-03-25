using UnityEngine;
using TMPro; // Убедитесь, что добавили using для TextMeshPro

public class TypeLevel : MonoBehaviour
{
    private TextMeshProUGUI textMeshProUI;
    public GameObject gameDisable;

    static public string type = "Зачистка";

    private string Stype = "Зачистка";
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
        // Устанавливаем новый текст для компонента TextMeshProUGUI
        if (textMeshProUI != null)
        {
            textMeshProUI.text = "Тип: " + newText;
        }
        else
        {
            Debug.LogError("Не найден компонент TextMeshProUGUI. Убедитесь, что он прикреплен к объекту и связан с этим скриптом.");
        }
    }
}
