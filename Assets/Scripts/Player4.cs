using UnityEngine;
using UnityEngine.InputSystem;

public class Player4 : MonoBehaviour
{
    private CharacterController _characon;
    private PlayerInput _input;
    Vector3 direction;
    float speed = 5.0f;
    bool is_walking = false;
    bool is_running = false;

    private void Awake()
    {
        TryGetComponent(out _characon);
        TryGetComponent(out _input);
    }

    private void OnEnable()
    {
        _input.actions["Move"].performed += OnMove4;
        _input.actions["Move"].canceled += OnMove4;
        _input.actions["Dash"].started += OnDash4;
        _input.actions["Dash"].canceled += OnDash4;
    }

    private void OnDisable()
    {
        _input.actions["Move"].performed -= OnMove4;
        _input.actions["Move"].canceled -= OnMove4;
        _input.actions["Dash"].started -= OnDash4;
        _input.actions["Dash"].canceled -= OnDash4;
    }

    private void OnMove4(InputAction.CallbackContext obj)
    {
        var value = obj.ReadValue<Vector2>();
        direction = new Vector3(value.x, 0, value.y);
        is_walking = value.x != 0 && value.y != 0;
    }

    private void OnDash4(InputAction.CallbackContext obj)
    {
        is_running = obj.phase == InputActionPhase.Started ? true : false;
    }

    void Start()
    {

    }

    void Update()
    {
        var _speed = is_running ? speed * 2.0f : speed;
        _characon.Move(direction * _speed * Time.deltaTime);
    }
}
