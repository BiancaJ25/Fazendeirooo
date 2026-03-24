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
    private InputAction pauseActionUI;
    private InputAction pauseActionPlayer;
    public GameObject Pausado;

    void Start()
    {
        
    }

    private void OnEnable()
    {
        inputActions.FindActionMap("Player").Enable();
    }

    private void OnDisable()
    {
        inputActions.FindActionMap("Player").Disable();
    }

    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        fireAction = InputSystem.actions.FindAction("Jump");
        pauseActionPlayer = InputSystem.actions.FindAction("Player/Pause");
        pauseActionUI = InputSystem.actions.FindAction("UI/Pause");
    }

    private void PauseGame()
    {
        if(pauseActionPlayer.WasPressedThisFrame())
        {
           inputActions.FindActionMap("Player").Disable();
           inputActions.FindActionMap("UI").Enable();
           Pausado.SetActive(true);
        } else if(pauseActionUI.WasPressedThisFrame())
        {
           inputActions.FindActionMap("Player").Enable();
           inputActions.FindActionMap("UI").Disable();
           Pausado.SetActive(false);
        }
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
    }
}
