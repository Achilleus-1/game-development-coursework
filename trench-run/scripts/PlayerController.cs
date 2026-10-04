using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float laneWidth = 4f;

    private int currentLane = 0;
    private GameInputActions input;

    
    
    void Awake()
    {
        input = new GameInputActions();
    }

    
    void OnEnable()
    {
        input.Player.Enable();
        input.Player.MoveLeft.performed += MoveLeft;
        input.Player.MoveRight.performed += MoveRight;
    }

    
    
    void OnDisable()
    {
        input.Player.MoveLeft.performed -= MoveLeft;
        input.Player.MoveRight.performed -= MoveRight;
        input.Player.Disable();
    }

    
    
    void Update()
    {
        // moving code
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.World);
    }

    
    
    private void MoveLeft(InputAction.CallbackContext context)
    {
        if (currentLane > -1)
        {
            currentLane--;
            UpdateLanePosition();
        }
    }

    private void MoveRight(InputAction.CallbackContext context)
    {
        if (currentLane < 1)
        {
            currentLane++;
            UpdateLanePosition();
        }
    }

    private void UpdateLanePosition()
    {
        Vector3 pos = transform.position;
        pos.x = currentLane * laneWidth;
        transform.position = pos;
    }
}