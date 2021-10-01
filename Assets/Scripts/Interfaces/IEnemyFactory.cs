using Assets.Scripts.Enemies;
using Assets.Scripts.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Interfaces
{
    public interface IEnemyFactory
    {
        Enemy Create(float maxHp);
    }
}
