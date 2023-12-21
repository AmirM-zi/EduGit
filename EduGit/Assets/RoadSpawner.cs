using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public List<GameObject> Roads;
    void Start()
    {
        if (Roads != null)
        {
            Roads = Roads.OrderBy(r => r.transform.position.z).ToList();
        }
    }

    public void MoveRoad()
    {
        GameObject movedRoad = Roads[0];
        Roads.Remove(movedRoad);
        float newZ = Roads[Roads.Count - 1].transform.position.z + 420;
        movedRoad.transform.position = new Vector3(0, 0, newZ);
        Roads.Add(movedRoad);
    }

    public void ResetRoads()
    {
        for (int i = 0; i < Roads.Count; i++)
        {
            Roads[i].transform.SetPositionAndRotation(new Vector3(0,0,i*500),Quaternion.identity);
        }
    }
    

}
