using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewVoidEvent", menuName = "Bug/Event/VoidEvent")]
public class StringEventChannelSO : ScriptableObjectEventBase
{
    public Action<string> onRaiseAction;

    public void Raise(string str)
    {
        onRaiseAction?.Invoke(str);
    }
}