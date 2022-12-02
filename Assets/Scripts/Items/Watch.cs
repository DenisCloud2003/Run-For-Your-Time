using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watch : ItemBase
{
    [SerializeField] public bool isForward;
    [SerializeField] public bool isBackward;
    [SerializeField] SpriteRenderer watchSprite;

    [HideInInspector] public int count = 0;
    public float cooldownTimer;
    public bool watchPickedUp;
    public static Watch instance;

    private void Awake()
    {
        watchSprite = GameObject.Find("Watch").GetComponent<SpriteRenderer>();
        watchPickedUp = false;
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

        if (Input.GetKeyDown(KeyCode.R) && cooldownTimer == 0 && !isUsing && watchPickedUp)
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        watchSprite.enabled = false;
        watchPickedUp = true;

        itemList.isUsingWatch = true;
        itemList.Items.Add(GameObject.FindGameObjectWithTag("Watch"));
        itemList.watchUI.SetActive(true);
    }
}
