using Assets.Scripts.Data;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Managers;
using Assets.Scripts.Player;
using Assets.Scripts.Ship;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Enemies
{
    public abstract class Enemy: MonoBehaviour, IPoolable
    {
        public static IEnemyFactory Factory;
        public Health Health { get; private set; }
        private static GameData _gameData;
        protected IMove _moveImplementation;
        protected IRotation _rotationImplementation;
        private Transform _enemyPool;

        public static void setGameData(GameData data)
        {
            _gameData = data;
        }

        public Transform EnemyPool
        {
            get
            {
                if (_enemyPool == null)
                {
                    var find = GameObject.Find(NameManager.POOL_ENEMIES);
                    _enemyPool = find == null ? null : find.transform;
                }

                return _enemyPool;
            }
        }

        public static Asteroid CreateAsteroidEnemy(float maxHp)
        {
            var enemy = Instantiate(Resources.Load<Asteroid>("Enemy/Asteroid"));
            enemy._moveImplementation = new MoveTransform(enemy.transform, 5);
            enemy._rotationImplementation = new Rotation(enemy.transform);
            (float limitMin, float limitMax) = _gameData.Asteroid.SpeedLimits;
            (float angularMin, float angularMax) = _gameData.Asteroid.AngularSpeedLimits;

            enemy._speedHorizontal = UnityEngine.Random.Range(limitMin, limitMax);
            enemy._speedVertical = UnityEngine.Random.Range(limitMin, limitMax);
            if (UnityEngine.Random.Range(1, 3) == 1)
            {
                enemy._speedHorizontal *= -1;
            }
            if (UnityEngine.Random.Range(1, 3) == 1)
            {
                enemy._speedVertical *= -1;
            }

            enemy._angularSpeed = UnityEngine.Random.Range(angularMin, angularMax);
            if (UnityEngine.Random.Range(1, 3) == 1)
            {
                enemy._angularSpeed *= -1;
            }
            var collider = enemy.gameObject.GetComponent<SphereCollider>();
            collider.radius = _gameData.Asteroid.ColliderRadius;

            var damager = enemy.gameObject.GetComponent<DamageDealer>();
            damager.InitDamageDealer(5, true, false, true);

            var health = enemy.gameObject.GetComponent<Health>();
            health.InitHealth(maxHp, maxHp);

            return enemy;
        }

        public void setMove(IMove move)
        {
            _moveImplementation = move;
        }

        public void setRotate(IRotation rotate)
        {
            _rotationImplementation = rotate;
        }

        public void DependencyInjectHealth(Health hp)
        {
            Health = hp;
        }

        public void OnTriggerEnter(Collider other)
        {
            Debug.Log(other);
        }

        public void ActivateEnemy(Vector3 position, Quaternion rotation)
        {
            transform.localPosition = position;
            transform.localRotation = rotation;
            gameObject.SetActive(true);
            transform.SetParent(null);
        }

        public void ReturnToPool()
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            gameObject.SetActive(false);
            transform.SetParent(EnemyPool);

            if (!EnemyPool)
            {
                Destroy(gameObject);
            }
        }
    }
}
