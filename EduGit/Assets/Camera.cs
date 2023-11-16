using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public void CameraMover(Vector3 pos)
    { 
        transform.SetPositionAndRotation(new Vector3(pos.x,pos.y+20,pos.z-25),Quaternion.Euler(20,0,0));
    }
}
