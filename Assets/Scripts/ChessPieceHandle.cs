using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ChessPiece))]
public class ChessPieceHandle : Editor
{
    void OnSceneGUI()
    {
        ChessPiece piece = target as ChessPiece;
        Transform transform = piece.transform;

        Handles.DrawWireDisc(transform.position, Vector3.forward, 0.5f);

        EditorGUI.BeginChangeCheck();
        Quaternion rot = Handles.RotationHandle(piece.handleValue, transform.position);
        if (EditorGUI.EndChangeCheck())
        {
            piece.handleValue = rot;
            Vector3 rgb = rot.eulerAngles / 360f;
            piece.tintColor = new Color(rgb.x, rgb.y, rgb.z, 1f);
            piece.UpdateVisuals();
        }
    }
}
