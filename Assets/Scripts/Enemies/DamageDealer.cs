using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Enemies
{
    class DamageDealer : MonoBehaviour, IDamageDealer
    {
        public void InitDamageDealer(float damage, bool damagesPlayer, bool damagesEnemy, bool disappear)
        {
            Damage = damage;
            DamagesPlayer = damagesPlayer;
            DamagesEnemy = damagesEnemy;
            DisappearsAfter = disappear;
        }

        public float Damage { get; private set; }

        public bool DamagesPlayer { get; private set; }

        public bool DamagesEnemy { get; private set; }

        public bool DisappearsAfter { get; private set; }
    }
}
