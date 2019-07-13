using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using InputActions;
using static InputActions.GameInputActions;

public class CharacterMove : MonoBehaviour, ICharacterActions
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private AnimationCurve jumpFallOff;
    [SerializeField] private float jumpMultiplier;

    private GameInputActions gameInputActions;
    private CharacterController charController;
    private float slopeLimit;
    private bool isJumping;
    private Vector2 direction;

    private void Awake()
    {
        gameInputActions = new GameInputActions();
        gameInputActions.Character.SetCallbacks(this);

        charController = GetComponent<CharacterController>();
        slopeLimit = charController.slopeLimit;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();

        Vector3 forwardMovement = transform.forward * direction.y * movementSpeed;
        Vector3 rightMovement = transform.right * direction.x * movementSpeed;

        charController.SimpleMove(forwardMovement + rightMovement);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        isJumping = true;
        StartCoroutine(JumpEvent());
    }

    private void OnEnable()
    {
        gameInputActions.Enable();
    }

    private void OnDisable()
    {
         gameInputActions.Disable();
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