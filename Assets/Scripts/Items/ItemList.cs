using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemList : ItemBase
{
    [SerializeField] protected GameObject[] Items;
    GameObject watchUI;
    GameObject axeUI;
    [HideInInspector] private int rotateCount = 0;

    private void Awake()
    {
        Items = GameObject.FindGameObjectsWithTag("Item");
    }

    private void Update()
    {
        RotateItems();
    }
    private void RotateItems()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (rotateCount == 0 && Items[rotateCount].name == "Watch")
            {
                rotateCount++;
            }
            else rotateCount--;
        }
    }
}
