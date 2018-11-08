using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public VirtualJoystick joystick;

    public float speed = 5.0f;
    private Rigidbody2D rigid;
    private Quaternion targetRotation;

    Vector2 tempDirection = Vector2.zero;

    public Animator animator;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
      //  trap = new Trap_player();
    }

    private void Update()
    {
        var direction = joystick.InputDirection;

        if (direction == Vector2.zero)
        {
            direction = tempDirection;
        }

        tempDirection = direction;

        var angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.back);
        
        rigid.velocity = joystick.InputDirection * speed;

        if (joystick.InputDirection != Vector2.zero) //če hodimo se vklopi animacija
        {
            animator.SetFloat("Speed", 1);
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }

        //rigid.transform.rotation = Quaternion.LookRotation(joystick.InputDirection, Vector3.back);
    }
}
