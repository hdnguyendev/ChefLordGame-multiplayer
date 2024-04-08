using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;

    public void Awake()
    {
        playButton.onClick.AddListener(OnPlayButtonClicked);
        quitButton.onClick.AddListener(OnQuitButtonClicked);

        Time.timeScale = 1f;
    }
    private void OnPlayButtonClicked()
    {
        // Load game scene
        Loader.Load(Loader.Scene.GameScene);
    }
    private void OnQuitButtonClicked()
    {
        Application.Quit();
    }


}
