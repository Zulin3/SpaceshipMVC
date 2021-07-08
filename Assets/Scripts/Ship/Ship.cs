using UnityEngine;

namespace Assets.Scripts.Ship
{
    internal sealed class Ship: IMove
    {
        private Camera _camera;
        private Transform _shipTransform;
        private float _speed;
        private IMove _moveImplementation;
        private IRotation _rotationImplementation;


        public Ship(Transform shipTransform, float speed, MovementType movementType)
        {
            _camera = Camera.main;
            _shipTransform = shipTransform;
            _speed = speed;
            switch (movementType)
            {
                case MovementType.Casual:
                    _moveImplementation = new MoveTransform(_shipTransform, _speed);
                    break;
                case MovementType.Physics:
                    _moveImplementation = new MovePhysical(_shipTransform, _speed);
                    break;
            }
            _rotationImplementation = new Rotation(_shipTransform);
        }

        public float Speed => _speed;

        public void Move(float horizontal, float vertical, float deltaTime)
        {
            _moveImplementation.Move(horizontal, vertical, deltaTime);
        }

        public void Rotate(float mouseX, float mouseY)
        {
            Vector3 mousePosition = new Vector3(mouseX, mouseY, 0.0f);
            var direction = mousePosition - _camera.WorldToScreenPoint(_shipTransform.position);
            _rotationImplementation.Rotate(direction);
        }
    }

}