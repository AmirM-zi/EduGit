using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    //public Coin CoinCatch;
    //public Obstacle Obstacle;
    public Rigidbody Rigidbody;
    public float speed;
    public int Hlth;
    public Action OnGetPoint,gameOver;
    public bool GroundCheck=true;
    public Animator animator;
    private int flag;
    public TextMeshProUGUI ShowPoint;
    

    public void MoveRunner(Vector3 direction)
    {
        Vector3 control = new Vector3(direction.x*1.5f, 0, direction.z);
        var move = (transform.position + (control * speed * Time.deltaTime));
        var pos = transform.position;
        if ((direction.y>=0.9) && GroundCheck)
        {
            Rigidbody.AddForce(new Vector3(0,120, -3) * 10 * Time.deltaTime, ForceMode.Impulse);
        }
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
            gameOver.Invoke();
        }

        if (collision.gameObject.tag == "Ground")
        {
            GroundCheck = true;
        }

        if (collision.gameObject.tag == "Obstacle")
        {
            Obstacle ClollidedObstacle = collision.gameObject.GetComponent<Obstacle>();
            ClollidedObstacle.DestroyYourSelf();
            Hlth -= 1;
            if (Hlth <= 0)
                gameOver.Invoke();
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            animator.SetTrigger("Jump");
            GroundCheck = false;
        }
    }
}