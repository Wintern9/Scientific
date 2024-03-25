using UnityEngine;
using UnityEngine.UI;

public class MouseHover : MonoBehaviour
{
    public int num;
    [SerializeField] private int SceneNum;
    public GameObject cardControl;
    private Animator animator;

    private string[] NameType = { "Босс", "Лобби", "Зачистка"/*, "Лабиринт", "Ловушки" */};

    public Sprite[] sprites;

    private void Start()
    {
        if (gameObject.CompareTag("Card"))
        {
            animator = GetComponent<Animator>();

            

            SceneNum = GetNum();
            animator.SetInteger("CardRan", SceneNum);

            
        }
    }

    void Update()
    {
        CardController cardController = cardControl.GetComponent<CardController>();

        if (IsMouseOver() && !cardController.isMouse)
        {
            cardController.Change(num);
        }

        if (cardController.isMouse)
        {
            if (cardController.nus == num)
            {
                animator.SetInteger("Click", 1);
            }
            else
            {
                animator.SetInteger("Click", 2);
            }
        }
    }

    public static int LevelNum = 0;

    private int GetNum()
    {
        int numm;
        LevelNum++;

        if ((LevelNum % 9 == 0 && LevelNum > 0))
        {
            numm = 0;
        }else{
            if (Random.Range(0, 5) == 1)
            {
                numm = 1;
            }
            else
            {
                numm = Random.Range(2, NameType.Length);
            }
        }
        return numm;
    }

    public GameObject[] cardImages;

    public void SpriteSet()
    {
        Debug.Log("Sprite Set " + (SceneNum));

        cardImages[SceneNum].SetActive(true);
    }

    public void Scene()
    {
        SceneController sceneController = GameObject.FindGameObjectsWithTag("SceneController")[0].GetComponent<SceneController>();
        sceneController.ChangeScene(NameType[SceneNum]);
    }

    public GameObject DarkObj;

    public void Darknes()
    {
        Darkness darkness = DarkObj.GetComponent<Darkness>();
        darkness.Param();
    }

    public void OnMouse()
    {
        CardController cardController = cardControl.GetComponent<CardController>();

        if (cardController.nus == num)
        {
            animator.SetBool("Start", true);
        }
        else
        {
            cardController.numChange(num);
            cardController.Change(num);
            cardController.isMouse = true;
        }
    }

    bool IsMouseOver()
    {
        // Получаем текущие координаты мыши в экранных координатах
        Vector2 mousePosition = Input.mousePosition;

        // Преобразуем экранные координаты в мировые координаты
        Vector2 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Проверяем, находится ли преобразованная позиция внутри коллайдера объекта
        return GetComponent<Collider2D>().OverlapPoint(worldMousePosition);
    }
}
