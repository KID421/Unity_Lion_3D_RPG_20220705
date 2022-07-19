using UnityEngine;

namespace KID
{
    public class ThirdPersonMovement : MonoBehaviour
    {
        [SerializeField]
        private float speed = 3.5f;
        [SerializeField]
        private float turn = 5;

        private CharacterController controller;
        private Transform traCamera;
        private Vector3 velocity;

        private void Awake()
        {
            controller = GetComponent<CharacterController>();
            traCamera = Camera.main.transform;
        }

        private void Update()
        {
            Movement();
            Jump();
        }

        private void Movement()
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            velocity = transform.right * h + transform.forward * v + transform.up * velocity.y;

            transform.rotation = Quaternion.Slerp(transform.rotation, traCamera.rotation, turn * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

            controller.Move(velocity * speed * Time.deltaTime);
        }

        private void Jump()
        {
            if (controller.isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                velocity.y = 5;
            }

            velocity.y += Physics.gravity.y * Time.deltaTime;
        }
    }
}

