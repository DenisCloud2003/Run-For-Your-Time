using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : ItemBase
{
    [SerializeField] public UsePoint usePoint;
    [SerializeField] bool isPickedUp;
    SpriteRenderer axeSprite;

    private void Awake()
    {
        axeSprite = GetComponent<SpriteRenderer>();
        isPickedUp = false;
    }

    //Check using state
    private void Update()
    {
        UseAxe();
    }

    //Use the axe
    private void UseAxe()
    {
        if (isPickedUp && usePoint.UseState())
        {
            Use();
        }
    }

    //Pick up axe
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            axeSprite.enabled = false;
            isPickedUp = true;
        }
    }
}