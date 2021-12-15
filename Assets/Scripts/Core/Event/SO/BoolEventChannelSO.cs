using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBoolEvent", menuName = "Bug/Event/BoolEvent")]
public class BoolEventChannelSO : ScriptableObjectEventBase
{
    public Action<bool> onRaiseAction;

    public void Raise(bool boolean)
    {
        onRaiseAction?.Invoke(boolean);
    }
}