using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //public Coin CoinCatch;
    //public Obstacle Obstacle;
    public Rigidbody Rigidbody;
    public float speed;
    public int Hlth,coin;
    public string ObstacleTag,EndLineTag,Coin,Ground;
    public Vector3 movement;
    public Action OnEndLine,OnGetPoint,gameOver;
    public bool GroundCheck=true;
    public Animator animator;
    private int flag;
    

    public void MoveRunner(Vector3 direction)
    {
        Vector3 control = new Vector3(direction.x, 0, direction.z);
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
        /*if(collision.gameObject.tag==Coin)
        {
            coin = coin + 1;
            Coin ClollidedCoin = collision.gameObject.GetComponent<Coin>();
            ClollidedCoin.CoinCatch();
            OnGetPoint.Invoke();
        }*/
        if(collision.gameObject.tag==EndLineTag)
        {
            Destroy(this.gameObject); 
            OnEndLine.Invoke();
        }

        if (collision.gameObject.tag == Ground)
        {
            GroundCheck = true;
        }

        /*if (collision.gameObject.tag == ObstacleTag)
        {
            Obstacle ClollidedObstacle = collision.gameObject.GetComponent<Obstacle>();
            ClollidedObstacle.DestroyYourself();
            Hlth = Hlth - 1;
            Debug.Log(Hlth);
            if (Hlth == 0)
                gameOver.Invoke();
        }*/
    }
    private void OnCollisionExit(Collision collision)
    {
        
        if (collision.gameObject.tag == Ground)
        {
            animator.SetTrigger("Jump");
            GroundCheck = false;
        }
    }
}