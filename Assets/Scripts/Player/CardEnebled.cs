using UnityEngine;

public class GameController : MonoBehaviour
{
    public MonoBehaviour[] gamePlayers;

    bool One = false;

    private void OnEnable()
    {
        if (One)
        {
            TopDownCharacterController.MoveAgr = false;

            foreach (var gamePlayer in gamePlayers)
            {
                //gamePlayer.enabled = false; //��������� ���� ����������
            }
            One = false;
        }
    }
}