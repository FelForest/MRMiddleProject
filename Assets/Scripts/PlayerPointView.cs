using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPointView : MonoBehaviour
{
    // ���� �ӵ�
    public float sensitivity = 500.0f;

    // ����
    private Vector2 viewPoint = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        // ���콺 Ŀ�� �Ⱥ��̰� �ϱ�
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // ���콺 X,Y �� ������ ��
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
        //���� ������ Ŀ�� ���̰�
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void ViewPointController()
    {
        // ���콺 X,Y �� ������ ��
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        //Debug.Log(mouseY);

        viewPoint.x -= mouseY * sensitivity * Time.deltaTime;
        viewPoint.y += mouseX * sensitivity * Time.deltaTime;

        viewPoint.x = viewPoint.x > 30 ? 30 : viewPoint.x;
        viewPoint.x = viewPoint.x < -35 ? -35 : viewPoint.x;

        transform.eulerAngles = new Vector3(viewPoint.x, viewPoint.y, 0);
    }
}
