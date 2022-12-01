using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBase : MonoBehaviour
{
    [SerializeField] protected bool isUsing;
    [HideInInspector] private int inputCount = 0;

    //Use function
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

    //Uncheck the use condition
    protected void NotUse()
    {
        isUsing = false;
        inputCount = 0;
    }
}
