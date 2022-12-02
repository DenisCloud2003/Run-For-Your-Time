using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] GameObject gameOverPanel;

    public GameObject point1;
    public GameObject point2;

    public GameObject phase1;
    public GameObject phase2;
    public GameObject phase3;

    public TextManager textManager;
    public PlayerMovement playerMovement;
    Timer time;

    [HideInInspector] string text;


    private void Awake()
    {
        mainCamera.transform.position = new Vector3(-7f, mainCamera.transform.position.y, -4.5f);
        time = GameObject.Find("Timer").GetComponent<Timer>();
        text = null;

        phase1.SetActive(true);
        phase2.SetActive(false);
        phase3.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("endPoint1"))
        {
            time.timer += 15f;
            mainCamera.transform.position = new Vector3(mainCamera.transform.position.x + 4.7f, mainCamera.transform.position.y, mainCamera.transform.position.z);
            point1.SetActive(false);

            phase1.SetActive(false);
            phase2.SetActive(true);
        }
        else if (collision.CompareTag("endPoint2"))
        {
            time.timer += 15f;
            mainCamera.transform.position = new Vector3(mainCamera.transform.position.x + 4.7f, mainCamera.transform.position.y, mainCamera.transform.position.z);
            point2.SetActive(false);

            phase2.SetActive(false);
            phase3.SetActive(true);
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
