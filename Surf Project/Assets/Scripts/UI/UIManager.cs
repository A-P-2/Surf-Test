using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Transform listContainer;
    [SerializeField] private GameObject listButtonTemplate;
    [SerializeField] private Transform infoContainer;
    [SerializeField] private DataManager dataManager;
    [SerializeField] private InfoCard infoCard;

    private void Start()
    {
        Queue<string> names = dataManager.GetListOfNames();

        foreach (string name in names)
        {
            GameObject newButton = Instantiate(listButtonTemplate, listContainer);
            newButton.GetComponentInChildren<TextMeshProUGUI>().text = name;
            newButton.GetComponent<Button>().onClick.AddListener(() => FillInfoCard(name));
        }

        listButtonTemplate.SetActive(false);
    }

    public void FillInfoCard(string dataName)
    {
        BasicData data = dataManager.GetData(dataName);
        infoCard.FillInfoCard(data);
    }

    public void InteractWithCurrentData() => dataManager.InteractWithCurrentData();
}
