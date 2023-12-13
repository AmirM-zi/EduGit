using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public void CameraMover(Vector3 pos)
    { 
        transform.SetPositionAndRotation(new Vector3(pos.x,pos.y+40,pos.z-50),Quaternion.Euler(5,0,0));
    }
}
