using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    [Header("Скорость поворота при вращении камеры по оси ОХ")]
    [SerializeField] private float xAxisRotateSpeed = 100f;

    [Header("Скорость поворота при вращении камеры по оси ОY")]
    [SerializeField] private float yAxisRotateSpeed = 15;

    [Header("Камера от 1 лица")]
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    [Header("Максимальное значение подъема камера по оси У")]
    [SerializeField] private float maxYAxisValue = 15f;

    private float horizontal;
    private float vertical;

    private Vector3 moveDirection;

    private CinemachineTransposer virtualCameraTranspose;

    private void Awake()
    {
        PlayerMovement.MoveVector += SetMoveVector;
        virtualCameraTranspose = virtualCamera.GetCinemachineComponent<CinemachineTransposer>();
    }

    private void OnDisable()
    {
        PlayerMovement.MoveVector -= SetMoveVector;
    }
    private void Update()
    {
        HorizontalCameraMove();
        VerticalCameraMove();
        if (horizontal != 0) RotatePlayer();
        if (vertical != 0) RotateCamera();
    }

    private void HorizontalCameraMove()
    {
        horizontal = Input.GetAxis("Mouse X") * xAxisRotateSpeed;

       
    }

    private void VerticalCameraMove()
    {
        vertical = Input.GetAxis("Mouse Y") * yAxisRotateSpeed;
    }

    private void RotatePlayer()
    {
        transform.Rotate(0f, horizontal * Time.deltaTime, 0f);
    }

    private void SetMoveVector(Vector3 direction)
    {
        moveDirection = direction;
    }

    private void RotateCamera()
    {
        Vector3 folloPosition = virtualCameraTranspose.m_FollowOffset;

        folloPosition.y += vertical*Time.deltaTime;
        folloPosition.y = SetValueInRange(folloPosition.y, -maxYAxisValue, maxYAxisValue);

        virtualCameraTranspose.m_FollowOffset = folloPosition;

    }

    private float SetValueInRange(float value, float minValue, float maxValue)
    {
        if (value > maxValue) value = maxValue;
        else if (value < minValue) value = minValue;
        return value;
    }
}
