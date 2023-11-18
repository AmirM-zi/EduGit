using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject Bullet;
    public void Shoot(Vector3 pos)
    {
       GameObject bullet = Instantiate(Bullet,new Vector3(-33,28,pos.z+10),Quaternion.Euler(0,45,0));
        bullet.GetComponent<Rigidbody>().AddForce(10000,0,10000);
        Debug.Log("Shooting");
    }
}
