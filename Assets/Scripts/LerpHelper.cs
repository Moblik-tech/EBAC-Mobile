using UnityEngine;

public class LerpHelper : MonoBehaviour
{
    public Transform target;

    public float lerpSpeed = 1f;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, lerpSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) < 0.005f)
        {
            transform.position = target.position;
        }
    }
}