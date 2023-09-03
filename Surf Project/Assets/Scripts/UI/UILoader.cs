using UnityEngine;

public class UILoader : MonoBehaviour
{
    public void LoadWindow(string path)
    {
        GameObject window = Resources.Load<GameObject>(path);
        Instantiate(window, transform);
    }
}
