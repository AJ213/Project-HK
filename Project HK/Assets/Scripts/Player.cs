using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed;
    public float rotationSpeed;
    private Rigidbody rigidBody;

    private void FixedUpdate()
    {
        PlayerInput();
    }
    private void Move(float xInput, float yInput, float speed)
    {
        if (xInput != 0 || yInput != 0)
        {
            float inputDirectionRadians = Mathf.Atan2(-xInput, yInput); //Note: Atan2 parameters model a -90 degree rotation
            float translationDirectionRadians = inputDirectionRadians - (Mathf.Deg2Rad * this.gameObject.transform.eulerAngles.y);
            Vector3 moveLocation = new Vector3(Mathf.Cos(translationDirectionRadians), 0, Mathf.Sin(translationDirectionRadians));
            rigidBody.velocity = speed * moveLocation;
        }
        else
        {
            rigidBody.velocity = Vector3.zero;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        this.gameObject.transform.eulerAngles = new Vector3(-90, this.gameObject.transform.eulerAngles.z + this.gameObject.transform.eulerAngles.y, 0);
    }
    private void OnCollisionStay(Collision collision)
    {
        this.gameObject.transform.eulerAngles = new Vector3(-90, this.gameObject.transform.eulerAngles.z + this.gameObject.transform.eulerAngles.y, 0);
    }
    private void PlayerInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float rotation = Input.GetAxis("Horizontal2");
        Move(horizontal, vertical, playerSpeed);
        Rotate(rotation);
    }
    private void Rotate(float xInput)
    {
        if (xInput != 0)
        {
            rigidBody.angularVelocity = new Vector3(0, xInput * rotationSpeed, 0);
        }
        else
        {
            rigidBody.angularVelocity = Vector3.zero;
        }
    }

    private void Start()
    {
        rigidBody = this.gameObject.GetComponent<Rigidbody>();
    }
}