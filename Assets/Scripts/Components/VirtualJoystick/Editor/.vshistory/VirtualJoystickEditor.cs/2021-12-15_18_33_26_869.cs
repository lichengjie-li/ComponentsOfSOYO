using UnityEditor;

[CustomEditor(typeof(VirtualJoystick))]
public class VirtualJoystickEditor : Editor
{
    private SerializedObject obj;
    private VirtualJoystick virtualJoystick;
    private SerializedProperty anchorsMin;
    private SerializedProperty anchorsMax;
    void OnEnable()
    {
        obj = new SerializedObject(target);
        anchorsMin = obj.FindProperty("DragAreaAnchorsMin");
        anchorsMax = obj.FindProperty("DragAreaAnchorsMax");
    }
    public override void OnInspectorGUI()
    {
        virtualJoystick = (VirtualJoystick)target;
        virtualJoystick.dragType =
            (DragType)EditorGUILayout.EnumPopup("Drag Type", virtualJoystick.dragType);
        // 满足条件时显示，否则隐藏
        if (virtualJoystick.dragType == DragType.Follow)
        {
            EditorGUILayout.PropertyField(anchorsMin);
            EditorGUILayout.PropertyField(anchorsMax);
        }
    }
}
