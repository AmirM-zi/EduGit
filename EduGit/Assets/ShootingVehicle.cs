using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingVehicle : MonoBehaviour
{
    private Transform transform;
    public void GetMove(Vector3 pos)
    {
        transform = GetComponent<Transform>();
        transform.SetPositionAndRotation(new Vector3(-50,0,pos.z+200),Quaternion.Euler(0,0,0));
    }
    
    
    
}
