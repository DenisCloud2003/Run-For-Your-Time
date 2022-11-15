using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watch : ItemBase
{
    [SerializeField] protected bool isForward;
    [SerializeField] protected bool isBackward;

    [SerializeField] GameObject watchPrefab;

    public int count = 0;
    public float cooldownTimer;

    public static Watch instance;

    private void Awake()
    {
        instance = this;
    }

    public void Update()
    {
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

    public void KeyInput()
    {
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

        Use();
    }

    void ForwardMode()
    {
        isForward = true;
        isBackward = false;
    }

    void BackwardMode()
    {
        isBackward = true;
        isForward = false;
    }
}
