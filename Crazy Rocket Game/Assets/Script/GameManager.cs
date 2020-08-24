using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        ButtonClick = (ButtonActive + 1).ToString();
        SceneManager.LoadScene(ButtonClick);
    }

}
