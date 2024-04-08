using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // playerController
    private CharacterController player;

    // player 이동 속도
    public float walkingSpeed = 5.0f;
    public float runningSpeed = 7.5f;
    private float speed;

    // player 방향
    private Vector3 moveDir = Vector3.zero;

    //중력 나중에 트릭 만들때는 따로 빼 놓을듯
    private float graviy = 98f;

    private void Awake()
    {
        // controller 받아오기
        player = transform.GetComponent<CharacterController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 혹시 못 받아오는 경우 대비
        if (player == null)
        {
            Debug.Log("Player 없음");
            return;
        }

        // 달리기 기능
        speed = Input.GetKey(KeyCode.LeftShift) ? runningSpeed : walkingSpeed;
        
        Move(speed);
    }

    void Move(float speed)
    {
        // 키보드로 입력 받을시
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // 이동 방향 결정
        moveDir = new Vector3(horizontalInput, 0, verticalInput);
        moveDir = player.transform.TransformDirection(moveDir);

        //중력 적용
        moveDir.y -= graviy * speed * Time.deltaTime;

        // 이동
        player.Move(moveDir * speed * Time.deltaTime);
    }
}
