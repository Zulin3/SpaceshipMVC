using Assets.Scripts.Bullets;
using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Ship
{
    internal sealed class Ship
    {
        private Camera _camera;
        private Transform _shipTransform;
        private float _speed;
        private SphereCollider _collider;
        private IMove _moveImplementation;
        private IRotation _rotationImplementation;
        private IShoot _shootImplementation;

        public Ship(Transform shipTransform, BulletPool bulletPool, float speed, MovementType movementType, float colliderRadius, float bulletSpeed, float bulletDamage)
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
            _collider = shipTransform.GetComponent<SphereCollider>();
            _collider.radius = colliderRadius;
            _shootImplementation = new Shoot(bulletPool, bulletSpeed, true, bulletDamage);
        }

        public float Speed => _speed;

        public void Fire()
        {
            _shootImplementation.ShootBullet(_shipTransform);
        }

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