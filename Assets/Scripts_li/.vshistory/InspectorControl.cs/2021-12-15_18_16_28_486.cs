using UnityEditor;
using static VirtualJoystick;

[CustomEditor(typeof(VirtualJoystick))]
public class InspectorControl : Editor
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
        virtualJoystick.dragType = (DragType)EditorGUILayout.EnumPopup("Drag Type", virtualJoystick.dragType);
        if (virtualJoystick.dragType == DragType.Follow)
        {
            EditorGUILayout.PropertyField(anchorsMin);
            EditorGUILayout.PropertyField(anchorsMax);
        }
    }
}
