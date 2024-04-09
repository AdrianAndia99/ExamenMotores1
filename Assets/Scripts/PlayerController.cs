using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public GameObject[] characters;
    private int currentCharacterIndex = 0;
    private Rigidbody rb;
    public float speed = 5f;
    public float jumpForce = 3f;
    private Vector3 movementInput;
    private PlayerInput playerInput;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();

        SwitchCharacter(currentCharacterIndex);

    }

    private void Update()
    {
        Vector3 movement = new Vector3(movementInput.x, 0f, movementInput.y);
        rb.velocity = movement;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            SwitchCharacter(currentCharacterIndex - 1);
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            SwitchCharacter(currentCharacterIndex + 1);
        }
    }

    private void SwitchCharacter(int index)
    {
        characters[currentCharacterIndex].GetComponent<PlayerController>().enabled = false;

        currentCharacterIndex = Mathf.Clamp(index, 0, characters.Length - 1);

        characters[currentCharacterIndex].GetComponent<PlayerController>().enabled = true;
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector3>();
    }
    public void OnJumpPerformed(InputAction.CallbackContext context)
    {
        Jump();
    }
}