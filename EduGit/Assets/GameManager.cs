using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Serialization;
using Lean.Gui;
using TMPro;
using UnityEditor;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public Camera camera;
    public GameObject Menu,Game,player,env,shootingvehicle,lvl;
    public Player playerprefab;
    public Vector3 PlayerPos;
    public Vector3 PlayerSpawn;
    public Envirement EnvirementPrefab;
    public ShootingVehicle shootingVehicle;
    public LeanJoystick leanJsRight;
    public LeanJoystick leanJsLeft;
    public SaveManager saveManager;
    public int point,Health;
    public TextMeshProUGUI showpoint,showHelth;
    private RoadSpawner roadSpawner;
    public Level level;
    

    private void Start()
    {
        Game.SetActive(false);
    }

    public void Play()
    { 
        Game.SetActive(true);
        Menu.SetActive(false); 
       env = Instantiate(EnvirementPrefab.gameObject);
       player = Instantiate(playerprefab.gameObject);
       SetPlayerStartPos(EnvirementPrefab,player);
       shootingvehicle = Instantiate(shootingVehicle.gameObject);
       player.GetComponent<Player>().OnGetPoint += GetPoints;
       player.GetComponent<Player>().OnObctacle += DecreasHealth;
       player.GetComponent<Player>().OngameOver += GameOver;
       player.GetComponent<Player>().OnRoadSpawn += RoadSpawn;
       point = saveManager.LoadFromJson();
       level.ObstaclePlace();
       lvl = Instantiate(level.gameObject);
    }
    public void GameOver()
    {
        Health = 5;
        Menu.SetActive(true);
        Game.SetActive(false);
        Destroy(player);
        Destroy(env);
        Destroy(shootingvehicle);
        Destroy(lvl);
        GetComponent<RoadSpawner>().ResetRoads();
        saveManager.SaveToJson(point);

    }

    private void GetPoints()
    {
        point += 1;
        Health += 1;
    }

    private void DecreasHealth()
    {
        Health -= 1;
        if (Health<=0)
            GameOver();
    }

    public void ResetPoints()
    {
        saveManager.ResetData();
    }

    void RoadSpawn()
    {
        GetComponent<RoadSpawner>().MoveRoad();
    }
    private void Update()
    {
        showpoint.text = "Point:"+point.ToString();
        showHelth.text = "Health:"+Health.ToString();
        try
        { 
            PlayerPos = player.transform.position;
            camera.CameraMover(PlayerPos);
        }
        catch (Exception)
        {
            return;
        }
        shootingvehicle.transform.SetPositionAndRotation(new Vector3(-50,0,PlayerPos.z+200),Quaternion.Euler(0,0,0));
        env.GetComponent<Shooting>().MoveShootingTarget(leanJsLeft.ScaledValue,PlayerPos);
        Vector3 VehiclePos = shootingvehicle.transform.position;
        env.GetComponent<Shooting>().LauncherPos(VehiclePos);
        player.GetComponent<Player>().MoveRunner(new Vector3(leanJsRight.ScaledValue.x,leanJsRight.ScaledValue.y,1));
        
    }
    
    private void SetPlayerStartPos(Envirement env,GameObject player)
    {
        PlayerSpawn = env.PlayerSpawn.position;
        player.transform.position = PlayerSpawn;
    }

    
}
