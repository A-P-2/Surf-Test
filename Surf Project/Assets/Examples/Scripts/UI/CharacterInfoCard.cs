using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInfoCard : InfoCard
{
    [SerializeField] private TextMeshProUGUI characterNameText;
    [SerializeField] private TextMeshProUGUI characterLevelText;
    [SerializeField] private Image character2DImage;
    [SerializeField] private Transform character3DModelRotator;

    public override void FillInfoCard(BasicData data)
    {
        CharacterData characterData = data as CharacterData;
        characterNameText.text = characterData.DataName;
        characterLevelText.text = $"Уровень: {characterData.Level}";
        character2DImage.sprite = characterData.Image;

        foreach (Transform child in character3DModelRotator)
        {
            Destroy(child.gameObject);
        }
        Instantiate(Resources.Load<GameObject>(characterData.ModelPath), character3DModelRotator);
    }
}
