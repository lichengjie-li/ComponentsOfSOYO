using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewFloatEvent", menuName = "Bug/Event/FloatEvent")]
public class FloatEventChannelSO : ScriptableObjectEventBase
{
    public Action<float> onRaiseAction;

    public void Raise(float value)
    {
        onRaiseAction?.Invoke(value);
    }
}