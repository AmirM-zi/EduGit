using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    //public Coin CoinCatch;
    //public Obstacle Obstacle;
    public Rigidbody Rigidbody;
    public float speed;
    public int Hlth;
    public Action OnGetPoint,OngameOver,OnObctacle,OnRoadSpawn;
    public Animator animator;
    private int flag;
    public TextMeshProUGUI ShowPoint;
    private bool GC;
    

    public void MoveRunner(Vector3 direction)
    {
        Vector3 control = new Vector3(direction.x, 0, direction.z);
        var move = (transform.position + (control * speed * Time.deltaTime)); 
        var pos = transform.position;
        bool flag = true;
        GC = GroundCheck();
        //if ((direction.y>=0.8) && GroundCheck && flag)
        if (Input.GetKey(KeyCode.A) && GC && flag)
        {
            flag = false;
            Physics.gravity = new Vector3(0, -100, 0);
            animator.SetTrigger("Jump");
            Rigidbody.velocity = new Vector3(0,10, 0) ;
            //Rigidbody.AddForce(new Vector3(0,120, -3) * 10 * Time.deltaTime, ForceMode.Impulse);
            //transform.DOMove(new Vector3(pos.x,pos.y+3,pos.z+20), 0.5f);
            flag = true; 
        }
        Physics.gravity = new Vector3(0, -9.8f, 0);
        if (Mathf.Abs(pos.x) >= 16)
        {
            control.x = -pos.x*0.01f;
            var an = (transform.position + (control * speed * Time.deltaTime));
            Rigidbody.MovePosition(an);
            
            return;
        }
        Rigidbody.MovePosition(move);
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if(collision.gameObject.tag=="Point")
        {
            Point ClollidedPoint = collision.gameObject.GetComponent<Point>();
            ClollidedPoint.PointCatch();
            OnGetPoint.Invoke();
        }
        if(collision.gameObject.tag=="EndLineTag")
        {
            OngameOver.Invoke();
        }
        

        if (collision.gameObject.tag == "Obstacle")
        {
            Obstacle ClollidedObstacle = collision.gameObject.GetComponent<Obstacle>();
            ClollidedObstacle.DestroyYourSelf();
            OnObctacle.Invoke();
        }
    }
    private bool GroundCheck()
    {
        Vector3 dwn = transform.TransformDirection(Vector3.down);
        if (Physics.Raycast(transform.position, dwn, 0.6f))
            GC = true;
        else
            GC = false;
        return GC;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "RoadSpawn")
        {
            OnRoadSpawn.Invoke();
        }
    }
}