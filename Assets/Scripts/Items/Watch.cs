using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watch : ItemBase
{
    [SerializeField] protected bool isForward;
    [SerializeField] protected bool isBackward;

    public int count = 0;
    public float cooldownTimer;

    public static Watch instance;

    //Constructor
    private void Awake()
    {
        instance = this;
    }

    public void Update()
    {
        Use();

        //Prevent spamming the clock
        if (cooldownTimer > 0f)
        {
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer < 0f)
            {
                cooldownTimer = 0f;
            }
        }
        else
        {
            KeyInput();
        }
    }

    //Check key input function
    public void KeyInput()
    {
        if (!isForward && !isBackward)
        {
            isUsing = false;
        }

        if (Input.GetKeyDown(KeyCode.R) && cooldownTimer == 0 && !isUsing)
        {
            if (count == 0)
            {
                ForwardMode();
                count++;
            }
            else if (count == 1)
            {
                BackwardMode();
                count--;
            }

            cooldownTimer = 1.5f;
        }
    }

    //Set clock mode to forward
    void ForwardMode()
    {
        isForward = true;
        isBackward = false;
    }

    //Set clock mode to backward
    void BackwardMode()
    {
        isBackward = true;
        isForward = false;
    }
}
