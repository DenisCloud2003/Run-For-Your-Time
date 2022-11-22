using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : ItemBase
{
    [SerializeField] public UsePoint usePoint;
    SpriteRenderer axeSprite;
    [SerializeField] bool isPickedUp;

    private void Awake()
    {
        axeSprite = GetComponent<SpriteRenderer>();
        isPickedUp = false;
    }

    private void Update()
    {
        UseAxe();
    }

    private void UseAxe()
    {
        if (isPickedUp && usePoint.UseState())
        {
            Use();
            StartCoroutine(DelayAfterUse());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            axeSprite.enabled = false;
            isPickedUp = true;
        }
    }

    IEnumerator DelayAfterUse()
    {
        yield return new WaitForSeconds(1f);
        NotUse();
    }
}
