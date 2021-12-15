using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewIntEvent", menuName = "Bug/Event/IntEvent")]
public class IntEventChannelSO : ScriptableObjectEventBase
{
    public Action<int> onRaiseAction;

    public void Raise(int index)
    {
        onRaiseAction?.Invoke(index);
    }
}