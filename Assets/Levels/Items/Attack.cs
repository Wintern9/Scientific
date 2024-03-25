using UnityEngine;
using UnityEngine.UI;

public class ButtonClickEmulator : MonoBehaviour
{
    Shooting shooting;
    TopDownCharacterController topDownCharacterController;
    private void Start()
    {
        shooting = FindFirstObjectByType<Shooting>();
        topDownCharacterController = FindFirstObjectByType<TopDownCharacterController>();
    }

    public void DropDown()
    {
        DropItem.drop = true;
    }

    public void TakeDown()
    {
        Stone.Take = true;
        Debug.Log("Поднять");
    }

    public void TakeUp()
    {
        Stone.Take = false;
    }

    public void AttackDown()
    {
        shooting.input = true;
    }

    public void AttackUp()
    {
        shooting.input = false;
    }

    public void RunDown()
    {
        topDownCharacterController.shift = true;
    }

    public void RunUp()
    {
        topDownCharacterController.shift = false;
    }

    bool Space = false;

    public void RunClick()
    {
        if (Space)
        {
            topDownCharacterController.space = true;
        }

        Space = true;
    }

    float time = 0.5f;

    public void Update()
    {
        if (Space) {
            time -= Time.deltaTime;
            Debug.Log("time = " + time);
            if (time < 0)
            {
                Space = false;
                topDownCharacterController.space = false;
                time = 0.5f;
            }
        }
    }

    //private void Update()
    //{
    //    if (Input.touchCount > 0)
    //    {
    //        // Получаем позицию, на которую было произведено нажатие мышью
    //        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    //        // Получаем все коллайдеры в точке нажатия мыши
    //        Collider2D[] hitColliders = Physics2D.OverlapPointAll(mousePosition);

    //        // Перебираем найденные коллайдеры
    //        foreach (Collider2D col in hitColliders)
    //        {
    //            // Проверяем тег коллайдера
    //            if (col.CompareTag("Attack"))
    //            {
    //                Debug.Log("Attack");
    //                shooting.input = true;
    //            }

    //            if (col.CompareTag("Shift"))
    //            {
    //                Debug.Log("Shift");
    //                topDownCharacterController.shift = true;
    //            }
    //        }
    //    } else
    //    {
    //        shooting.input = false;
    //        topDownCharacterController.shift = false;
    //    }

    //    if (Input.touchCount == 2)
    //    {
    //        Debug.Log("2");
    //    }
    //}
}
