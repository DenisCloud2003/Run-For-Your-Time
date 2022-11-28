using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemList : MonoBehaviour
{
    [SerializeField] GameObject[] Items;
    private int data;

    private void Awake()
    {
        
    }

    private int Return()
    {
        foreach (GameObject item in Items)
        {
            if (item.name == "Watch")
            {
                data = 0;
            }
            else data = 1;
        }

        return data;
    }
}
