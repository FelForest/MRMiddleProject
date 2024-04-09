using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Player Rigidbody
    private Rigidbody player;
    // player �̵� �ӵ�
    public float walkingSpeed = 5.0f;
    public float runningSpeed = 7.5f;
    private float speed;

    private bool isRunning = false;

    private bool isMoving = false;
    // player ����
    private Vector3 moveDir = Vector3.zero;

    //�߷� ���߿� Ʈ�� ���鶧�� ���� �� ������
    private float graviy = 98f;

    private void Awake()
    {
        player = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �޸��� ���
        isRunning = Input.GetKey(KeyCode.LeftShift) ? true : false;
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        // KeyButtonInput
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        
        moveDir = new Vector3(horizontalInput,0,verticalInput);

        speed = isRunning ? runningSpeed : walkingSpeed;

        transform.position += moveDir * speed * Time.deltaTime;
    }

    void PlayerAnimition()
    {

    }
}
