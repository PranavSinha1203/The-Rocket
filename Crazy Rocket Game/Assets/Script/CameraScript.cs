using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Rocket;
    public Vector3 offset;
    public float LerpRate;
    public Vector2 MinPos;
    public Vector2 MaxPos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(!RocketController.instance.PlayerDead)
        {
            Vector3 TargetPos = new Vector3(Rocket.position.x, Rocket.position.y, transform.position.z);
            TargetPos.x = Mathf.Clamp(TargetPos.x, MinPos.x, MaxPos.x);
            TargetPos.y = Mathf.Clamp(TargetPos.y, MinPos.y, MaxPos.y);
            transform.position = Vector3.Lerp(transform.position, TargetPos, LerpRate);
        }
        
    }
}
