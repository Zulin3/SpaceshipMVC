using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Bullets
{
    class BulletsController : IExecute, IFixedExecute, IInitialization, ICleanup
    {
        public readonly BulletPool _pool;
        private HashSet<Bullet> _activeBullets;

        public BulletsController(int maxBullets)
        {
            _pool = new BulletPool(maxBullets);
            _activeBullets = _pool.ActiveBullets;
        }

        public void Cleanup()
        {
            _activeBullets.ToList<Bullet>().ForEach(bul => bul.Cleanup());
        }

        public void Execute(float deltaTime)
        {
            _activeBullets = _pool.ActiveBullets;
            _activeBullets.ToList<Bullet>().ForEach(bul => bul.Execute(deltaTime));
        }

        public void FixedExecute()
        {
            _activeBullets.ToList<Bullet>().ForEach(bul => bul.FixedExecute());
        }

        public void Initialize()
        {
            _activeBullets.ToList<Bullet>().ForEach(bul => bul.Initialize());
        }

    }
}
