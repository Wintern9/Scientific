using UnityEngine;

public class MonsterCollider : MonoBehaviour
{
    private Animator monsterAnimator;
    public bool playerInsideCollider = false;
    public string NameAttack;
    public string NameRun;

    public int attack = 0;

    void Start()
    {
        monsterAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (playerInsideCollider)
        {
            monsterAnimator.Play(NameAttack);
            //monsterAnimator.Play(NameRun);
        }
    }

    public void OnAnimationComplete()
    {
        if (playerInsideCollider)
        {
            TopDownCharacterController.hp -= attack;
            //Debug.Log(TopDownCharacterController.hp);
            if (TopDownCharacterController.hp <= 0)
            {
                Debug.Log("Kill");
                TopDownCharacterController.MoveAgr = false;
                GameObject.FindGameObjectWithTag("Player").gameObject.SetActive(false);
            }
        }
        monsterAnimator.Play(NameRun);
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
