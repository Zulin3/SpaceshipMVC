using Assets.Scripts.Data;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Managers;
using Assets.Scripts.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets.Scripts.Enemies
{
    public sealed class EnemyPool
    {
        private readonly Dictionary<string, HashSet<Enemy>> _enemyPool;
        private readonly int _capacityPool;
        private Transform _rootPool;
        private GameData _gameData;

        public EnemyPool(int capacityPool, GameData data)
        {
            _gameData = data;
            _enemyPool = new Dictionary<string, HashSet<Enemy>>();
            _capacityPool = capacityPool;
            if (!_rootPool)
            {
                _rootPool = new GameObject(NameManager.POOL_ENEMIES).transform;

            }
        }

        public Enemy GetEnemy(string type)
        {
            Enemy result;
            switch (type)
            {
                case "Asteroid":
                    result = GetAsteroid(GetListEnemies(type));
                    break;
                case "Comet":
                    result = GetComet(GetListEnemies(type));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, "Нет такого противника");
            }

            return result;
        }

        private HashSet<Enemy> GetListEnemies(string type)
        {
            return _enemyPool.ContainsKey(type) ? _enemyPool[type] : _enemyPool[type] = new HashSet<Enemy>();
        }

        private Enemy GetAsteroid(HashSet<Enemy> enemies)
        {
            var enemy = enemies.FirstOrDefault(a => !a.gameObject.activeSelf);
            if (enemy == null)
            {
                for (var i=0; i<_capacityPool; i++)
                {
                    var asteroid = Enemy.CreateAsteroidEnemy(100.0f);
                    ReturnToPool(asteroid.transform);
                    enemies.Add(asteroid);
                }

                return GetAsteroid(enemies);
            }
            else
            {
                return enemy;
            }
        }

        private Enemy GetComet(HashSet<Enemy> enemies)
        {
            var enemy = enemies.FirstOrDefault(a => !a.gameObject.activeSelf);
            if (enemy == null)
            {
                IEnemyFactory cometFactory = new CometFactory(_gameData.Comet);

                for (var i = 0; i < _capacityPool; i++)
                {
                    var comet = cometFactory.Create(50.0f);
                    ReturnToPool(comet.transform);
                    enemies.Add(comet);
                }

                return GetComet(enemies);
            }
            else
            {
                return enemy;
            }
        }

        private void ReturnToPool(Transform transform)
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.gameObject.SetActive(false);
            transform.SetParent(_rootPool);
        }

        public void RemovePool()
        {
            Object.Destroy(_rootPool.gameObject);
        }
    }
}
