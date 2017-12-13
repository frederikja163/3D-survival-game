using UnityEngine;

[RequireComponent(typeof(CharactorMotor))]
public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float movementSpeed = 10f;
    [SerializeField]
    private float sensitivity = 3f;

    private CharactorMotor motor = null;

    //Called when initialized
    private void Start()
    {
        motor = GetComponent<CharactorMotor>();
    }

    //Called on every frame
    private void Update()
    {
        UpdateMovement();
        UpdateRotation();
    }

    //Updates movement every frame
    private void UpdateMovement()
    {
        Vector3 movX = transform.right * Input.GetAxisRaw("Horizontal");
        Vector3 movZ = transform.forward * Input.GetAxisRaw("Vertical");

        Vector3 velocity = (movX + movZ).normalized * movementSpeed;

        motor.velocity = velocity;
    }

    //Updates rotation every frame
    private void UpdateRotation()
    {
        Vector3 rotation = transform.up * Input.GetAxisRaw("Mouse X");

        motor.rotation = rotation * sensitivity;

        motor.camRotationX = -Input.GetAxisRaw("Mouse Y") * sensitivity;
    }
}