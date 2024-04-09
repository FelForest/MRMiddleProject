using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
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

    // player 감도
    public float sensitivity = 500.0f;

    private Vector2 viewPoint = Vector2.zero;

    public GameObject Eyes;

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
        ViewPointSet();
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

    void ViewPointSet()
    {
        // ���콺 X,Y �� ������ ��
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        //Debug.Log(mouseY);

        viewPoint.x -= mouseY * sensitivity * Time.deltaTime;
        viewPoint.y += mouseX * sensitivity * Time.deltaTime;

        viewPoint.x = viewPoint.x > 30 ? 30 : viewPoint.x;
        viewPoint.x = viewPoint.x < -35 ? -35 : viewPoint.x;

        transform.eulerAngles = new Vector3(0, viewPoint.y, 0);
        Eyes.transform.localEulerAngles = new Vector3(viewPoint.x, 0, 0);
    }
}
