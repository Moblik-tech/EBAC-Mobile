using UnityEngine;
using Moblik.Core.Singleton;
using TMPro;
using DG.Tweening;

public class PlayerController : Singleton<PlayerController>
{
    [Header("Lerp")]
    public Transform target;
    public float lerpSpeed = 5f;

    public float speed = 1.0f;

    public string tagToCheckEnemy = "Enemy";
    public string tagToCheckEndLine = "EndLine";

    public GameObject endScreen;

    public bool invincible = false;

    [Header("TextMeshPro")]
    public TextMeshPro uITextPowerUp;

    [Header("Coin Collector")]
    public GameObject coinCollector;

    private bool _canRun;
    private Vector3 _pos;
    private float _currentSpeed;
    private Vector3 _startPosition;

    private void Start()
    {
        ResetSpeed();
        _startPosition = transform.position;
    }

    private void Update()
    {
        if (!_canRun) return;

        _pos = target.position;
        _pos.y = transform.position.y;
        _pos.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, _pos, lerpSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, _pos) < 0.005f)
        {
            transform.position = _pos;
        }

        transform.Translate(_currentSpeed * Time.deltaTime * transform.forward);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(tagToCheckEnemy))
        {
            if (!invincible) EndGame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagToCheckEndLine))
        {
            if (!invincible) EndGame();
        }
    }

    private void EndGame()
    {
        _canRun = false;
        endScreen.SetActive(true);
    }

    public void StartToRun()
    {
        _canRun = true;
    }

    #region POWER UPS
    public void SetPowerUpText(string s)
    {
        uITextPowerUp.text = s;
    }

    public void PowerUpSpeedUp(float f)
    {
        _currentSpeed = f;
    }

    public void ResetSpeed()
    {
        _currentSpeed = speed;
    }

    public void SetInvincible(bool b)
    {
        invincible = b;
    }

    public void ChangeHeight(float amount, float duration, float animationDuration, Ease ease)
    {
        transform.DOMoveY(_startPosition.y + amount, animationDuration).SetEase(ease);
        Invoke(nameof(ResetHeight), duration);
    }

    public void ResetHeight()
    {
        transform.DOMoveY(_startPosition.y, 0.4f);
    }

    public void ChangeCoinCollectorSize(float size)
    {
        coinCollector.transform.localScale = Vector3.one * size;
    }
    #endregion
}