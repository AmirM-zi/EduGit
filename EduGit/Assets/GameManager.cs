using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Serialization;
using Lean.Gui;

public class GameManager : MonoBehaviour
{
    public Camera camera;
    public GameObject playerprefab,player;
    public Vector3 PlayerPos;
    public Vector3 PlayerSpawn;
    public Envirement EnvirementPrefab;
    public Envirement env;
    public ShootingVehicle shootingVehicle;
    public LeanJoystick leanJsRight;
    [FormerlySerializedAs("leanJs")] [SerializeField] private LeanJoystick leanJsLeft;
    private void Start()
    { 
        env = Instantiate(EnvirementPrefab);
       player = Instantiate(this.playerprefab);
       SetPlayerStartPos(env,player);
       shootingVehicle = Instantiate(shootingVehicle);
       
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
        shootingVehicle.GetMove(PlayerPos);
        var Shooting = env.GetComponent<Shooting>();
        Shooting.MoveShootingTarget(leanJsLeft.ScaledValue,PlayerPos);
        Vector3 VehiclePos = shootingVehicle.transform.position;
        Shooting.LouncherAiming(VehiclePos);
        player.GetComponent<Player>().MoveRunner(new Vector3(leanJsRight.ScaledValue.x,leanJsRight.ScaledValue.y,1));
        
    }
    
    private void SetPlayerStartPos(Envirement env,GameObject player)
    {
        PlayerSpawn = env.PlayerSpawn.position;
        player.transform.position = PlayerSpawn;
    }

    

}
