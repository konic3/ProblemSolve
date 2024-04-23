using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float speed = 5.0f;
    public Transform target; // 카메라가 따라다닐 대상(캐릭터)의 Transform
    public Camera MC;
    public Transform character; // 캐릭터의 Transform

    bool isRotating = false;
    Vector3 rotationAxis;
    Quaternion startRotation;
    Quaternion targetRotation;
    float rotationTime = 1.0f; // 회전 시간
    float rotationStartTime; // 회전 시작 시간

    void Update()
    {
        // 카메라 이동
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

        // 카메라 회전
        if (Input.GetKeyDown(KeyCode.O) && !isRotating)
        {
            StartRotation(Vector3.up);
        }
        if (Input.GetKeyDown(KeyCode.P) && !isRotating)
        {
            StartRotation(Vector3.down);
        }

        // 회전 중일 때
        if (isRotating)
        {
            // 회전 애니메이션
            float elapsedTime = Time.time - rotationStartTime;
            float t = elapsedTime / rotationTime;

            MC.transform.RotateAround(target.position, rotationAxis, 90 * Time.deltaTime / rotationTime); // 90도 회전

            // 회전이 완료되었는지 확인
            if (elapsedTime >= rotationTime)
            {
                isRotating = false;
            }
        }
    }

    // 회전 시작
    void StartRotation(Vector3 axis)
    {
        isRotating = true;
        rotationAxis = axis;
        startRotation = MC.transform.rotation;
        targetRotation = startRotation * Quaternion.Euler(axis * 90); // 목표 회전 각도
        rotationStartTime = Time.time;

        // 캐릭터의 방향을 회전 방향과 일치시킴
        character.rotation = Quaternion.Euler(character.rotation.eulerAngles + axis * 90);
    }
}
