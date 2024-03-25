using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCloses : MonoBehaviour
{
    public GameObject Canvas;
    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ButtonClose()
    {
        TopDownCharacterController.MoveAgr = true;
        animator.enabled = true;
        animator.SetBool("Button", true);
    }

    public void OnAnimationComplete()
    {
        gameObject.GetComponent<CanvasChanger>().Click();
        Canvas.SetActive(false);
    }
    
    public void OnAnimation()
    {
        animator.enabled = false;
    }

    private void OnDisable()
    {
        Animator animator = GetComponent<Animator>();
        animator.SetBool("Button", false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            animator.enabled = true;
            animator.SetBool("Button", true);
        }
    }
}
