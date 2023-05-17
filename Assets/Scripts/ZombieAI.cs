using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAI : MonoBehaviour
{
    [SerializeField]
    private float detectionDistance = 3;

    [SerializeField]
    private float attackDistance = 0.2f;

    [SerializeField]
    private float attackMinAngle = 15;

    [SerializeField]
    private ZombieCharacterControl zombieCharacter;

    private void Update()
    {
        Vector3 playerVector = Player.Instance.transform.position - transform.position;
        if (detectionDistance >= playerVector.magnitude)
        {
            zombieCharacter.Direction = new Vector2(playerVector.x, playerVector.z);
            if (attackDistance >= playerVector.magnitude && Vector3.Angle(playerVector, transform.forward) < attackMinAngle)
            {
                zombieCharacter.OrderToAttack = true;
            }
            else
            {
                zombieCharacter.OrderToAttack = false;
            }
        }
        else
        {
            zombieCharacter.OrderToAttack = false;
            zombieCharacter.Direction = Vector2.zero;
        }
    }
}
