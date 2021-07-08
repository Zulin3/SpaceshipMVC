using Assets.Scripts.Data;
using Assets.Scripts.Ship;
using UnityEngine;

internal sealed class PlayerController : IExecute, IFixedExecute, IInitialization, ICleanup
{
    private readonly IPlayerFactory _playerFactory;
    private Transform _player;
    private Ship _ship;
    private IUserInputProxy _inputHorizontal;
    private IUserInputProxy _inputVertical;
    private MovementType _movementType;
    private IUserMouseInputProxy _inputMouse;

    private float _vertical;
    private float _horizontal;

    private float _mouseX;
    private float _mouseY;

    public PlayerController(IPlayerFactory playerFactory, Vector2 position, (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) input, IUserMouseInputProxy inputMouse, PlayerData playerData)
    {
        _playerFactory = playerFactory;
        _player = _playerFactory.CreatePlayer();
        _player.position = position;
        _inputHorizontal = input.inputHorizontal;
        _inputVertical = input.inputVertical;
        _movementType = playerData.MovementType;

        _inputMouse = inputMouse;

        _ship = new Ship(_player, playerData.Speed, _movementType);

        _inputHorizontal.AxisOnChange += HorizontalAxisOnChange;
        _inputVertical.AxisOnChange += VerticalAxisOnChange;

        _inputMouse.OnMouseMove += MouseXOnChange;
    }

    private void MouseXOnChange(float mouseX, float mouseY)
    {
        _mouseX = mouseX;
        _mouseY = mouseY;
    }
    
    private void MouseYOnChange(float value)
    {
        _mouseY = value;
    }

    private void HorizontalAxisOnChange(float value)
    {
        _horizontal = value;
    }
    
    private void VerticalAxisOnChange(float value)
    {
        _vertical = value;
    }

    public void Cleanup()
    {
        _inputHorizontal.AxisOnChange -= HorizontalAxisOnChange;
        _inputVertical.AxisOnChange -= VerticalAxisOnChange;
    }

    public void Execute(float deltaTime)
    {
        if (_movementType == MovementType.Casual)
        {
            _ship.Move(_horizontal, _vertical, deltaTime);
        }
        _ship.Rotate(_mouseX, _mouseY);
    }

    public void FixedExecute()
    {
        if (_movementType == MovementType.Physics)
        {
            _ship.Move(_horizontal, _vertical, Time.deltaTime);
        }
        
    }

    public void Initialize()
    {

    }
}
