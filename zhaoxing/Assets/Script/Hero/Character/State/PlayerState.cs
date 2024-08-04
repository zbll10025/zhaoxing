using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerState : IState
{
    public static int facingDir = 1;
    public static bool facingRight = true;//判断是否朝右


    protected bool triggerCalled;//动画是否完成控制值


    protected Animator anim { get; private set; }
    protected Rigidbody2D rb;

    protected PlayerStateMachine stateMachine {  get; private set; }


    public float xInput;
    public PlayerState( PlayerStateMachine playerStateMachine)
    {
        stateMachine = playerStateMachine;
        //简化名称，如：playerStateMachine.hero.rb->rb
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
    }//动画控制函数，当动画完成时将控制器设置为true表达其动画已经完成了

    public virtual void Update()
    {
        xInput = PlayerInputSystem.MainInstance.PlayerXMove.x;
        anim.SetFloat(AnimatorID.YVelocityID, rb.velocity.y);
        
    }
    #region 设置角色移动速度
    public void SetVelocity(float _xVelocity, float _yVelocity)
    {
        rb.velocity = new Vector2(_xVelocity, _yVelocity);
        FlipController(_xVelocity);//在设置速度的时候调用翻转控制器
    }
    public void ZeroVelocity()
    {
        rb.velocity = new Vector2(0, 0);
    }
    #endregion
    #region 反转人物
    public void Flip()
    {
        facingDir *= -1;
        facingRight = !facingRight;
        stateMachine.hero.transform.Rotate(0, 180, 0);
    }
    public void FlipController(float _x)//目前设置x，目的时能在空中时也能转身
    {
        if (_x > 0 && !facingRight)//当速度大于0且没有朝右时，翻转
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
