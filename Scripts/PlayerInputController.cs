using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    [SerializeField] private Menu _menu;

    private GameInput _gameInput;
    private IContrallable _contrallable;

    private void Awake()
    {
        _gameInput = new GameInput();
        _gameInput.Enable();

        _contrallable = GetComponent<IContrallable>();
    }

    private void OnEnable()
    {
        _gameInput.Keyboard.Jump.performed += OnJumpPerformed;
        _gameInput.Menu.Pause.performed += OnPausePerformed;
        GameOver.OnGameOver += OnGameOverPerformed;
        Menu.OffMenu += OnMenuDisactivate;
        GameOver.OnGameRestart += OnGameRestartPerformed;
    }


    private void OnDisable()
    {
        _gameInput.Keyboard.Jump.performed -= OnJumpPerformed;
        _gameInput.Menu.Pause.performed -= OnPausePerformed;
        GameOver.OnGameOver -= OnGameOverPerformed;
        Menu.OffMenu -= OnMenuDisactivate;
        GameOver.OnGameRestart -= OnGameRestartPerformed;
    }

    private void OnJumpPerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        _contrallable.Jump();
    }
    private void OnPausePerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        _menu.MenuActivate();
        _gameInput.Disable();
    }
    private void OnMenuDisactivate()
    {
        _gameInput.Enable();
    }
    private void OnGameRestartPerformed()
    {
        _gameInput.Enable();
    }
    private void OnGameOverPerformed()
    {
        _gameInput.Disable();
    }
}