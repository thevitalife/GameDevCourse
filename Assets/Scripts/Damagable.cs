using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour
{
    [SerializeField]
    private float minDamage;

    [SerializeField]
    private float maxDamage;

    protected virtual void OnTriggerEnter(Collider other)
    {
        DealDamage(other);
    }

    protected virtual void DealDamage(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.TryGetComponent(out Health health))
            {
                health.Damage(Random.Range(minDamage, maxDamage));
            }
        }
    }
}
