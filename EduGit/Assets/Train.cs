using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    private Transform transform;
    public void GetMove(Vector3 pos)
    {
        transform = GetComponent<Transform>();
        transform.SetPositionAndRotation(new Vector3(-50,0,pos.z+150),Quaternion.Euler(0,0,0));
    }

}
