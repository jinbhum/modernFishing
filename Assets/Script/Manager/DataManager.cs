using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyFactory.Game.Data;


public class DataManager : MonoBehaviourSingleton<DataManager>
{
    private List<System.Action> tableList = new List<System.Action>();

    private Dictionary<int, FishData> fishInfoDictionary = new Dictionary<int, FishData>();
    public Dictionary<int, FishData> FishInfoDictionary { get { return fishInfoDictionary; } }


    public void ReadAllTable()
    {
        tableList.Clear();
        tableList.Add(ReadFishInformation);

        for (int i = 0; i < tableList.Count; i++)
        {
            tableList[i]();
        }
    }

    public void ReadFishInformation()
    {
        CSVReader.instance.ReadNew("Table/table_fish",
        data =>
        {
            for (int i = 0; i < data.Count; i++)
            {
                FishData fishInfo = new FishData();

                int index = int.Parse((data[i]["index"]).ToString());

                if (fishInfoDictionary.ContainsKey(index) == false)
                {
                    fishInfo.fishName = (data[i]["Name"]).ToString();
                    fishInfo.spriteName = (data[i]["SpriteName"]).ToString();
                    fishInfo.moveSpeed = float.Parse((data[i]["MoveSpeed"]).ToString());
                    fishInfo.weight = int.Parse((data[i]["Weight"]).ToString());
                    fishInfo.size = int.Parse((data[i]["Size"]).ToString());
                    fishInfo.hitCount = int.Parse((data[i]["HitCount"]).ToString());

                    fishInfoDictionary.Add(index, fishInfo);
                }
            }
        });
    }


    public FishData GetFishInformation(int index)
    {
        if (fishInfoDictionary.ContainsKey(index) == true)
        {
            return fishInfoDictionary[index];
        }

        return null;
    }
}



