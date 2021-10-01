using Assets.Scripts.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Bullets
{
    public class BulletPool
    {
        private readonly int _capacity;
        private int _bulletsCount;
        private Transform _deadBulletPlace;
        private HashSet<Bullet> _activeBullets;
        private HashSet<Bullet> _disabledBullets;

        public HashSet<Bullet> ActiveBullets
        {
            get
            {
                return _activeBullets;
            }
        }

        public BulletPool(int capacity)
        {
            _capacity = capacity;
            _bulletsCount = 0;
            _activeBullets = new HashSet<Bullet>();
            _disabledBullets = new HashSet<Bullet>();
            if (!_deadBulletPlace)
            {
                _deadBulletPlace = new GameObject(NameManager.POOL_BULLETS).transform;
            }
        }

        public Bullet AddBullet(Transform position, bool playerBullet, float damage, float speed)
        {
            Bullet bullet;
            if (!_disabledBullets.Any<Bullet>())
            {
                if (_bulletsCount == _capacity)
                {
                    return null;
                }
                bullet = Bullet.CreateBullet(this, position, playerBullet, damage, speed);
                _bulletsCount++;
            }
            else 
            {
                bullet = _disabledBullets.First<Bullet>();
                _disabledBullets.Remove(bullet);
                bullet.InitBullet(position, playerBullet, damage, speed);
                bullet.transform.SetParent(null);
                bullet.gameObject.SetActive(true);
            }

            _activeBullets.Add(bullet);
            return bullet;
        }

        public void ReturnToPool(Bullet bullet)
        {
            var transform = bullet.gameObject.transform;
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.gameObject.SetActive(false);
            transform.SetParent(_deadBulletPlace);
            _activeBullets.Remove(bullet);
            _disabledBullets.Add(bullet);
        }


    }
}
