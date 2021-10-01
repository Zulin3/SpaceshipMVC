using Assets.Scripts.Data;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Player;
using Assets.Scripts.Ship;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets.Scripts.Enemies
{
    internal sealed class CometFactory : IEnemyFactory
    {
        CometData _cometData;

        public CometFactory(CometData data)
        {
            _cometData = data;
        }

        public Enemy Create(float maxHp)
        {
            var enemy = Object.Instantiate(Resources.Load<Comet>("Enemy/Comet"));
            var enemyObj = enemy.gameObject;
            enemy._speed = UnityEngine.Random.Range(_cometData.SpeedLimits.x, _cometData.SpeedLimits.y);
            enemy.transform.Rotate(new Vector3(0.0f, 0.0f, UnityEngine.Random.Range(0.0f, 360f)));
            enemy.setMove(new MoveTransform(enemy.transform, enemy._speed));
            enemy.setRotate(new Rotation(enemy.transform));

            var collider = enemyObj.GetComponent<SphereCollider>();
            collider.radius = _cometData.ColliderRadius;

            var damager = enemyObj.GetComponent<DamageDealer>();
            damager.InitDamageDealer(10, true, false, true);

            var health = enemyObj.GetComponent<Health>();
            health.InitHealth(maxHp, maxHp);

            return enemy;
        }
    }
}
