using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D body;
    public float speed;
    public Vector2 velocity;
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        speed = 4f;

        if (body == null)
        {
            Debug.LogError("Rigidbody2D component is missing!");
            enabled = false; // Disable this script if Rigidbody2D is missing
        }
        body.velocity = new Vector2(body.velocity.x, -5f);
        velocity = body.velocity;

    }
    private void Update()
    {
        body.velocity = velocity;
    }
    public void Move(InputAction.CallbackContext context)
    {
        Vector2 direction = context.ReadValue<Vector2>();
        velocity = new Vector2(direction.x * speed, body.velocity.y);

    }

}
//这个是测试敌人ai写的player移动代码