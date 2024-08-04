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
    #region ���ý�ɫ֡�¼�
    public void AnimationTrigger() => playerStateMachine.AnimationFinishTrigger();
    //�ӵ�ǰ״̬�õ�AnimationTrigger���е��õĺ���

    #endregion
    #region ������
    public bool IsGroundDetected()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, whatIsGround);
    }
    #endregion
    #region ǽ����
    public bool IsWallDetected()
    {
        return Physics2D.Raycast(transform.position,
            Vector2.right * PlayerState.facingDir,
            wallCheckDistance, whatIsGround);
    }
    #endregion
}
