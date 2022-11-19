using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootsEvent : MonoBehaviour
{
    public GameObject collider1;
    public GameObject collider2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collider1.SetActive(true);
        collider2.SetActive(true);
    }
}
