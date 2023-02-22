using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAI : MonoBehaviour
{
    private const float MIN_ACCURACY = 0.1f;

    [SerializeField]
    private Gun gun;

    [SerializeField]
    private Transform gunHolder;

    [SerializeField]
    private float gunRotationSpeed;

    [SerializeField]
    private float detectionDistance;

    [SerializeField]
    private float idleDelay;

    private Coroutine idleCoroutine = null;

    private void Update()
    {
        Vector3 playerVector = Player.Instance.transform.position - gunHolder.transform.position;
        playerVector.y = 0;
        if (Physics.Raycast(gunHolder.position, playerVector, out RaycastHit hitInfo, detectionDistance))
        {
            if (hitInfo.transform.CompareTag("Player"))
            {
                StopIdle();
                RotateTo(playerVector);
                if (Vector3.Angle(playerVector, gunHolder.right) < MIN_ACCURACY)
                {
                    gun.Shoot();
                }
            }
            else
            {
                SetToIdle();
            }
        }
        else
        {
            SetToIdle();
        }
    }

    private Vector3 RotateTo(Vector3 direction)
    {
        return gunHolder.right = Vector3.RotateTowards(gunHolder.right, direction.normalized, gunRotationSpeed * Mathf.Deg2Rad * Time.deltaTime, 1);
    }

    public void SetToIdle()
    {
        if (idleCoroutine == null)
        {
            idleCoroutine = StartCoroutine(Idle());
        }
    }

    public void StopIdle()
    {
        if (idleCoroutine == null) return;
        StopCoroutine(idleCoroutine);
        idleCoroutine = null;
    }

    private IEnumerator Idle()
    {
        while (true)
        {
            yield return new WaitForSeconds(idleDelay);
            Vector3 direction = Random.onUnitSphere;
            direction.y = 0;
            yield return RotateToContinuos(direction);
        }
    }

    private IEnumerator RotateToContinuos(Vector3 direction)
    {
        while (Vector3.Angle(direction, gunHolder.right) > MIN_ACCURACY)
        {
            RotateTo(direction);
            yield return null;
        }
    }
}
