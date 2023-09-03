using UnityEngine;

[CreateAssetMenu(fileName = "CharacterScriptableObject", menuName = "ScriptableObjects/Character")]
public class CharacterData : BasicData
{
    [SerializeField] protected int level;
    [SerializeField] protected Sprite image;
    [SerializeField] protected string modelPath;

    public int Level { get => level; }
    public Sprite Image { get => image; }
    public string ModelPath { get => modelPath; }

    public override void Interact()
    {
        Debug.Log($"Выбран персонаж \"{dataName}\"");
    }
}
