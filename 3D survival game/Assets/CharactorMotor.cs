using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharactorMotor : MonoBehaviour
{
    [HideInInspector]
    public Vector3 velocity = Vector3.zero;
    [HideInInspector]
    public Vector3 rotation = Vector3.zero;
    [HideInInspector]
    public float camRotationX = 0;

    private Rigidbody rb = null;
    [SerializeField]
    private Transform cam = null;

    //Called when initialized
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    //Called on every physics update
    private void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }

    //Performs movement on a physics update
    private void PerformMovement()
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
    }

    //Performs a movement on a physics update
    private void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));

        if (cam != null)
        {
            cam.localEulerAngles += Vector3.right * camRotationX;
        }
    }
}
