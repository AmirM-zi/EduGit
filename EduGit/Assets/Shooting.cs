using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Lean.Gui;
using UnityEngine;
using UnityEngine.Serialization;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class Shooting : MonoBehaviour
{
    public GameObject Bullet,ShootingSpot,ShootingWeapon,ShootPoint;
    private GameObject ShootingWeaponSpot,bullet;
    public Vector3 PlayerPos,SS;
    private void Start()
    {
        Vector3 SS = ShootingSpot.transform.position;
        ShootingWeaponSpot = Instantiate(ShootingWeapon,SS,ShootingSpot.transform.rotation);
    }

    public void Shoot(Vector3 pos,Quaternion rot)
    { 
        bullet = Instantiate(Bullet,ShootingWeaponSpot.transform.position,Quaternion.Euler(0,0,0));
       bullet.GetComponent<Rigidbody>().AddForce(Mathf.Sin(rot.y)*10000, 0, Mathf.Cos(rot.y)*10000);
        Debug.Log(rot.y);
    }

    public void MoveShootingTarget(Vector2 JoyStickValue,Vector3 Pos)
    {
        Vector3 JoyStickValueV3 = new Vector3(JoyStickValue.x,0 , JoyStickValue.y);
        Vector3 SP = ShootPoint.transform.position;
        var move = (new Vector3(SP.x,SP.y,(JoyStickValue.y*20)+Pos.z+50) + (JoyStickValueV3 * 200f * Time.deltaTime));
        //ShootPoint.transform.SetPositionAndRotation(move,Quaternion.identity);
        ShootPoint.GetComponent<Rigidbody>().MovePosition(move);
        if (Mathf.Abs(SP.x) >= 18)
        {
            var an = (SP + (new Vector3(-SP.x,0,0) * 5f * Time.deltaTime));
            ShootPoint.GetComponent<Rigidbody>().MovePosition(an);
        }
    }
    void FixedUpdate()
    {
        
        Quaternion movement = Quaternion.Euler(0,0,0);
        if (Input.GetKey(KeyCode.DownArrow))
            movement = Quaternion.Euler(0, movement.y-90, 0);
        if (Input.GetKey(KeyCode.UpArrow))
            movement = Quaternion.Euler(0, movement.y+90, 0);
        LouncherAiming(SS);
        if (Input.GetKey(KeyCode.C))
        {
            Shoot(ShootingWeaponSpot.transform.position,ShootingWeaponSpot.transform.rotation);
        }

        try
        {
            if (bullet.transform.position.x >= 500)
            {
                Destroy(bullet);
            }
        }
        catch (Exception)
        {
        }
        
    }

    public void LouncherAiming(Vector3 pos)
    {
       //var rotated = new Vector3(Louncher.transform.rotation.x,Louncher.transform.rotation.y,Louncher.transform.rotation.z);
        //ShootingWeaponSpot.transform.SetPositionAndRotation(ShootingWeaponSpot.transform.position,rot);new Vector3(SS.x,SS.y,pos.z-10)
        ShootingWeaponSpot.transform.SetPositionAndRotation(new Vector3(pos.x,pos.y,pos.z-150) ,ShootingSpot.transform.rotation);
    }
}
