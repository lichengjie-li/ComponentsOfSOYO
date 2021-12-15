using UnityEngine;

public class TestScript : MonoBehaviour
{
    public bool b;

    public int number;

    [ContextMenu("Test")]
    private void Test()
    {
        Adapter.SetAdapterValue(ref number, b, -1, 1);
    }
}