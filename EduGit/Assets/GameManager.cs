using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public Camera camera;
    public GameObject playerprefab;
    public GameObject player;
    public Vector3 PlayerPos;
    public Vector3 PlayerSpawn;
    public Envirement Envirement;
    private void Start()
    { 
        var env = Instantiate(Envirement);
       player = Instantiate(this.playerprefab);
       SetPlayerStartPos(env,player);
    }

    private void Update()
    {
        PlayerPos = player.transform.position;
        try
        { 
            camera.CameraMover(PlayerPos);
        }
        catch (Exception)
        {
            return;
        }
      
    }
    
    private void SetPlayerStartPos(Envirement env,GameObject player)
    {
        PlayerSpawn = env.PlayerSpawn.position;
        player.transform.position = PlayerSpawn;
    }

    

}
