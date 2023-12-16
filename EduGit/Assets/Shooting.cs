using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using DG.Tweening;
using Lean.Gui;
using UnityEngine;
using UnityEngine.Serialization;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class Shooting : MonoBehaviour
{
    public GameObject Bullet,ShootPoint,ShootingWeapon;

    public void Shoot(Vector3 Target)
    {
        Vector3 ShootSpot = ShootingWeapon.transform.position;
        GameObject bullet = Instantiate(Bullet,ShootSpot,Quaternion.Euler(0,0,0));
        bullet.transform.DOMove(new Vector3(Target.x,Target.y,Target.z+200), 1f).OnComplete(() => Destroy(bullet));
    }

    public void MoveShootingTarget(Vector2 JoyStickValue,Vector3 Pos)
    {
        Vector3 JoyStickValueV3 = new Vector3(JoyStickValue.x,JoyStickValue.y,0 );
        Vector3 SP = ShootPoint.transform.position;
        var move = new Vector3(SP.x,SP.y,Pos.z+300) + (JoyStickValueV3 * 300f * Time.deltaTime);//Shoot Point limit Surface and speed
        ShootPoint.GetComponent<Rigidbody>().MovePosition(move);
        if (Mathf.Abs(SP.x) >= 18)
        {
            var an = (SP + (new Vector3(-SP.x,0,0) * 5f * Time.deltaTime));
            ShootPoint.GetComponent<Rigidbody>().MovePosition(an);
        }
        if (Mathf.Abs(SP.y) >= 18)
        {
            var an = (SP + (new Vector3(0,-SP.y,0) * 5f * Time.deltaTime));
            ShootPoint.GetComponent<Rigidbody>().MovePosition(an);
        }
    }
    void FixedUpdate()
    {
        Shoot(ShootPoint.transform.position);
    }

    public void LauncherPos(Vector3 pos)
    {
        ShootingWeapon.transform.SetPositionAndRotation(new Vector3(pos.x+5,pos.y+30,pos.z-150) ,Quaternion.identity);
    }
}
