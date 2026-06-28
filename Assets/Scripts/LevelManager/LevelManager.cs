//using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Transform levelContainer;
    public bool useWholeLevel = true;

    [Header("Whole levels")]
    public List<GameObject> levels;

    public List<LevelPieceBasedSetup> levelPieceBasedSetup;

    private int _index;
    private GameObject _level;

    private List<LevelPieceBase> _spawnedPieces = new List<LevelPieceBase>();
    private LevelPieceBasedSetup _currentSetup;

    private void Awake()
    {
        if (useWholeLevel)
        {
            SpawnNextLevel();
            return;
        }

        GenerateFragmentedLevel();
    }

    #region Whole Level Generation
    private void SpawnNextLevel()
    {
        if (_level != null)
        {
            Destroy(_level);
            _index++;

            if(_index >= levels.Count)
            {
                ResetLevelIndex();
            }
        }
        
        _level = Instantiate(levels[_index], levelContainer);
        _level.transform.localPosition = Vector3.zero;
    }
    #endregion

    #region Random Level Generation
    private void GenerateFragmentedLevel()
    {
        CleanSpawnedPieces();

        if (_currentSetup != null)
        {
            _index++;

            if (_index >= levelPieceBasedSetup.Count)
            {
                ResetLevelIndex();
            }
        }

        _currentSetup = levelPieceBasedSetup[_index];

        for (int i = 0; i < _currentSetup.piecesNumberStart; i++)
        {
            CreateLevelPiece(_currentSetup.levelPiecesStart);
        }
        for (int i = 0; i < _currentSetup.piecesNumber; i++)
        {
            CreateLevelPiece(_currentSetup.levelPieces);
        }
        for (int i = 0; i < _currentSetup.piecesNumberEnd; i++)
        {
            CreateLevelPiece(_currentSetup.levelPiecesEnd);
        }
    }

    private void CreateLevelPiece(List<LevelPieceBase> list)
    {
        var piece = list[Random.Range(0, list.Count)];
        var spawnedPiece = Instantiate(piece, levelContainer);

        if (_spawnedPieces.Count > 0)
        {
            var lastPiece = _spawnedPieces[_spawnedPieces.Count - 1];

            spawnedPiece.transform.position = lastPiece.endPiece.position;
        }
        else
        {
            spawnedPiece.transform.localPosition = Vector3.zero;
        }

        foreach (var art in spawnedPiece.GetComponentsInChildren<ArtPiece>())
        {
            art.ChangePieceType(ArtManager.Instance.GetSetupByType(_currentSetup.artType).gameObject);
        }

        _spawnedPieces.Add(spawnedPiece);
    }
    #endregion

    private void CleanSpawnedPieces()
    {
        for (int i = _spawnedPieces.Count - 1; i >= 0; i--)
        {
            Destroy(_spawnedPieces[i].gameObject);
        }

        _spawnedPieces.Clear();
    }

    private void ResetLevelIndex()
    {
        _index = 0;
    }
}