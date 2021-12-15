using UnityEngine;

public class SingletonMono<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T GetInstance { get; private set; }

    protected virtual void Awake()
    {
        GetInstance = this as T;
    }
}