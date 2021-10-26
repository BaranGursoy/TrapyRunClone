using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [NonSerialized]
    public bool hasPlayerTouchedTheScreen = false;

    [SerializeField]
    private GameObject startingUI;
    [SerializeField]
    private GameObject restartButton;

    public PlayerController playerController;

    private void Update()
    {
        if (Input.anyKey)
        {
            startingUI.SetActive(false);
            hasPlayerTouchedTheScreen = true;
        }

        if (playerController.gameOver)
        {
            StartCoroutine(ShowButton());
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator ShowButton()
    {
        yield return new WaitForSeconds(1.2f);
        restartButton.SetActive(true);
    }
}
