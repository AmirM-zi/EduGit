using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rod : MonoBehaviour
{
    public float MovementAmount, SpeedRod = 0.05f;

    private void FixedUpdate()
    {
        if ((MovementAmount >= 10)||(MovementAmount <= 0))   
            SpeedRod = -SpeedRod;
        
        MovementAmount -= SpeedRod;
        transform.position = new Vector3(MovementAmount, transform.position.y, transform.position.z);
    }
    
}
