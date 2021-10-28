using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    [SerializeField] 
    private GameObject endingUI;

    [SerializeField] 
    private GameObject endingButtons;

    [SerializeField] 
    private TextMeshProUGUI textMeshPro;
    
    
    public PlayerController playerController;

    private void Start()
    {
        textMeshPro.text += (SceneManager.GetActiveScene().buildIndex + 1).ToString();
    }

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

        if (playerController.finished)
        {
            StartCoroutine(ShowEndingButtons());
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel()
    {
        int nextScene = (SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(nextScene);
    }

    IEnumerator ShowButton()
    {
        yield return new WaitForSeconds(1.2f);
        restartButton.SetActive(true);
    }

    IEnumerator ShowEndingButtons()
    {
        textMeshPro.gameObject.SetActive(false);
        endingUI.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        endingButtons.SetActive(true);
    }
    
}
