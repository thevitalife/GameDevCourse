using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Damagable
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private Vector3 direction;

    [SerializeField]
    private float timeToDeath = 10;

    protected override void DealDamage(Collider collider)
    {
        base.DealDamage(collider);
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.position += direction * (speed * Time.deltaTime);
    }

    public void Init(Vector3 position, Vector3 direction)
    {
        transform.position = position;
        this.direction = direction;
        transform.up = direction;
    }

    private IEnumerator DieAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

    private void OnEnable()
    {
        StartCoroutine(DieAfterTime(timeToDeath));
    }
}
