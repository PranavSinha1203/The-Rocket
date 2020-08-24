using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    // Start is called before the first frame update
    public static RocketController instance;
    Rigidbody2D Rocket_Rb;
    public float Force;
    public float RotateSpeed;
    AudioSource ThrustAudio;
    public AudioClip DaimondSound;
    public AudioClip FuelSound;
    public AudioClip HitSound;
    public AudioClip DieSound;
    public AudioClip BlastSound;
    public AudioClip HealthSound;
    public ParticleSystem RocketThrust;
    public ParticleSystem DaimondParticle;
    public ParticleSystem HitEffect;
    public ParticleSystem HealthEffect;
    public ParticleSystem FuelEffect;
    public ParticleSystem MegaStarEffect1;
    public ParticleSystem CrackersEffect;
    public ParticleSystem[] PlayerBlast;
    public Transform LevelComplete;
    public Transform CrackersPos;
    public GameObject LevelCompleteTrigger;
    public float Damage;
    public float FuelConsume;
    bool ThrustButton;
    public bool PlayerDead;
    bool LeftRotateButton, RightRotateButton;
    public float FuelIncrement, HealthIncrement;
    Vector3 PlayerDiePos;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }

    void Start()
    {
        Rocket_Rb = GetComponent<Rigidbody2D>();
        ThrustAudio = GetComponent<AudioSource>();
        ThrustButton = false;
        LeftRotateButton = false;
        RightRotateButton = false;
        PlayerDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!PlayerDead && !GameManager.instance.LevelComplete)
        {
            ThrustForce();
            LeftRotate();
            RightRotate();
        }
        PlayerDiePos = transform.position;
      
    }

    public void ThrustButtonUp()
    {
        ThrustButton = false;
    }

    public void ThrustButtonDown()
    {
        ThrustButton = true;
    }

    public void RightRotateButtonUp()
    {
        RightRotateButton = false;
    }

    public void RightRotateButtonDown()
    {
        RightRotateButton = true;
    }

    public void LeftRotateButtonUp()
    {
        LeftRotateButton = false;
    }
    public void LeftRotateButtonDown()
    {
        LeftRotateButton = true;
    }


    public void ThrustForce()
    {
        if(ThrustButton)                                              //Thrust function
        {
            Rocket_Rb.AddRelativeForce(Vector2.up * Force);
            if(!ThrustAudio.isPlaying)
            {
                ThrustAudio.Play();
                RocketThrust.Play();
                if(Fuel.instance.CurrentFuel<=0)
                {
                    WhenPlayerDie();
                }
                else
                {
                    Fuel.instance.CurrentFuel -= FuelConsume;  
                }  
            }
        }
        else
        {
            ThrustAudio.Stop();
            RocketThrust.Stop();
        }
        
    }

    void RightRotate()                                             //Rotate right function
    {
        Rocket_Rb.freezeRotation = true;
        if(RightRotateButton)
        {
            transform.Rotate(0, 0, -RotateSpeed * Time.deltaTime);
        }
        Rocket_Rb.freezeRotation = false; 
    }

    void LeftRotate()                                              //Rotate left function
    {
        Rocket_Rb.freezeRotation = true;
        if (LeftRotateButton)
        {
            transform.Rotate(0, 0, RotateSpeed * Time.deltaTime);
        }
        Rocket_Rb.freezeRotation = false;
    }

    void WhenPlayerDie()
    {
        PlayerDead = true;
        Rocket_Rb.drag = 0f;
        Rocket_Rb.gravityScale = 2f;
        AudioSource.PlayClipAtPoint(DieSound, transform.position);
        ThrustAudio.Stop();
        RocketThrust.Stop();
        Destroy(gameObject, 2f);
       
    }

    void DaimondParticleEffect()
    {
        ParticleSystem Particle = Instantiate(DaimondParticle, transform.position, Quaternion.identity);
        Destroy(Particle, 2f);
    }

    void FuelParticleEffect()
    {
        ParticleSystem Particle = Instantiate(FuelEffect, transform.position, Quaternion.identity);
        Destroy(Particle, 2f);
    }

    void HitParticleEffect()
    {
        ParticleSystem Particle = Instantiate(HitEffect, transform.position, Quaternion.identity);
        Destroy(Particle, 2f);
    }

    void HealthParticleEffect()
    {
        ParticleSystem Particle = Instantiate(HealthEffect, transform.position, Quaternion.identity);
        Destroy(Particle, 2f);
    }

    void MegaStarParticleEffect()
    {
        ParticleSystem Particle = Instantiate(MegaStarEffect1, transform.position, Quaternion.identity);
        Destroy(Particle, 2f);
    }


    void OnTriggerEnter2D(Collider2D col)
    { 
     
            if (col.gameObject.layer == 11 && !PlayerDead)
            {
                Destroy(col.gameObject);
                DaimondParticleEffect();
                AudioSource.PlayClipAtPoint(DaimondSound, transform.position);
                UIManager.instance.TotalDaimonds -= 1;
                
            }

            if (col.gameObject.layer == 15 && !PlayerDead)
            {
                Destroy(col.gameObject);
                MegaStarParticleEffect();
                AudioSource.PlayClipAtPoint(DaimondSound, transform.position);
                UIManager.instance.TotalMegastar -= 1;
            }

            if (col.gameObject.layer == 14 && !PlayerDead)
            {
                Destroy(col.gameObject);
                HealthParticleEffect();
                AudioSource.PlayClipAtPoint(HealthSound, transform.position);
                if (Health.instance.CurrentHealth <= 75)
                {
                    Health.instance.CurrentHealth += HealthIncrement;
                }
                else if (Health.instance.CurrentHealth > 75)
                {
                    float health = 100 - Health.instance.CurrentHealth;
                    Health.instance.CurrentHealth += health;
                }
            }


            if (col.gameObject.layer == 13 && !PlayerDead)
            {
                Destroy(col.gameObject);
                FuelParticleEffect();
                AudioSource.PlayClipAtPoint(FuelSound, transform.position);
                if (Fuel.instance.CurrentFuel <= 80)
                {
                    Fuel.instance.CurrentFuel += FuelIncrement;
                }
                else if (Fuel.instance.CurrentFuel > 80)
                {
                    float fuel = 100 - Fuel.instance.CurrentFuel;
                    Fuel.instance.CurrentFuel += fuel;
                }

            }

            if(col.gameObject.layer == 17 && !PlayerDead)
           {
               if (UIManager.instance.TotalDaimonds <= 0 && UIManager.instance.TotalMegastar <= 0)
               {
                Instantiate(LevelCompleteTrigger, LevelComplete.position, Quaternion.identity);

               }
            }
   

        if (col.gameObject.layer == 16 && !PlayerDead)
        {
            GameManager.instance.LevelComplete = true;
            Instantiate(CrackersEffect, CrackersPos.position, Quaternion.identity);
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(!GameManager.instance.LevelComplete)
        {
            if (col.gameObject.layer == 9 && !PlayerDead)
            {
                AudioSource.PlayClipAtPoint(HitSound, transform.position);
                HitParticleEffect();
                if (Health.instance.CurrentHealth <= 0)
                {
                    WhenPlayerDie();
                }
                else
                {
                    Health.instance.CurrentHealth -= Damage;
                }

            }
        }
       
    }


    private void OnDestroy()
    {
        if(!GameManager.instance.LevelComplete && PlayerDead)
        {
            for (int i = 0; i < 2; i++)
            {
                Instantiate(PlayerBlast[i], PlayerDiePos, Quaternion.identity);
            }
            AudioSource.PlayClipAtPoint(BlastSound, PlayerDiePos);
        }
        
        
    }
}
