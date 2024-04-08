using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // playerController
    private CharacterController player;

    // player �̵� �ӵ�
    public float walkingSpeed = 5.0f;
    public float runningSpeed = 7.5f;
    private float speed;

    // player ����
    private Vector3 moveDir = Vector3.zero;

    //�߷� ���߿� Ʈ�� ���鶧�� ���� �� ������
    private float graviy = 98f;

    private void Awake()
    {
        // controller �޾ƿ���
        player = transform.GetComponent<CharacterController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Ȥ�� �� �޾ƿ��� ��� ���
        if (player == null)
        {
            Debug.Log("Player ����");
            return;
        }

        // �޸��� ���
        speed = Input.GetKey(KeyCode.LeftShift) ? runningSpeed : walkingSpeed;
        
        Move(speed);
    }

    void Move(float speed)
    {
        // Ű����� �Է� ������
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // �̵� ���� ����
        moveDir = new Vector3(horizontalInput, 0, verticalInput);
        moveDir = player.transform.TransformDirection(moveDir);

        //�߷� ����
        moveDir.y -= graviy * speed * Time.deltaTime;

        // �̵�
        player.Move(moveDir * speed * Time.deltaTime);
    }
}
