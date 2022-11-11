using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : Watch
{
    public int animCount = 0;
    Animator treeAnim;

    // Start is called before the first frame update
    void Start()
    {
        treeAnim = GetComponent<Animator>();
    }

    public void CheckInput()
    {
        StartCoroutine(Timer());
    }

    public IEnumerator Timer()
    {
        yield return new WaitForSeconds(1.5f);

        if (isUsing)
        {
            if (isForward && !isBackward && animCount < 4)
            {
                treeAnim.SetTrigger("Forward");
                animCount++;
            }
            else if (isBackward && !isForward && animCount > 0)
            {
                treeAnim.SetTrigger("Backward");
                animCount--;
            }
            else StartCoroutine(Timer());
        }
        else
        {
            StartCoroutine(Timer());
        }
    }
}
