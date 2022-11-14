using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBase : MonoBehaviour
{
    [SerializeField]
    GameObject[] ItemList;
    [SerializeField] protected bool isUsing;

    [HideInInspector] private int inputCount = 0;

    static ItemBase instance;

    //Constructor
    public ItemBase()
    {
        instance = this;
    }

    //Switching item in an item list(array)
    protected void Switch()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {

        }
        else if (Input.GetKeyDown(KeyCode.E))
        {

        }
    }

    //Function to use an item
    protected void Use()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (inputCount == 0)
            {
                isUsing = true;
                inputCount++;
            }
            else
            {
                isUsing = false;
                inputCount--;
            }
            
        }
    }
}
