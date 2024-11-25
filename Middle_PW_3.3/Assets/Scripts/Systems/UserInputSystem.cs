using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class UserInputSystem : ComponentSystem
{
    // Переменная (запрос на движение)
    private EntityQuery _inputQuery;

    // Переменная (наш ввод)
    private InputAction _moveAction;

    private InputAction _shootAction;

    private InputAction _burstAction;

    private float2 _moveInput;

    private float _shootInput;

    private float _burstInput;

    /// <summary>
    /// Создание системы (кэшируем запрос: наша система берёт все энтити у которых есть компонент UserInputData (все энтити, которым нужен Input)
    /// </summary>
    protected override void OnCreate()
    {        
        _inputQuery = GetEntityQuery(ComponentType.ReadOnly<InputData>());
    }

    /// <summary>
    /// Запуск системы (создаем новый InputAction)
    /// </summary>
    protected override void OnStartRunning()
    {
        _moveAction = new InputAction("move", binding: "<Gamepad>/rightStick");

        _moveAction.AddCompositeBinding("Dpad")
            .With("Up", "<Keyboard>/w")
            .With("Down", "<Keyboard>/s")
            .With("Left", "<Keyboard>/a")
            .With("Right", "<Keyboard>/d");

        // Заполняем все возможные состояния устройства ввода
        _moveAction.performed += context => { _moveInput = context.ReadValue<Vector2>(); };

        _moveAction.started += context => { _moveInput = context.ReadValue<Vector2>(); };

        _moveAction.canceled += context => { _moveInput = context.ReadValue<Vector2>(); };

        _moveAction.Enable();

        // Стрельба
        _shootAction = new InputAction("shoot", binding: "<Keyboard>/Space");

        _shootAction.performed += context => { _shootInput = context.ReadValue<float>(); };

        _shootAction.started += context => { _shootInput = context.ReadValue<float>(); };

        _shootAction.canceled += context => { _shootInput = context.ReadValue<float>(); };

        _shootAction.Enable();

        // Рывок
        _burstAction = new InputAction("burst", binding: "<Keyboard>/Tab");

        _burstAction.performed += context => { _burstInput = context.ReadValue<float>(); };

        _burstAction.started += context => { _burstInput = context.ReadValue<float>(); };

        _burstAction.canceled += context => { _burstInput = context.ReadValue<float>(); };

        _burstAction.Enable();
    }

    // Срабатывает когда отключается система
    protected override void OnStopRunning()
    {
        _moveAction.Disable();

        _shootAction.Disable();

        _burstAction.Disable();
    }

    protected override void OnUpdate() 
    {
        Entities.With(_inputQuery).ForEach(
            (Entity entity, ref InputData inputData) => 
            { 
                inputData.Move = _moveInput; 

                inputData.Shoot = _shootInput;

                inputData.BurstMove = _burstInput;
            });
    }
}
