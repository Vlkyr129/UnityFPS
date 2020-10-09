using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float shakeDurtation = .1f;
    [SerializeField] float shakeMagnitude = .4f;

    private void Update()
    {
        if (EnemyProjectile.playerRangedHit == true)
        {
            StartCoroutine(Shake(shakeDurtation, shakeMagnitude));
            EnemyProjectile.playerRangedHit = false;
        }
        if (EnemyMeleeAttack.playerMeleeHit == true)
        {
            StartCoroutine(Shake(shakeDurtation, shakeMagnitude));
            EnemyMeleeAttack.playerMeleeHit = false;
        }
    }

    public IEnumerator Shake (float duration, float magnitude)
    {
        Vector3 originalPosition = transform.localPosition;

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float xShake = Random.Range(-1f, 1f) * magnitude;
            float yShake = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(xShake, yShake, originalPosition.z);

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPosition;
    }
}
