using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {
    #region Components
    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }
    public EntityFx fx { get; private set; }
    #endregion

    [Header("Knockback Info")]
    [SerializeField] protected Vector2 knockbackDir;
    [SerializeField] protected float KnockbackDuration;
    protected bool isKnocked;

    [Header("Collision Info")]
    public Transform attackCheck;
    public float attackCheckRadius;
    [SerializeField] protected Transform groundCheck;
    [SerializeField] protected float groundCheckDistance;
    [SerializeField] protected Transform wallCheck;
    [SerializeField] protected float wallCheckDistance;
    [SerializeField] protected LayerMask whatIsGround;

    public float facingDir = 1;
    private bool isFacingRight = true;

    protected virtual void Awake() {

    }
    protected virtual void Start() {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        fx = GetComponent<EntityFx>();
    }

    // Update is called once per frame
    protected virtual void Update() {

    }

    public void Damage() {
        fx.StartCoroutine("FlashFX");
        StartCoroutine("HitKnockBack");
    }

    protected virtual IEnumerator HitKnockBack() {
        isKnocked = true;
        rb.velocity = new Vector2(knockbackDir.x * -facingDir, knockbackDir.y);
        yield return new WaitForSeconds(KnockbackDuration);
        isKnocked = false;

    }

    #region Velocity
    public void SetZeroVelocity() {
        if (isKnocked) {
            return;
        }
        rb.velocity = Vector2.zero;
    }

    public void SetVelocity(float _xVelocity, float _yVelocity) {
        if (isKnocked) {
            return;
        }

        rb.velocity = new Vector2(_xVelocity, _yVelocity);
        FlipController(_xVelocity);
    }
    #endregion

    #region Flip
    public virtual void Flip() {
        facingDir = facingDir * -1;
        isFacingRight = !isFacingRight;
        transform.Rotate(0, 180, 0);
    }
    public virtual void FlipController(float _x) {
        if (_x < 0 && isFacingRight) {
            Flip();
        }
        else if (_x > 0 && !isFacingRight) {
            Flip();
        }
    }
    #endregion

    #region Collision
    public virtual bool isGroundDetected() {
        return Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);
    }

    public virtual bool isWallDetected() {
        return Physics2D.Raycast(wallCheck.position, Vector2.right * facingDir, wallCheckDistance, whatIsGround);
    }
    protected virtual void OnDrawGizmos() {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance * facingDir, wallCheck.position.y));
        Gizmos.DrawWireSphere(attackCheck.position, attackCheckRadius);
    }
    #endregion
}
