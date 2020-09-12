using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static LevelManager instance;
    public GameObject[] LevelPanel;
    string ButtonClicked;
    public Button[] Buttons;
    public int AtLevel;
    public int NextButtonActive;
    public GameObject TutorialPanel;
    public GameObject ContactUsPanel;
    int ActivePanelNo, NextPanelNo, PreviousPanelNo;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {

 

        AtLevel = PlayerPrefs.GetInt("AtLevel", NextButtonActive+1);
        for (int i = 0; i < Buttons.Length; i++)
        {
            if (i + 1 > AtLevel)
            {
                Buttons[i].interactable = false;
            }
        }

        print(NextButtonActive);

    }

    // Update is called once per frame
    void Update()
    {
       // UnlockingButton();
    }

    public void Play()
    {
        ActivePanelNo = 0;
        LevelPanel[ActivePanelNo].SetActive(true);
    }

    public void BackToMenu()
    {
        LevelPanel[ActivePanelNo].SetActive(false);
    }

    public void NextPanel()
    {
        NextPanelNo = ActivePanelNo + 1;
        LevelPanel[NextPanelNo].SetActive(true);
        LevelPanel[ActivePanelNo].SetActive(false);
        ActivePanelNo = NextPanelNo;
    }

    public void PreviousPanel()
    {
        PreviousPanelNo = ActivePanelNo - 1;
        LevelPanel[PreviousPanelNo].SetActive(true);
        LevelPanel[ActivePanelNo].SetActive(false);
        ActivePanelNo = PreviousPanelNo;
    }

  
    public void LoadScene()
    {
        ButtonClicked = EventSystem.current.currentSelectedGameObject.name;
        SceneManager.LoadScene(ButtonClicked);
    }


    public void UnlockingButton()
    {
       
    }


    public void Exit()
    {
        Application.Quit();
    }

    public void ContactUs()
    {
        ContactUsPanel.SetActive(true);
    }

    public void Tutorial()
    {
        TutorialPanel.SetActive(true);
    }

    public void ContactusExitPanel()
    {
        ContactUsPanel.SetActive(false);
    }

    public void TutorialExitPanel()
    {
        TutorialPanel.SetActive(false);
    }
}
