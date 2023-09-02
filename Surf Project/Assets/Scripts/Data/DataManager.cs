using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataManagerScriptableObject", menuName = "ScriptableObjects/DataManager")]
public class DataManager : ScriptableObject
{
    [SerializeField] private string dataPath;

    private readonly Dictionary<string, string> dataFileNames = new Dictionary<string, string>();
    private BasicData currentData = null;

    public Queue<string> GetListOfNames()
    {
        Queue<string> dataNames = new Queue<string>();
        BasicData[] datas = Resources.LoadAll<BasicData>(dataPath);

        foreach (BasicData data in datas)
        {
            dataFileNames.Add(data.DataName, data.name);

            dataNames.Enqueue(data.DataName);
            Resources.UnloadAsset(data);
        }

        return dataNames;
    }

    public BasicData GetData(string dataName)
    {
        Resources.UnloadAsset(currentData);

        currentData = Resources.Load<BasicData>($"{dataPath}/{dataFileNames[dataName]}");
        return currentData;
    }

    public void InteractWithCurrentData() => currentData.Interact();
}
