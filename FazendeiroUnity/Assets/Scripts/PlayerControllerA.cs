using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerA : MonoBehaviour
{
    public float speed = 20f;
    public float xRange = 15f;
    public GameObject projectilePrefab;

    public InputActionAsset inputActions;

    private InputAction moveAction;
    private InputAction fireAction;
    private InputAction pauseAction;
    private bool Pause = false;
    public GameObject Pausado;

    void Start()
    {
        Pause = false;
        Pausado.SetActive(false);
    }

    private void OnEnable()
    {
        inputActions.FindActionMap("Player").Enable();
        inputActions.FindActionMap("UI").Disable();
        Pause = false;
        pauseAction = InputSystem.actions.FindAction("Pause");
        Pausado.SetActive(false);
    }

    private void OnDisable()
    {
        inputActions.FindActionMap("Player").Disable();
        inputActions.FindActionMap("UI").Enable();
        Pause = true;
        pauseAction = InputSystem.actions.FindAction("Pause");
        Pausado.SetActive(true);
    }

    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        fireAction = InputSystem.actions.FindAction("Jump");
    }

    void Update()
    {
        float horizontalInput = moveAction.ReadValue<Vector2>().x;
        transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.y);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.y);
        }

        if (fireAction.WasPressedThisFrame())
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
        if(pauseAction.WasPressedThisFrame())
        {
            if(Pause == false)
            {
                OnDisable();
            } else
            {
                OnEnable();
            }
        }
    }
}
