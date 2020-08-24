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
    public GameObject LevelPanel1;
    string ButtonClicked;
    public Button[] Buttons;
    public int ButtonNum;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        Buttons = GetComponent<Button[]>();
    }

    // Update is called once per frame
    void Update()
    {
        UnlockingButton();
    }

    public void Play()
    {
        LevelPanel1.SetActive(true);
    }

    public void BackToMenu()
    {
        LevelPanel1.SetActive(false);
    }

    public void LoadScene()
    {
        ButtonClicked = EventSystem.current.currentSelectedGameObject.name;
        SceneManager.LoadScene(ButtonClicked);
    }


    void UnlockingButton()
    {
        if(GameManager.instance.LevelComplete)
        {
            ButtonNum = GameManager.instance.ButtonActive;
            Buttons[ButtonNum].interactable = true;
        }
       
    }


    public void Exit()
    {
        Application.Quit();
    }

    void ContactUs()
    {

    }
}
