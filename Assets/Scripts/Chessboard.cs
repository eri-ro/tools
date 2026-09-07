using UnityEngine;

public class Chessboard : MonoBehaviour
{
    private int boardSize = 8;
    private float squareSize = 1.0f;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;

        for (int x = 0; x < boardSize; x++)
        {
            for (int y = 0; y < boardSize; y++)
            {
                Vector3 squarePosition = new Vector3(x + 0.5f, y + 0.5f, 0.0f);
                Gizmos.DrawWireCube(squarePosition, new Vector3(squareSize, squareSize, 0.1f));
            }
        }
    }
}