using UnityEngine;

public class SortingOrderController : MonoBehaviour
{
    public GameObject target;
    private GameObject[] Player;
    private SpriteRenderer player;
    private SpriteRenderer Mon;
    public GameObject s1;
    public GameObject s2;
    private string Name = "Player";
    public int layer;
    

    private void Start()
    {
        Player = GameObject.FindGameObjectsWithTag(Name);
        player = Player[0].GetComponent<SpriteRenderer>();
        Mon = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
         if (player.transform.position.y > transform.position.y)
         {
            Mon.sortingOrder = layer;
            if (s1 != null)
                s1.GetComponent<SpriteRenderer>().sortingOrder = layer+1;
            if (s2 != null)
                s2.GetComponent<SpriteRenderer>().sortingOrder = layer + 1;
         } else{
            Mon.sortingOrder = -layer;
            if (s1 != null)
                s1.GetComponent<SpriteRenderer>().sortingOrder = -layer + 1;
            if (s2 != null)
                s2.GetComponent<SpriteRenderer>().sortingOrder = -layer + 1;
        }

    }
}









//using UnityEngine;

//public class SortingOrderController : MonoBehaviour
//{
//    public GameObject target;
//    private GameObject[] Player;
//    private SpriteRenderer player;
//    public GameObject s1;
//    public GameObject s2;
//    public string Name;
//    public int layer;

//    private void Start()
//    {
//        Player = GameObject.FindGameObjectsWithTag(Name);
//        player = Player[0].GetComponent<SpriteRenderer>();
//    }

//    void Update()
//    {
//        if (target.transform.position.y > Player[0].transform.position.y)
//        {
//            player.sortingOrder = layer;
//            if (s1 != null)
//                s1.GetComponent<SpriteRenderer>().sortingOrder = layer + 1;
//            if (s2 != null)
//                s2.GetComponent<SpriteRenderer>().sortingOrder = layer + 1;
//        }
//        else

//        {
//            player.sortingOrder = -layer;
//            if (s1 != null)
//                s1.GetComponent<SpriteRenderer>().sortingOrder = -layer + 1;
//            if (s2 != null)
//                s2.GetComponent<SpriteRenderer>().sortingOrder = -layer + 1;
//        }

//    }
//}