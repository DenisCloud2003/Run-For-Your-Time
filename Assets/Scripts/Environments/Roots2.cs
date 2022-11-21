using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roots2 : Watch
{
    protected int animCount = 0;
    Animator roots2Anim;

    // Start is called before the first frame update
    void Start()
    {
        roots2Anim = GetComponent<Animator>();
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
            if (isForward && !isBackward && animCount < 3)
            {
                roots2Anim.SetTrigger("Forward");
                animCount++;
            }
            else if (isBackward && !isForward && animCount > 0)
            {
                roots2Anim.SetTrigger("Backward");
                animCount--;
            }
            else StartCoroutine(Timer());

            if (isForward && animCount == 3)
            {
                isUsing = false;
            }
        }
        else
        {
            StartCoroutine(Timer());
        }
    }
}
