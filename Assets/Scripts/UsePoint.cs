using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsePoint : MonoBehaviour
{
    [SerializeField] Sprite usingPointSpr;
    [SerializeField] GameObject usingPanel;
    [SerializeField] bool canUse;

    private void Awake()
    {
        canUse = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canUse = true;
        usingPanel.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canUse = false;
        usingPanel.SetActive(false);
    }

    public bool UseState()
    {
        return canUse;
    }
}
