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
    
    void FixedUpdate()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, 1);
        MoveRunner(movement);
        if (Input.GetKey(KeyCode.Space) && GroundCheck)
        {
            
            Rigidbody.AddForce(new Vector3(0, 30, -3) * speed * Time.deltaTime, ForceMode.Impulse);
        }

    }
    
    void MoveRunner(Vector3 direction)
    {
        var move = (transform.position + (direction * speed * Time.deltaTime));
        var pos = transform.position;
        if (Mathf.Abs(pos.x) >= 10)
        {
            direction.x = -pos.x*0.01f;
            var an = (transform.position + (direction * speed * Time.deltaTime));
            Rigidbody.MovePosition(an);
            return;
        }
        Rigidbody.MovePosition(move);
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        Debug.Log(GroundCheck);
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
            Debug.Log(GroundCheck);
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
        Debug.Log("zamin");
        if (collision.gameObject.tag == Ground)
            GroundCheck = false;
    }
}