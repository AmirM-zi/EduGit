using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public Level level;
    public List<GameObject> obstacle;
    // Start is called before the first frame update
    public void ObstaclePlace()
    {
        Vector3 Position = new Vector3(0, 0, 0);
        for (int i = 0; i <= 100; i++)
        {
             Position.z = Random.Range(0, 5000);
             Position.x = Random.Range(-10, 10);
             Position.y = Random.Range(0, 5);
             Instantiate(obstacle[Random.Range(0,6)],Position,Quaternion.Euler(0,0,0));
        }
    }
}
