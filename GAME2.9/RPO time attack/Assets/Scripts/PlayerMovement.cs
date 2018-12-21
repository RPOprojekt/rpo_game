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

    public Animator animator1;
    public Animator animator2;

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
            if (PlayerPrefs.GetInt("player") == 0)
            {
                animator1.SetFloat("Speed", 1);
            }
            else if (PlayerPrefs.GetInt("player") == 1)
            {
                animator2.SetFloat("Speed", 1);
            }
        }
        else
        {
            if (PlayerPrefs.GetInt("player") == 0)
            {
                animator1.SetFloat("Speed", 0);
            }
            else if (PlayerPrefs.GetInt("player") == 1)
            {
                animator2.SetFloat("Speed", 0);
            }
        }

        //rigid.transform.rotation = Quaternion.LookRotation(joystick.InputDirection, Vector3.back);
    }
}
