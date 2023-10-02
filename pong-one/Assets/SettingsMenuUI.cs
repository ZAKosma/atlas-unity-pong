using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenuUI : MonoBehaviour
{
    
//     [SerializeField] private Button singlePlayerButton;
//     [SerializeField] private Button multiPlayerButton;
//     [SerializeField] private Button settingsButton;
    
    [SerializeField] private Button backButton;


    [SerializeField] private RectTransform mainMenuUIParent;

    private void Start()
    {
        backButton.onClick.AddListener(Back);
    }

    public void Back()
    {
        mainMenuUIParent.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }
    
}