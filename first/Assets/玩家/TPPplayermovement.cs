using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPPplayermovement : MonoBehaviour//�ĤT�H�ٵ���
{
    [Header("�۾� ����")]
    public CharacterController controller;
    public Transform cam;//�۾�
    public float tureSmoothTime = 0.1f;
    public float tureSmoothvelocity;

    [Header("���a ���A")]
    public float speed = 5f;//�]�t  /100*5
    public float gravity = -9.81f;//���O
    public float jumpHeight = 3f;//���D�O  /100*3
    public float rotationSpeed = 1f;//���D�O  /100*3
    public characterstats characterstats;//�t�� ���A
    public bool �i���;


    [Header("���a �P�_")]
    public float groundDistance = 0.4f;//Ĳ�o�Z��
    public float climbingDistance = 0.7f;
    public Transform groundCheck;
    public LayerMask groundMask;

    public Vector3 velocity;
    public bool isGrounded;
    public bool isclimbing;

    [Header("�ʵe ����")]
    public Animator animator;

    //[Header("��L")]

    //public Rigidbody rigidbody;

    //public VariableJoystick variableJoystick;

    void Start()//�䪫��
    {
        controller = GetComponent<CharacterController>();
        GetSpeed();
        //animator = GetComponent<Animator>();

        //rigidbody = GetComponent<Rigidbody>();
        //cam = gameObject.transform.GetChild(0);//�令�ΩԪ�
        //groundCheck = gameObject.transform.GetChild(1);
        //GetComponent<TPPplayermovement>().groundMask="Ground";
    }

    void Update()
    {
        if (�i���) 
        { 
            XZMove();
            YMove();
        }

        if (!�i���)
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
        Vector3 direction = new Vector3(x, 0f, z).normalized;//������V
        //animator.SetFloat("Speed", Mathf.Pow(Mathf.Abs(Mathf.Pow(x, 2) + Mathf.Pow(z, 2)),0.5f));
        if (characterstats.objectState != characterdata.ObjectState.Dead)
        {
            animator.SetFloat("Speed", Vector3.Distance(direction, new Vector3(0, 0f, 0)));
            if (direction.magnitude >= 0.1f)
            {
                float targetngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;//���������V+��v����V
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetngle, ref tureSmoothvelocity, tureSmoothTime);//�����V* rotationSpeed
                transform.rotation = Quaternion.Euler(0f, angle, 0f);//��V


                Vector3 movedir = Quaternion.Euler(0f, targetngle, 0f) * Vector3.forward;//����*��V

                controller.Move(movedir.normalized * speed * Time.deltaTime * 2);//����
            }
        }
    }
    public void Jump()
    {
        if (characterstats.objectState != characterdata.ObjectState.Dead)
            if ((isGrounded || isclimbing))//�P�_���D
            {
                animator.SetTrigger("Jump");
                velocity.y = Mathf.Sqrt(jumpHeight * -1f * gravity);//�����D�O
                isGrounded = false;
                isclimbing = false;
            }

    }
    public void YMove()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);//Ĳ�o
        isclimbing = Physics.CheckSphere(groundCheck.position, climbingDistance, groundMask);
        //if (!(isGrounded || isclimbing))
        if (!isGrounded && !isclimbing)
        {
            velocity.y += gravity * Time.deltaTime;//���O
        }
        if (Input.GetButtonDown("Jump"))
            Jump();
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0;
        }
        else if (isclimbing && velocity.y < -4)//����U���t��
        {
            velocity.y = -4f;
        }

        controller.Move(velocity * Time.deltaTime * 3);//�W�U���O
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
