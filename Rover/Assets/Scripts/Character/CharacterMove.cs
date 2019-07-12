using System.Collections;
using UnityEngine;
//using UnityEngine.InputSystem;

public class CharacterMove : MonoBehaviour
{
  //  private InputAction movement;
  //  [Space] [SerializeField] private InputActionAsset inputActionAsset;




    [SerializeField] private float movementSpeed;



    private CharacterController charController;
    private float slopeLimit;


    [SerializeField] private AnimationCurve jumpFallOff;

    [SerializeField] private float jumpMultiplier;

    [SerializeField] private KeyCode jumpKey;


    private bool isJumping;


    private void Awake()
    {
        charController = GetComponent<CharacterController>();
        slopeLimit = charController.slopeLimit;
    }

    private void FixedUpdate()
    {
        
    }

    private void Update()

    {

       // PlayerMovement();

    }



    private void PlayerMovement()

    {

     //   float horizInput = Input.GetAxis(horizontalInputName) * movementSpeed;

       // float vertInput = Input.GetAxis(verticalInputName) * movementSpeed;



        //Vector3 forwardMovement = transform.forward * vertInput;

        //Vector3 rightMovement = transform.right * horizInput;



        //charController.SimpleMove(forwardMovement + rightMovement);



        //JumpInput();



    }



    private void JumpInput()

    {

        if (Input.GetKeyDown(jumpKey) && !isJumping)

        {

            isJumping = true;

            StartCoroutine(JumpEvent());

        }

    }



    private IEnumerator JumpEvent()

    {

        charController.slopeLimit = 90.0f;

        float timeInAir = 0.0f;

        do
        {
            float jumpForce = jumpFallOff.Evaluate(timeInAir);

            charController.Move(Vector3.up * jumpForce * jumpMultiplier * Time.deltaTime/2);

            timeInAir += Time.deltaTime;

            yield return null;

        } while (!charController.isGrounded && charController.collisionFlags != CollisionFlags.Above);


        charController.slopeLimit = slopeLimit;

        isJumping = false;
    }
}