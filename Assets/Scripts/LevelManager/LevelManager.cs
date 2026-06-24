//using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Transform levelContainer;
    public bool useWholeLevel = true;

    [Header("Whole levels")]
    public List<GameObject> levels;

    [Header("Level Pieces")]
    public List<LevelPieceBase> levelStartPieces;
    public List<LevelPieceBase> levelPieces;
    public List<LevelPieceBase> levelEndPieces;

    public int piecesStartNumber = 3;
    public int piecesNumber = 5;
    public int piecesEndNumber = 1;
    //public float timeBetweenPieces = 0.3f;

    private int _index;
    private GameObject _currentLevel;
    private List<LevelPieceBase> _spawnedPieces;

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
        if (_currentLevel != null)
        {
            Destroy(_currentLevel);
            _index++;

            if(_index >= levels.Count)
            {
                ResetLevelIndex();
            }
        }
        
        _currentLevel = Instantiate(levels[_index], levelContainer);
        _currentLevel.transform.localPosition = Vector3.zero;
    }

    private void ResetLevelIndex()
    {
        _index = 0;
    }
    #endregion

    #region Random Level Generation
    private void GenerateFragmentedLevel()
    {
        _spawnedPieces = new List<LevelPieceBase>();

        for (int i = 0; i < piecesStartNumber; i++)
        {
            CreateLevelPiece(levelStartPieces);
        }
        for (int i = 0; i < piecesNumber; i++)
        {
            CreateLevelPiece(levelPieces);
        }
        for (int i = 0; i < piecesEndNumber; i++)
        {
            CreateLevelPiece(levelEndPieces);
        }

        //StartCoroutine(SpawnLevelPiece());
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

        _spawnedPieces.Add(spawnedPiece);
    }

    /*
    IEnumerator SpawnLevelPiece()
    {
        _spawnedPieces = new List<LevelPieceBase>();

        for (int i = 0; i < piecesNumber; i++)
        {
            CreateLevelPiece();
            yield return new WaitForSeconds(timeBetweenPieces);
        }
    }
    */
    #endregion
}