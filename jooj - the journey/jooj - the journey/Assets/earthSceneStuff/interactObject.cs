﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class interactObject : MonoBehaviour
{
    public GameObject Player;
    public GameObject PlayerCamera;
    public GameObject ShipCamera;

    bool isInside = false;
    bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;

    public Text entrar;
    public Text sair;

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

    }

    void Update()
    {
        if(!isInside && Input.GetKeyDown(interactKey) && isInRange)
        {
            Debug.Log(interactKey);
            interactAction.Invoke();
            isInside = true;

            ShipCamera.SetActive(true);
            PlayerCamera.SetActive(false);
            Player.SetActive(false);
            SceneManager.LoadScene("MainGameScene");
        }
        else if(isInside && Input.GetKeyDown(interactKey))
        {
            Debug.Log(interactKey);
            interactAction.Invoke();
            isInside = false;

            Player.SetActive(true);
            PlayerCamera.SetActive(true);
            ShipCamera.SetActive(false);

        }
    }
}
