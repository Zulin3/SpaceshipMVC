using UnityEngine;

namespace Assets.Scripts.Ship
{
    internal class MovePhysical : IMove
    {
        private Transform _shipTransform;
        private float _speed;
        private Rigidbody _rb;

        public MovePhysical(Transform shipTransform, float speed)
        {
            _shipTransform = shipTransform;
            _rb = _shipTransform.gameObject.AddRigidbody();
            _speed = speed;
        }

        public float Speed => _speed;

        public void Move(float horizontal, float vertical, float deltaTime)
        {
            Vector3 movement = new Vector3(horizontal, vertical, 0.0f);
            _rb.AddForce(movement * deltaTime * _speed);
        }
    }
}