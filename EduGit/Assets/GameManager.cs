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
public class GameManager : MonoBehaviour
{
    public Camera camera;
    public GameObject FirstPage,player,env,shootingvehicle;
    public Player playerprefab;
    public Vector3 PlayerPos;
    public Vector3 PlayerSpawn;
    public Envirement EnvirementPrefab;
    public ShootingVehicle shootingVehicle;
    public LeanJoystick leanJsRight;
    public LeanJoystick leanJsLeft;
    private SaveManager saveManager;
    public int point;
    public TextMeshProUGUI showpoint,showHelth;
    
    public void Play()
    { 
        FirstPage.SetActive(false); 
       env = Instantiate(EnvirementPrefab.gameObject); 
       player = Instantiate(playerprefab.gameObject);
       SetPlayerStartPos(EnvirementPrefab,player);
       shootingvehicle = Instantiate(shootingVehicle.gameObject);
       player.GetComponent<Player>().OnGetPoint += GetPoints;
       player.GetComponent<Player>().gameOver += GameOver;
       //point = saveManager.LoadFromJson();
       
    }
    public void GameOver()
    { 
        FirstPage.SetActive(true);
        Destroy(player);
        Destroy(env);
        Destroy(shootingvehicle);
       // saveManager.SaveToJson(point);

    }

    private void GetPoints()
    {
        point += 1;
    }

    public void ResetPoints()
    {
        //saveManager.ResetData();
    }
    private void Update()
    {
        showpoint.text = point.ToString();
        showHelth.text = playerprefab.Hlth.ToString();
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
        var Shooting = EnvirementPrefab.GetComponent<Shooting>();
        Shooting.MoveShootingTarget(leanJsLeft.ScaledValue,PlayerPos);
        Vector3 VehiclePos = shootingvehicle.transform.position;
        Shooting.LauncherPos(VehiclePos);
        player.GetComponent<Player>().MoveRunner(new Vector3(leanJsRight.ScaledValue.x,leanJsRight.ScaledValue.y,1));
        
    }
    
    private void SetPlayerStartPos(Envirement env,GameObject player)
    {
        PlayerSpawn = env.PlayerSpawn.position;
        player.transform.position = PlayerSpawn;
    }

    
}
