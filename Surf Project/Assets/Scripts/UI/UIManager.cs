using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Transform listContainer;
    [SerializeField] private GameObject listButtonTemplate;
    [SerializeField] private DataManager dataManager;
    [SerializeField] private InfoCard infoCard;
    [SerializeField] private Selectable[] horizontalNavigation;

    private void Start()
    {
        listButtonTemplate.SetActive(false);

        Queue<string> names = dataManager.GetListOfNames();
        GameObject firstButton = CreateButton(listButtonTemplate, listContainer, names.Dequeue());
        Button firstButtonComponent = firstButton.GetComponent<Button>();
        GameObject previousButton = firstButton;

        foreach (string buttonText in names)
        {
            GameObject currentButton = CreateButton(listButtonTemplate, listContainer, buttonText);
            LinkTwoSelectebles(previousButton.GetComponent<Selectable>(), currentButton.GetComponent<Selectable>());
            if (horizontalNavigation.Length > 0)
                LinkTwoSelectebles(currentButton.GetComponent<Selectable>(), horizontalNavigation[0], false, false);

            previousButton = currentButton;
        }
        LinkTwoSelectebles(previousButton.GetComponent<Selectable>(), firstButtonComponent);

        if (horizontalNavigation.Length > 0)
        {
            LinkTwoSelectebles(firstButtonComponent, horizontalNavigation[0], false, true);
            for (int i = 0; i < horizontalNavigation.Length - 1; i++)
            {
                LinkTwoSelectebles(horizontalNavigation[i], horizontalNavigation[i + 1], false, true);
            }
        }

        firstButtonComponent.onClick.Invoke();
        firstButtonComponent.Select();
    }

    private GameObject CreateButton(GameObject listButtonTemplate, Transform listContainer, string buttonText)
    {
        GameObject newButton = Instantiate(listButtonTemplate, listContainer);
        newButton.GetComponentInChildren<TextMeshProUGUI>().text = buttonText;
        newButton.GetComponent<Button>().onClick.AddListener(() => FillInfoCard(buttonText));
        newButton.SetActive(true);

        return newButton;
    }

    private void LinkTwoSelectebles(Selectable firstSelectable, Selectable secondSelectable, bool vertical = true, bool bothDirections = true)
    {
        if (vertical)
        {
            Navigation firstSelectableNav = firstSelectable.navigation;
            firstSelectableNav.selectOnDown = secondSelectable;
            firstSelectable.navigation = firstSelectableNav;

            if (bothDirections)
            {
                Navigation secondSelectableNav = secondSelectable.navigation;
                secondSelectableNav.selectOnUp = firstSelectable;
                secondSelectable.navigation = secondSelectableNav;
            }
        }
        else
        {
            Navigation firstSelectableNav = firstSelectable.navigation;
            firstSelectableNav.selectOnRight = secondSelectable;
            firstSelectable.navigation = firstSelectableNav;

            if (bothDirections)
            {
                Navigation secondSelectableNav = secondSelectable.navigation;
                secondSelectableNav.selectOnLeft = firstSelectable;
                secondSelectable.navigation = secondSelectableNav;
            }
        }
    }

    public void FillInfoCard(string dataName)
    {
        BasicData data = dataManager.GetData(dataName);
        infoCard.FillInfoCard(data);
    }

    public void InteractWithCurrentData() => dataManager.InteractWithCurrentData();

    public void CloseWindow() => Destroy(gameObject);
}
