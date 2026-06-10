using UnityEngine;

public class ItemCollectableBase : MonoBehaviour
{
    [Header("General")]
    public GameObject graphicItem;
    public float timeToHide = 1f;
    public string collidedObjectTag = "Player";
    public ParticleSystem particleSystem;

    [Header("Sounds")]
    public AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(collidedObjectTag))
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {
        if (graphicItem != null) graphicItem.SetActive(false);
        OnCollect();

        Invoke(nameof(HideObject), timeToHide);
    }

    private void HideObject()
    {
        gameObject.SetActive(false);
    }

    protected virtual void OnCollect()
    {
        if (particleSystem != null) particleSystem.Play();
        if (audioSource != null) audioSource.Play();
    }
}