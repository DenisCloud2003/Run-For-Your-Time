using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roots : Watch
{
    public GameObject triggerPoint;
    protected int animCount = 0;
    Animator rootsAnim;

    // Start is called before the first frame update
    void Start()
    {
        rootsAnim = GetComponent<Animator>();
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
                rootsAnim.SetTrigger("Forward");
                animCount++;
            }
            else if (isBackward && !isForward && animCount > 0)
            {
                rootsAnim.SetTrigger("Backward");
                animCount--;
            }
            else StartCoroutine(Timer());

            if (isForward && animCount == 3)
            {
                isUsing = false;
                triggerPoint.SetActive(true);
            }
        }
        else
        {
            StartCoroutine(Timer());
        }
    }
}
