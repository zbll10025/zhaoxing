using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using zhou.Tool.Singleton;

public class PlayerInputSystem : Singleton<PlayerInputSystem>
{
    public PlayerInputAction inputAction;
    public Vector2 PlayerXMove => inputAction.Player.Move.ReadValue<Vector2>();
    public bool Jump => inputAction.Player.Jump.triggered;
    public bool PrimaryAttack => inputAction.Player.PrimaryAttack.triggered;
    public bool Charge => inputAction.Player.ChargeAttack1.phase == InputActionPhase.Performed;
    public bool ChargeAttack1Exit => inputAction.Player.ChargeAttack1.phase == InputActionPhase.Canceled;
    protected override void Awake()
    {
        base.Awake();
        inputAction ??= new PlayerInputAction();
    }
    private void OnEnable()
    {
        inputAction.Enable();
    }
    private void OnDisable()
    {  
        inputAction.Disable();
    }
}
