using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController2D : MonoBehaviour
{
    Rigidbody2D rigidbody2d;    //自动将所需的组件添加为依赖项
    [SerializeField]float speed = 2f;  //强制 Unity 对私有字段进行序列化
    Vector2 motionVector;
    public Vector2 lastMotionVector;
    Animator animator;
    public bool moving;

    void Awake()    //立即调用
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        //移动方向
        float horizontal =  Input.GetAxisRaw("Horizontal"); //左右方向（水平轴
        float vertical = Input.GetAxisRaw("Vertical");   //上下方向（垂直轴

        motionVector = new Vector2(horizontal, vertical);

        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);
        animator.SetFloat("Speed", motionVector.sqrMagnitude);

        //最后朝向
        moving = horizontal != 0 || vertical != 0;
        animator.SetBool("Moving", moving);
        if (moving) {
            lastMotionVector = new Vector2(horizontal, vertical).normalized;
            animator.SetFloat("LastHorizontal", horizontal);
            animator.SetFloat("LastVertical", vertical);
        }
    }
 
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    { 
        rigidbody2d.MovePosition(rigidbody2d.position + motionVector * speed * Time.fixedDeltaTime);
    }
}
