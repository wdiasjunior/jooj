using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using static System.Net.Mime.MediaTypeNames;

public class InteractCasa : MonoBehaviour
{
    public GameObject Player;
    public GameObject PlayerCamera;
    public GameObject HouseCamera;
    public Canvas Canvas2;

    bool isInside = false;
    bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            Debug.Log("ta no range meu parça");
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            Debug.Log("ta fora do range meu parça");
        }
    }

    void Start()
    {
        Canvas2 = GameObject.Find("Canvas2").GetComponent<Canvas>();
        Canvas2.enabled = false;
    }

    void Update()
    {
        if (!isInside && Input.GetKeyDown(interactKey) && isInRange)
        {
            Debug.Log(interactKey);
            interactAction.Invoke();
            isInside = true;
            HouseCamera.SetActive(false);
            PlayerCamera.SetActive(false);
            Player.SetActive(false);
            Canvas2.enabled = true;
            Thread.Sleep(10000);
            PlayerPrefs.SetInt("score", 0);
            SceneManager.LoadScene("MainMenu");
        }
        else if (isInside && Input.GetKeyDown(interactKey))
        {
            Debug.Log(interactKey);
            interactAction.Invoke();
            isInside = false;

            Player.SetActive(true);
            PlayerCamera.SetActive(true);
            HouseCamera.SetActive(false);

        }
    }
}
