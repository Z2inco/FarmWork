using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController2D : MonoBehaviour
{
    Rigidbody2D rigidbody2d;    //�Զ��������������Ϊ������
    [SerializeField]float speed = 2f;  //ǿ�� Unity ��˽���ֶν������л�
    Vector2 motionVector;
    public Vector2 lastMotionVector;
    Animator animator;
    public bool moving;

    void Awake()    //��������
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        //�ƶ�����
        float horizontal =  Input.GetAxisRaw("Horizontal"); //���ҷ���ˮƽ��
        float vertical = Input.GetAxisRaw("Vertical");   //���·��򣨴�ֱ��

        motionVector = new Vector2(horizontal, vertical);

        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);
        animator.SetFloat("Speed", motionVector.sqrMagnitude);

        //�����
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
