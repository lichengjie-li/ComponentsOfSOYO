using UnityEngine;

public class SingletonMono<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T GetInstance
    {
        get
        {
            if (_instance != null) return _instance;
            var go = new GameObject { name = typeof(T).ToString() };

            DontDestroyOnLoad(go);
            _instance = go.AddComponent<T>();

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }
}