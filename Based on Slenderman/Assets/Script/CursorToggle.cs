using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CursorToggle : MonoBehaviour
{
    private bool isCursorLocked;
    public PlayerInputActions pia;

    [SerializeField] private GameObject won;
    [SerializeField] private GameObject back;
    [SerializeField] private Button buttonBack;

    #region PlayerInputActions
    public void Awake()
    {
        pia = new PlayerInputActions();
    }

    public void OnEnable()
    {
        pia.Enable();
    }

    public void OnDisable()
    {
        pia.Disable();
    }
    #endregion

    void Start()
    {
        ToggleCursorState();
    }

    void Update()
    {
        CheckIfWon();
        CheckForInput();
        CheckIfCursorShouldBeLocked();
    }

    void ToggleCursorState()
    {
        isCursorLocked = !isCursorLocked;
    }

    void CheckForInput()
    {
        //Se acerta o Escape muda de State do Cursor para 
        //nao deixar travado e sair da tela do jogo
        if (pia.PlayerActions.ESC.triggered)//Input.GetKeyDown(KeyCode.Escape)
        {
            ToggleCursorState();
        }

        //Consegue clicar se a tela de Won nao estiver ativa
        if(won.gameObject.activeInHierarchy == false)
        {
            if (isCursorLocked == false && pia.PlayerActions.Mouse0.triggered)//Input.GetMouseButtonDown(0)
            {
                if (EventSystem.current.IsPointerOverGameObject())
                {
                    Debug.Log("Clicado na interface do usuario");
                }
                else
                {
                    ToggleCursorState();
                }
                    
            }
        }
    }

    void CheckIfCursorShouldBeLocked()
    {
        //Removendo e travando o cursor na tela do jogo
        if (isCursorLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            back.gameObject.SetActive(false);
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            BackMenu();
        }
    }

    //Se vencer o jogo o cursor volte a normal
    void CheckIfWon()
    {
        if (won.gameObject.activeInHierarchy == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    //O botao para voltar a tela inicial quando apertar ESC
    void BackMenu()
    {
        if (won.gameObject.activeInHierarchy == false)
        {
            back.gameObject.SetActive(true);
            buttonBack.transform.position = new Vector2((Screen.width / 2), Screen.height - buttonBack.GetComponent<RectTransform>().sizeDelta.y / 2 - 200);
        }
    }
}
