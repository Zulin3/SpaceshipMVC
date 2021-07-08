using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Data
{
    [CreateAssetMenu(fileName = "GameData", menuName = "Data/GameData")]
    public sealed class GameData: ScriptableObject
    {
        [SerializeField] private string _playerDataPath;

        private PlayerData _player;

        public PlayerData Player
        {
            get
            {
                if (_player == null)
                {
                    _player = Load<PlayerData>("Data/" + _playerDataPath);
                }

                return _player;
            }
        }

        private T Load<T>(string path) where T: UnityEngine.Object
        {
            return Resources.Load<T>(Path.ChangeExtension(path, null));
        }

    }
}
