using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LocationInfoCard : InfoCard
{
    [SerializeField] private TextMeshProUGUI locationNameText;
    [SerializeField] private TextMeshProUGUI locationDescriptionText;
    [SerializeField] private Image locationImage;

    public override void FillInfoCard(BasicData data)
    {
        LocationData locationData = data as LocationData;
        locationNameText.text = locationData.DataName;
        locationDescriptionText.text = locationData.Description;
        locationImage.sprite = locationData.Image;
    }
}
