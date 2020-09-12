using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static UIManager instance;
    public float TotalDaimonds;
    public float TotalMegastar;
    public Text DaimondsRemaining;
    public Text MegaStarRemaining;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        DaimondsCount();
        MegaStarCount();
    }

    void DaimondsCount()
    {
        if(TotalDaimonds>=0)
        {
            DaimondsRemaining.text = TotalDaimonds.ToString();
        } 
    }

    void MegaStarCount()
    {
        if(TotalMegastar>=0)
        {
            MegaStarRemaining.text = TotalMegastar.ToString();
        }
    }
}
