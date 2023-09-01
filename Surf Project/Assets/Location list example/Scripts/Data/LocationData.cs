using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "LocationScriptableObject", menuName = "ScriptableObjects/Location")]
public class LocationData : BasicData
{
    [SerializeField] [TextArea(3, 10)] protected string description;
    [SerializeField] protected Sprite image;
    [SerializeField] protected int sceneID;

    public string Description { get => description; }
    public Sprite Image { get => image; }
    public int SceneID { get => sceneID; }

    public override void Interact()
    {
        //SceneManager.LoadScene(SceneID);
        Debug.Log($"Запуск сцены {dataName}");
    }
}
