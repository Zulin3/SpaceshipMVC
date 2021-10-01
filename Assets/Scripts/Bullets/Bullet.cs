using Assets.Scripts.Enemies;
using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Bullets
{
    public class Bullet : MonoBehaviour, IBullet, IPoolable, IExecute, IFixedExecute, IInitialization, ICleanup
    {
        private const float BULLET_LIVE_TIME = 5;
        private Transform _transform;
        private bool _playerBullet;
        private float _damage;
        private float _speed;
        private float _time_left = BULLET_LIVE_TIME;

        private BulletPool Pool {
            get;
            set;
        }

        public static Bullet CreateBullet(BulletPool pool, Transform position, bool playerBullet, float damage, float speed)
        {
            var bullet = Instantiate(Resources.Load<Bullet>("Bullets/Bullet"));

            bullet.Pool = pool;
            bullet._transform = bullet.transform;
            var dd = bullet._transform.GetComponent<DamageDealer>();
            dd.InitDamageDealer(damage, !playerBullet, playerBullet, true);

            bullet.InitBullet(position, playerBullet, damage, speed);
            bullet._playerBullet = true;
            return bullet;
        }

        public void InitBullet(Transform position, bool playerBullet, float damage, float speed)
        {
            _transform.position = position.position;
            _transform.rotation = position.rotation;
            _playerBullet = playerBullet;
            _damage = damage;
            _speed = speed;
            _time_left = BULLET_LIVE_TIME;
        }

        public void ReturnToPool()
        {
            
            Pool.ReturnToPool(this);
        }

        public void Execute(float deltaTime)
        {
            _transform.localPosition += _transform.right * deltaTime * _speed;
            _time_left -= deltaTime;
            if (_time_left <= 0)
            {
                ReturnToPool();
            }
        }

        public void FixedExecute()
        {

        }

        public void Initialize()
        {
        }

        public void Cleanup()
        {
        }
    }
}
