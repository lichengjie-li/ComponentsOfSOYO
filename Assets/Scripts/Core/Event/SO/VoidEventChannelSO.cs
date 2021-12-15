using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewVoidEvent", menuName = "Bug/Event/VoidEvent")]
public class VoidEventChannelSO : ScriptableObjectEventBase
{
    public Action onRaiseAction;

    public void Raise()
    {
        onRaiseAction?.Invoke();
    }
}