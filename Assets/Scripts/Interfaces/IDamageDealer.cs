using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Interfaces
{
    public interface IDamageDealer
    {
        float Damage { get; }
        bool DamagesPlayer { get; }
        bool DamagesEnemy { get; }

        bool DisappearsAfter { get; }
    }
}
