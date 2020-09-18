using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager instance;
    public GameObject LevelCompletePanel;
    public GameObject GamePlayPanel;
    public GameObject PlayerDiePanel;
    public GameObject ChallengePanel;
    public bool LevelComplete;
    public int ButtonActive;
    string ButtonClick;
    public GameObject[] LevelPanel;
    string ButtonClicked;
    public Button[] Buttons;
    public int AtLevel;
    public GameObject TutorialPanel;
    public GameObject ContactUsPanel;
    int ActivePanelNo, NextPanelNo, PreviousPanelNo;


    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }
    void Start()
    {
        LevelComplete = false;

        AtLevel = PlayerPrefs.GetInt("AtLevel", 1);
        for (int i = 0; i < Buttons.Length; i++)
        {
            if (i + 1 > AtLevel)
            {
                Buttons[i].interactable = false;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (RocketController.instance.PlayerDead)
        {
            StartCoroutine(PlayerDead());
        }

        if (LevelComplete)
        {

            StartCoroutine(OnLevelComplete());
        }

     
    }

    public void ChallengeAcceptButton()
    {
        GamePlayPanel.SetActive(true);
        ChallengePanel.SetActive(false);
    }

    IEnumerator OnLevelComplete()
    {
        yield return new WaitForSeconds(1f);
        LevelCompletePanel.SetActive(true);
        GamePlayPanel.SetActive(false);
        PlayerPrefs.SetInt("AtLevel", ButtonActive);
    }

    IEnumerator PlayerDead()
    {
        yield return new WaitForSeconds(3f);
        PlayerDiePanel.SetActive(true);
        GamePlayPanel.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("0");
    }

    public void PlayAgain()
    {
        ButtonClick = EventSystem.current.currentSelectedGameObject.name;
        SceneManager.LoadScene(ButtonClick);
    }

    public void NextLevel()
    {
        ButtonClick = (ButtonActive).ToString();
        SceneManager.LoadScene(ButtonClick);
    }

    public void LoadScene()
    {
        ButtonClicked = EventSystem.current.currentSelectedGameObject.name;
        SceneManager.LoadScene(ButtonClicked);
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
