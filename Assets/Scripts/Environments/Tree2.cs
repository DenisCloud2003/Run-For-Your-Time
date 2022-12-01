using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree2 : Watch
{
    [SerializeField] GameObject usePoint;
    private int animCount = 0;
    Animator tree2Anim;

    // Start is called before the first frame update
    void Start()
    {
        tree2Anim = GetComponent<Animator>();
        usePoint.SetActive(false);
    }

    //Run cut tree Anim
    private void CutTree()
    {
        tree2Anim.SetTrigger("Cut");
    }

    //Check for item input
    public void CheckInput()
    {
        StartCoroutine(Timer());
    }

    //Delay && Anim runner
    public IEnumerator Timer()
    {
        //Time delay for each Anim state
        yield return new WaitForSeconds(1.5f);

        if (isUsing)
        {
            //If Anim at right tree, set the use point to true
            if (animCount == 3)
            {
                usePoint.SetActive(true);
            }

            //Run anim base on the item ouput
            if (isForward && !isBackward && animCount < 4)
            {
                tree2Anim.SetTrigger("Forward");
                animCount++;
            }
            else if (isBackward && !isForward && animCount > 0)
            {
                tree2Anim.SetTrigger("Backward");
                animCount--;
            }
            else StartCoroutine(Timer());

            //If at the last Anim, set using state to false
            if (isForward && animCount == 4)
            {
                isUsing = false;
            }
        }
        else //Infinite loop to check the condition
        {
            StartCoroutine(Timer());
        }
    }
}
