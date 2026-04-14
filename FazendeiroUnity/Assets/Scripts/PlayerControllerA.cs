using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class PlayerControllerA : MonoBehaviour
{
    public float speed = 20f;
    public float xRange = 15f;
    public GameObject projectilePrefab;

    public InputActionAsset inputActions;

    private InputAction moveAction;
    private InputAction fireAction;
    private InputAction ghostAction;
    private InputAction pauseActionUI;
    private InputAction pauseActionPlayer;
    public GameObject Pausado;
    public GameObject ghost;
    public bool BGhost;
    private int vida;
    private int vidaM = 3;
    [SerializeField] Image vidaOn1;
    [SerializeField] Image vidaOff1;

    [SerializeField] Image vidaOn2;
    [SerializeField] Image vidaOff2;

    [SerializeField] Image vidaOn3;
    [SerializeField] Image vidaOff3;

    void Start()
    {
        vida = vidaM;

        ghost = GameObject.Find("/Player/SF_Character_FarmersWife");
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
        ghostAction = InputSystem.actions.FindAction("Ghost");
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
        if (ghostAction.WasPressedThisFrame())
        {
            ghost.SetActive(false);
            BGhost = true;
            StartCoroutine(Ghost(2));
        }
        PauseGame();
    }

    private IEnumerator Ghost(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        ghost.SetActive(true);
        BGhost = false;
    }

    private void OTriggerEnter(Collider col)
     {
         if(col.gameObject.CompareTag("AnimalD"))
         {
             if(BGhost == true)
             {
                 return;
             }
             else
             {
                 Dano();
             }
         }
     }

    private void Dano()
    {
        vida -= 1;

        if (vida == 2)
        {
            vidaOn3.enabled = true;
            vidaOff3.enabled = false;
        }
        if (vida == 1)
        {
            vidaOn2.enabled = true;
            vidaOff2.enabled = false;
        }
        if (vida <= 0)
        {
            vidaOn1.enabled = true;
            vidaOff1.enabled = false;

            GameObject.Find("MenuManager").GetComponent<MainMenuManager>().GameOver();
        }
    }
}
