using UnityEngine;

public class TestScript : MonoBehaviour
{
    public bool b;
    public int number;

    [ContextMenu("Test")]
    private void Test()
    {
        number = Adapter.SetAdapterValue(b, 1, -1);
    }
}