using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public Level level;
    public List<GameObject> Ghostobstacle;
    public GameObject JumpObstacle;
    // Start is called before the first frame update
    public void ObstaclePlace()
    {
        Vector3 Position = new Vector3(0, 0, 0);
        for (int i = 0; i <= 100; i++)
        {
             Position.z = Random.Range(0, 5000);
             Position.x = Random.Range(-15, 15);
             Position.y = Random.Range(0, 5);
             Instantiate(Ghostobstacle[Random.Range(0,6)],Position,Quaternion.Euler(0,0,0)); 
        }
        for (int i = 0; i <= 50; i++)
        {
            Position.x = Random.Range(-15, 15);
            Position.z = Random.Range(0, 5000); 
            Instantiate(JumpObstacle,Position,Quaternion.Euler(0,0,0)); 
        }
    }
}
