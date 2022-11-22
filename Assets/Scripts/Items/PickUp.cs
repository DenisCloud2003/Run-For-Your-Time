using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] GameObject watchItem;
    Watch watch;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
            watchItem.SetActive(true);
        }
    }
}
