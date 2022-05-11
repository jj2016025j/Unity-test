using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPPplayermovement : MonoBehaviour//第三人稱視角
{
    [Header("相機 控制")]
    public CharacterController controller;
    public Transform cam;//相機
    public float tureSmoothTime = 0.1f;
    public float tureSmoothvelocity;

    [Header("玩家 狀態")]
    public float speed = 5f;//跑速  /100*5
    public float gravity = -9.81f;//重力
    public float jumpHeight = 3f;//跳躍力  /100*3
    public float rotationSpeed = 1f;//跳躍力  /100*3
    public characterstats characterstats;//速度 狀態
    public bool 可控制的;


    [Header("落地 判斷")]
    public float groundDistance = 0.4f;//觸發距離
    public float climbingDistance = 0.7f;
    public Transform groundCheck;
    public LayerMask groundMask;

    public Vector3 velocity;
    public bool isGrounded;
    public bool isclimbing;

    [Header("動畫 控制")]
    public Animator animator;

    //[Header("其他")]

    //public Rigidbody rigidbody;

    //public VariableJoystick variableJoystick;

    void Start()//找物件
    {
        controller = GetComponent<CharacterController>();
        GetSpeed();
        //animator = GetComponent<Animator>();

        //rigidbody = GetComponent<Rigidbody>();
        //cam = gameObject.transform.GetChild(0);//改成用拉的
        //groundCheck = gameObject.transform.GetChild(1);
        //GetComponent<TPPplayermovement>().groundMask="Ground";
    }

    void Update()
    {
        if (可控制的) 
        { 
            XZMove();
            YMove();
        }

        if (!可控制的)
        {
        //Jump();
        }
        
    }
    public void XZMove()
    {


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        if (x == 0 & z == 0)
        {
            //x = variableJoystick.Horizontal;
            //z = variableJoystick.Vertical;
        }
        Vector3 direction = new Vector3(x, 0f, z).normalized;//水平方向
        //animator.SetFloat("Speed", Mathf.Pow(Mathf.Abs(Mathf.Pow(x, 2) + Mathf.Pow(z, 2)),0.5f));
        if (characterstats.objectState != characterdata.ObjectState.Dead)
        {
            animator.SetFloat("Speed", Vector3.Distance(direction, new Vector3(0, 0f, 0)));
            if (direction.magnitude >= 0.1f)
            {
                float targetngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;//紀錄按鍵方向+攝影機方向
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetngle, ref tureSmoothvelocity, tureSmoothTime);//圓滑轉向* rotationSpeed
                transform.rotation = Quaternion.Euler(0f, angle, 0f);//轉向


                Vector3 movedir = Quaternion.Euler(0f, targetngle, 0f) * Vector3.forward;//角度*方向

                controller.Move(movedir.normalized * speed * Time.deltaTime * 2);//移動
            }
        }
    }
    public void Jump()
    {
        if (characterstats.objectState != characterdata.ObjectState.Dead)
            if ((isGrounded || isclimbing))//判斷跳躍
            {
                animator.SetTrigger("Jump");
                velocity.y = Mathf.Sqrt(jumpHeight * -1f * gravity);//給跳躍力
                isGrounded = false;
                isclimbing = false;
            }

    }
    public void YMove()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);//觸發
        isclimbing = Physics.CheckSphere(groundCheck.position, climbingDistance, groundMask);
        //if (!(isGrounded || isclimbing))
        if (!isGrounded && !isclimbing)
        {
            velocity.y += gravity * Time.deltaTime;//重力
        }
        if (Input.GetButtonDown("Jump"))
            Jump();
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0;
        }
        else if (isclimbing && velocity.y < -4)//限制下降速度
        {
            velocity.y = -4f;
        }

        controller.Move(velocity * Time.deltaTime * 3);//上下的力
    }
    public void GetSpeed()
    {
        if (characterstats)
        {
            speed = characterstats.currentSpeed / 100 * 5;
            jumpHeight = characterstats.currentSpeed / 100 * 3;
            //rotationSpeed = 1/(characterstats.currentSpeed / 100)/ tureSmoothTime;
        }
    }
        
}
