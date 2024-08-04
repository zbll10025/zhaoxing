using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerState : IState
{
    public static int facingDir = 1;
    public static bool facingRight = true;//�ж��Ƿ���


    protected bool triggerCalled;//�����Ƿ���ɿ���ֵ


    protected Animator anim { get; private set; }
    protected Rigidbody2D rb;

    protected PlayerStateMachine stateMachine {  get; private set; }


    public float xInput;
    public PlayerState( PlayerStateMachine playerStateMachine)
    {
        stateMachine = playerStateMachine;
        //�����ƣ��磺playerStateMachine.hero.rb->rb
        anim = playerStateMachine.hero.animator;

        rb = playerStateMachine.hero.rb;

    }
    public virtual void Enter()
    {
        Debug.Log(GetType().Name);
    }

    public virtual void Exit()
    {
        
    }

    public void HandInput()
    {
        
    }
    public virtual void AnimationFinishTrigger()
    {
        triggerCalled = true;
    }//�������ƺ��������������ʱ������������Ϊtrue����䶯���Ѿ������

    public virtual void Update()
    {
        xInput = PlayerInputSystem.MainInstance.PlayerXMove.x;
        anim.SetFloat(AnimatorID.YVelocityID, rb.velocity.y);
        
    }
    #region ���ý�ɫ�ƶ��ٶ�
    public void SetVelocity(float _xVelocity, float _yVelocity)
    {
        rb.velocity = new Vector2(_xVelocity, _yVelocity);
        FlipController(_xVelocity);//�������ٶȵ�ʱ����÷�ת������
    }
    public void ZeroVelocity()
    {
        rb.velocity = new Vector2(0, 0);
    }
    #endregion
    #region ��ת����
    public void Flip()
    {
        facingDir *= -1;
        facingRight = !facingRight;
        stateMachine.hero.transform.Rotate(0, 180, 0);
    }
    public void FlipController(float _x)//Ŀǰ����x��Ŀ��ʱ���ڿ���ʱҲ��ת��
    {
        if (_x > 0 && !facingRight)//���ٶȴ���0��û�г���ʱ����ת
        {
            Flip();
        }
        else if (_x < 0 && facingRight)
        {
            Flip();
        }
    }
    #endregion
}
