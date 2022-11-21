using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] GameObject gameOverPanel;
    public GameObject point1;
    public GameObject point2;
    public TextManager textManager;
    public PlayerMovement playerMovement;
    [HideInInspector] string text;


    private void Awake()
    {
        mainCamera.transform.position = new Vector3(-7f, mainCamera.transform.position.y, -4.5f);
        text = null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("endPoint1"))
        {
            mainCamera.transform.position = new Vector3(mainCamera.transform.position.x + 4.7f, mainCamera.transform.position.y, mainCamera.transform.position.z);
            point1.SetActive(false);
        }
        else if (collision.CompareTag("endPoint2"))
        {
            mainCamera.transform.position = new Vector3(mainCamera.transform.position.x + 4.7f, mainCamera.transform.position.y, mainCamera.transform.position.z);
            point2.SetActive(false);
        }

        if (collision.CompareTag("Obstacle"))
        {
            playerMovement.Dead();

            StartCoroutine(Delay());
        }

        if (collision.CompareTag("fallPoint"))
        {
            Time.timeScale = 0f;
            gameOverPanel.SetActive(true);
            text = "fall";
            textManager.TextChanger(text);
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
        text = "spike";
        textManager.TextChanger(text);
    }
}
