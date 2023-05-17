using UnityEngine;

public class ZombieCharacterControl : MonoBehaviour
{
    private enum ControlMode
    {
        /// <summary>
        /// Up moves the character forward, left and right turn the character gradually and down moves the character backwards
        /// </summary>
        Tank,
        /// <summary>
        /// Character freely moves in the chosen direction from the perspective of the camera
        /// </summary>
        Direct
    }

    [SerializeField] 
    private float m_moveSpeed = 2;

    [SerializeField]
    private float m_turnSpeed = 200;

    [SerializeField] 
    private float m_attackTimeout = 2;

    [SerializeField] 
    private Animator m_animator = null;

    [SerializeField] 
    private Rigidbody m_rigidBody = null;

    [SerializeField]
    private Transform attackPoint;

    [SerializeField]
    private float attackRadius;

    [SerializeField]
    private float damage;

    [SerializeField]
    private LayerMask attackLayer;

    [SerializeField]
    private ParticleSystem attackHitParticle;

    private float m_currentV = 0;
    private float m_currentH = 0;

    private readonly float m_interpolation = 10;

    private Vector3 m_currentDirection = Vector3.zero;
    private float m_currentAttackTimeout = 0;

    public Vector2 Direction { get; set; }
    public bool OrderToAttack { get; set; }

    private void Awake()
    {
        if (!m_animator) { gameObject.GetComponent<Animator>(); }
        if (!m_rigidBody) { gameObject.GetComponent<Animator>(); }
    }

    private void Update()
    {
        DirectUpdate();
    }

    private void DirectUpdate()
    {
        bool isWalking = m_animator.GetCurrentAnimatorStateInfo(0).IsName("Walk");

        if (isWalking)
        {
            float v = Direction.y;
            float h = Direction.x;

            Transform camera = Camera.main.transform;

            m_currentV = Mathf.Lerp(m_currentV, v, Time.deltaTime * m_interpolation);
            m_currentH = Mathf.Lerp(m_currentH, h, Time.deltaTime * m_interpolation);

            Vector3 direction = camera.forward * m_currentV + camera.right * m_currentH;

            float directionLength = direction.magnitude;
            direction.y = 0;
            direction = direction.normalized * directionLength;

            if (direction != Vector3.zero)
            {
                m_currentDirection = Vector3.Slerp(m_currentDirection, direction, Time.deltaTime * m_interpolation);

                transform.rotation = Quaternion.LookRotation(m_currentDirection);
                transform.position += m_currentDirection * m_moveSpeed * Time.deltaTime;

                m_animator.SetFloat("MoveSpeed", direction.magnitude);
            }
        }

        if (m_currentAttackTimeout <= 0)
        {
            if (OrderToAttack && isWalking)
            {
                m_animator.SetTrigger("Attack");
                m_currentAttackTimeout = m_attackTimeout;
                OrderToAttack = false;
            }
        }
        else
        {
            m_currentAttackTimeout -= Time.deltaTime;
        }
    }

    public void DealDamage()
    {
        var colliders = Physics.OverlapSphere(attackPoint.position, attackRadius, attackLayer.value);
        foreach (var collider in colliders)
        {
            var health = collider.GetComponent<Health>();
            health.Damage(damage);
            attackHitParticle.Play();
        }
    }
}
