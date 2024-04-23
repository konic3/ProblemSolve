using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float speed = 5.0f;
    public Transform target; // ī�޶� ����ٴ� ���(ĳ����)�� Transform
    public Camera MC;
    public Transform character; // ĳ������ Transform

    bool isRotating = false;
    Vector3 rotationAxis;
    Quaternion startRotation;
    Quaternion targetRotation;
    float rotationTime = 1.0f; // ȸ�� �ð�
    float rotationStartTime; // ȸ�� ���� �ð�

    void Update()
    {
        // ī�޶� �̵�
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
            MC.transform.Translate(Vector3.down * (speed-1.5f) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            MC.transform.Translate(Vector3.up * (speed - 1.5f) * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            MC.transform.Translate(Vector3.left * speed * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            MC.transform.Translate(Vector3.right * speed * Time.deltaTime);

        }

        // ī�޶� ȸ��
        if (Input.GetKeyDown(KeyCode.O) && !isRotating)
        {
            StartRotation(Vector3.up);
        }
        if (Input.GetKeyDown(KeyCode.P) && !isRotating)
        {
            StartRotation(Vector3.down);
        }

        // ȸ�� ���� ��
        if (isRotating)
        {
            // ȸ�� �ִϸ��̼�
            float elapsedTime = Time.time - rotationStartTime;
            float t = elapsedTime / rotationTime;

            MC.transform.RotateAround(target.position, rotationAxis, 90 * Time.deltaTime / rotationTime); // 90�� ȸ��

            // ȸ���� �Ϸ�Ǿ����� Ȯ��
            if (elapsedTime >= rotationTime)
            {
                isRotating = false;
            }
        }
    }

    // ȸ�� ����
    void StartRotation(Vector3 axis)
    {
        isRotating = true;
        rotationAxis = axis;
        startRotation = MC.transform.rotation;
        targetRotation = startRotation * Quaternion.Euler(axis * 90); // ��ǥ ȸ�� ����
        rotationStartTime = Time.time;

        // ĳ������ ������ ȸ�� ����� ��ġ��Ŵ
        character.rotation = Quaternion.Euler(character.rotation.eulerAngles + axis * 90);
    }
}
