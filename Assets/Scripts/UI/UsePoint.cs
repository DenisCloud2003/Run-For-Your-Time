using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsePoint : MonoBehaviour
{
    [SerializeField] Sprite usingPointSpr;
    [SerializeField] GameObject usingPanel;
    [SerializeField] bool canUse;
    Axe axe;

    private void Awake()
    {
        axe = GameObject.Find("Axe").GetComponent<Axe>();
        canUse = false;
    }

    //In the use point
    private void OnTriggerEnter2D(Collider2D collision)
    {
        canUse = true;
        usingPanel.SetActive(true);
    }

    //Out the use point
    private void OnTriggerExit2D(Collider2D collision)
    {
        canUse = false;
        usingPanel.SetActive(false);
    }

    //Return the boolean of use state
    public bool UseState()
    {
        return canUse;
    }
}
