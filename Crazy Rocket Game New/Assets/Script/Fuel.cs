using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fuel : MonoBehaviour
{
    public static Fuel instance;
    Image FuelImage;
    float MaxFuel = 100f;
    [HideInInspector]
    public float CurrentFuel;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        FuelImage = GetComponent<Image>();
        CurrentFuel = MaxFuel;
    }

    // Update is called once per frame
    void Update()
    {
        FuelImage.fillAmount = CurrentFuel / MaxFuel;
    }
}
