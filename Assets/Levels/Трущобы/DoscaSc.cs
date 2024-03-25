using UnityEngine;

public class DoscaSc : MonoBehaviour
{
    public GameObject[] DoscaScPrefab;
    public GameObject DoscaScCollider;

    public bool bol = false;
    private bool bolInput = false;

    public void LateStart()
    {
        //Debug.Log(bol);
        if (bol)
        {
            foreach (GameObject go in DoscaScPrefab) { go.SetActive(false); }
            DoscaScCollider.SetActive(false);
            TeniLobby.TeniBool = true;
            FindFirstObjectByType<SortingLayer>().Switch();
        }
    }

    int sssa = 0;
    Collider2D collision0;

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision0 = null;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        collision0 = collision;
    }

    private void Update()
    {
        if (bol == false)
        {
            if (collision0 != null)
            {
                if (collision0.CompareTag("Player"))
                {
                    if (Stone.Take)
                    {
                        Debug.Log("E");
                        sssa++;
                        Stone.Take = false;
                    }
                }
            }

            if (sssa != 0)
            {
                if (sssa % 3 == 0)
                {
                    DoscaScPrefab[(sssa / 3) - 1].SetActive(false);
                    if (sssa / 3 == 4)
                    {
                        DoscaScCollider.SetActive(false);
                        FindFirstObjectByType<SortingLayer>().Switch();
                        bolInput = true;
                        TeniLobby.TeniBool = true;
                    }
                }

                if (bolInput)
                {
                    Player itemToUpdate = Serialization.connection.Table<Player>().FirstOrDefault();

                    if (itemToUpdate != null)
                    {
                        itemToUpdate.DoscaOpen = 1;

                        Serialization.connection.Update(itemToUpdate);
                    }
                    else
                    {
                        Debug.LogError("Item with Id " + 1 + " not found.");
                    }
                    bolInput = false;
                    bol = true;
                }
            }
        }
    }

}
