using UnityEngine;

public abstract class BasicData : ScriptableObject
{
    [SerializeField] protected string dataName;
    public string DataName { get => dataName; }

    public abstract void Interact();
}
