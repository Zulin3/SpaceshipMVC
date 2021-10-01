using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Bullets
{
    interface IBullet
    {
        void InitBullet(Transform position, bool playerBullet, float damage, float speed);
    }
}
