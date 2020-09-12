using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    public static Health instance;
    Image HealthImage;
    float MaxHealth = 100f;
    [HideInInspector]
    public float CurrentHealth;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }
    void Start()
    {
        HealthImage = GetComponent<Image>();
        CurrentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        HealthImage.fillAmount = CurrentHealth / MaxHealth; 
    }
}
