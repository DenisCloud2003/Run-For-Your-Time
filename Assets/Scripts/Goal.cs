using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private GameObject startPoint;

   public Timer timer;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player.transform.position = new Vector2(startPoint.transform.position.x, Player.transform.position.y);
            timer.PauseTimer();
        }
    }
}
