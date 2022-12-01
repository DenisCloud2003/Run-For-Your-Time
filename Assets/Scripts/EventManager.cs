using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void TriggerAction();
    public static event TriggerAction OnTrigger;

    public void EventTrigger()
    {
        if (OnTrigger != null)
        {
            OnTrigger();
        }
    }
}
