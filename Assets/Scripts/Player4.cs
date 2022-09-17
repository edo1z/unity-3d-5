using UnityEngine;
using UnityEngine.InputSystem;

public class Player4 : MonoBehaviour
{
    public float default_speed = 5.0f;
    public float ground_radius = 3.0f;
    public LayerMask ground_layers;

    private CharacterController _characon;
    private PlayerInput _input;
    private Animator _animator;
    Vector3 direction;

    bool is_running = false;
    bool is_grounded = false;

    private void Awake()
    {
        TryGetComponent(out _characon);
        TryGetComponent(out _input);
        TryGetComponent(out _animator);
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
        Debug.Log("direction: " + direction);
    }

    private void OnDash4(InputAction.CallbackContext obj)
    {
        is_running = obj.phase == InputActionPhase.Started ? true : false;
    }

    private void grounded_check()
    {
        is_grounded = Physics.CheckSphere(transform.position, ground_radius, ground_layers, QueryTriggerInteraction.Ignore);
        _animator.SetBool("is_grounded", is_grounded);
    }

    private void move()
    {
        var _speed = is_running ? default_speed * 2.0f : default_speed;
        var distance = direction * _speed * Time.deltaTime;
        _characon.Move(distance);
        _animator.SetFloat("walk_speed", distance.magnitude);
    }

    void Update()
    {
        grounded_check();
        move();
    }
}
