using System;
using UnityEngine;
using File = System.IO.File;
using Input = UnityEngine.Input;


public class SaveManager : MonoBehaviour
{
    public void SaveToJson(int point)
    {
        DataBox data = new DataBox();
        data.point = point;
        string Json = JsonUtility.ToJson(data, true);
        File.WriteAllText(Application.dataPath + "/DataBox.json",Json);
    }

    public int LoadFromJson()
    {
        try
        {
            string Json = File.ReadAllText(Application.dataPath + "/DataBox.json");
            DataBox data = JsonUtility.FromJson<DataBox>(Json);
            return data.point;
        }
        catch (Exception)
        {
            return 0;
        }
    }

    public void ResetData()
    {
        File.Delete(Application.dataPath + "/DataBox.json");
    }
    
    
}