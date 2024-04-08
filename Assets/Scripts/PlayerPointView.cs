using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPointView : MonoBehaviour
{
    // 시점 속도
    public float sensitivity = 500.0f;

    // 시점
    private Vector2 viewPoint = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        // 마우스 커서 안보이게 하기
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // 마우스 X,Y 축 움직임 값
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        //Debug.Log(mouseY);

        viewPoint.x -= mouseY * sensitivity * Time.deltaTime;
        viewPoint.y += mouseX * sensitivity * Time.deltaTime;

        viewPoint.x = viewPoint.x > 30 ? 30 : viewPoint.x;
        viewPoint.x = viewPoint.x < -35 ? -35 : viewPoint.x;

        transform.eulerAngles = new Vector3(viewPoint.x, viewPoint.y, 0);

    }

    private void OnDestroy()
    {
        //게임 끝나면 커서 보이겜
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
