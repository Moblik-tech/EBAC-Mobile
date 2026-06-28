using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LevelPieceBasedSetup : ScriptableObject
{
    public ArtManager.ArtType artType;

    [Header("Level Pieces")]
    public List<LevelPieceBase> levelPiecesStart;
    public List<LevelPieceBase> levelPieces;
    public List<LevelPieceBase> levelPiecesEnd;

    public int piecesNumberStart;
    public int piecesNumber;
    public int piecesNumberEnd;
}