using UnityEngine;

public class ChessPiece : MonoBehaviour
{
    public enum PieceType
    {
        Pawn,
        Rook,
        Knight,
        Bishop,
        Queen,
        King
    }

    [SerializeField] private PieceType pieceType = PieceType.Pawn;
    public Color tintColor = Color.white;
    public Quaternion handleValue = Quaternion.identity;

    [SerializeField] private Sprite pawnSprite;
    [SerializeField] private Sprite rookSprite;
    [SerializeField] private Sprite knightSprite;
    [SerializeField] private Sprite bishopSprite;
    [SerializeField] private Sprite queenSprite;
    [SerializeField] private Sprite kingSprite;

    [SerializeField] private Color moveGizmoColor = Color.green;

    private SpriteRenderer spriteRenderer;

    private void OnValidate()
    {
        UpdateVisuals();
    }

    public void UpdateVisuals()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.sprite = SpriteType(pieceType);
        spriteRenderer.color = tintColor;
    }

    private Sprite SpriteType(PieceType type)
    {
        switch (type)
        {
            case PieceType.Pawn: return pawnSprite;
            case PieceType.Rook: return rookSprite;
            case PieceType.Knight: return knightSprite;
            case PieceType.Bishop: return bishopSprite;
            case PieceType.Queen: return queenSprite;
            case PieceType.King: return kingSprite;
            default: return pawnSprite;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = moveGizmoColor;

        int boardX = Mathf.FloorToInt(transform.position.x);
        int boardY = Mathf.FloorToInt(transform.position.y);

        switch (pieceType)
        {
            case PieceType.Pawn:
                DrawSphere(boardX, boardY + 1);
                DrawSphere(boardX, boardY + 2);
                break;

            case PieceType.Rook:
                DrawRookMoves(boardX, boardY);
                break;

            case PieceType.Bishop:
                DrawBishopMoves(boardX, boardY);
                break;

            case PieceType.Queen:
                DrawRookMoves(boardX, boardY);
                DrawBishopMoves(boardX, boardY);
                break;

            case PieceType.King:
                for (int offsetX = -1; offsetX <= 1; offsetX++)
                {
                    for (int offsetY = -1; offsetY <= 1; offsetY++)
                    {
                        if (offsetX == 0 && offsetY == 0)
                            continue;
                        DrawSphere(boardX + offsetX, boardY + offsetY);
                    }
                }
                break;

            case PieceType.Knight:
                DrawSphere(boardX + 1, boardY + 2);
                DrawSphere(boardX - 1, boardY + 2);
                DrawSphere(boardX + 1, boardY - 2);
                DrawSphere(boardX - 1, boardY - 2);
                DrawSphere(boardX + 2, boardY + 1);
                DrawSphere(boardX - 2, boardY + 1);
                DrawSphere(boardX + 2, boardY - 1);
                DrawSphere(boardX - 2, boardY - 1);
                break;
        }
    }

    private void DrawRookMoves(int boardX, int boardY)
    {
        for (int i = 0; i < 8; i++)
        {
            if (i != boardX)
                DrawSphere(i, boardY);
            if (i != boardY)
                DrawSphere(boardX, i);
        }
    }

    private void DrawBishopMoves(int boardX, int boardY)
    {
        for (int i = 1; i < 8; i++)
        {
            DrawSphere(boardX + i, boardY + i);
            DrawSphere(boardX + i, boardY - i);
            DrawSphere(boardX - i, boardY + i);
            DrawSphere(boardX - i, boardY - i);
        }
    }

    private void DrawSphere(int boardX, int boardY)
    {
        if (boardX < 0 || boardX > 7 || boardY < 0 || boardY > 7)
            return;

        Vector3 center = new Vector3(boardX + 0.5f, boardY + 0.5f, 0f);
        Gizmos.DrawSphere(center, 0.15f);
    }
}
