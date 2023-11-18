using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public void CameraMover(Vector3 pos)
    { 
        transform.SetPositionAndRotation(new Vector3(pos.x,pos.y+100,pos.z-100),Quaternion.Euler(35,0,0));
    }
}
