using Assets.Scripts.Enemies;
using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public sealed class Health: MonoBehaviour
    {
        public float Max { get; private set; }
        public float Current { get; private set; }
        private bool _playerHealth;

        public void InitHealth(float max, float current, bool playerHealth = false)
        {
            Max = max;
            Current = current;
            _playerHealth = playerHealth;
        }

        public void ChangeCurrentHealth(float hp)
        {
            Current = hp;
        }

        public void OnTriggerEnter(Collider other)
        {
            var damager = other.GetComponent<DamageDealer>();
            if (!_playerHealth)
            {
                Debug.Log(gameObject.name + " collided with " + other.name);
            }
            if (damager != null && ((_playerHealth && damager.DamagesPlayer) || (!_playerHealth && damager.DamagesEnemy)))
            {
                Current -= damager.Damage;
                Debug.Log(other.name + " damaged "+ gameObject.name + "for " + damager.Damage + " damage leaving " + Current + " health left");
                
                if (Current <= 0)
                {
                    var poolable = gameObject.GetComponent<IPoolable>();
                    if (poolable != null)
                    {
                        poolable.ReturnToPool();
                    }
                    else
                    {
                        Destroy(gameObject);
                    }
                }

                if (damager.DisappearsAfter)
                {
                    var poolable = other.gameObject.GetComponent<IPoolable>();
                    if (poolable != null)
                    {
                        poolable.ReturnToPool();
                    }
                    else
                    {
                        Destroy(other.gameObject);
                    }
                }
                
            }    
        }
    }
}
