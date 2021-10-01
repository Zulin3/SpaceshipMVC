using Assets.Scripts.Bullets;
using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Ship
{
    class Shoot : IShoot
    {
        private BulletPool _pool;
        private float _speed;
        private bool _playerBullet;
        private float _damage;

        public Shoot(BulletPool pool, float speed, bool playerBullet, float damage)
        {
            _pool = pool;
            _speed = speed;
            _playerBullet = playerBullet;
            _damage = damage;
        }

        public void ShootBullet(Transform origin)
        {
            _pool.AddBullet(origin, _playerBullet, _damage, _speed);
        }
    }
}
