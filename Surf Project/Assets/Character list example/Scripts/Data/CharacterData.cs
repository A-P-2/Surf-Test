using UnityEngine;

[CreateAssetMenu(fileName = "CharacterScriptableObject", menuName = "ScriptableObjects/Character")]
public class Character : BasicData
{
    [SerializeField] protected int level;
    [SerializeField] protected Sprite image;
    [SerializeField] protected GameObject model;

    public int Level { get => level; }
    public Sprite Image { get => image; }
    public GameObject Model { get => model; }

    public override void Interact()
    {
        Debug.Log($"Выбран персонаж {dataName}");
    }
}
