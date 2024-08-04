using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class Hero : MonoBehaviour
{
    public PlayerStateMachine playerStateMachine {  get; private set; }
    public Animator animator;
    public Rigidbody2D rb;


    public float moveSpeed;
    public float jumpForce;

  
    [SerializeField] private float groundCheckDistance;  
    [SerializeField] private float wallCheckDistance;
    [SerializeField] private LayerMask whatIsGround;
    private void Awake()
    {
        playerStateMachine = new PlayerStateMachine(this);
    }
    private void Start()
    {
        playerStateMachine.ChangeState(playerStateMachine.IdleState);
    }
    private void Update()
    {
        playerStateMachine.Update();
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + wallCheckDistance, transform.position.y));
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - groundCheckDistance));
    }
    #region 调用角色帧事件
    public void AnimationTrigger() => playerStateMachine.AnimationFinishTrigger();
    //从当前状态拿到AnimationTrigger进行调用的函数

    #endregion
    #region 地面检测
    public bool IsGroundDetected()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, whatIsGround);
    }
    #endregion
    #region 墙面检测
    public bool IsWallDetected()
    {
        return Physics2D.Raycast(transform.position,
            Vector2.right * PlayerState.facingDir,
            wallCheckDistance, whatIsGround);
    }
    #endregion
}
