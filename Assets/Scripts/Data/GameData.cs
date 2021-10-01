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
        [SerializeField] private string _asteroidDataPath;
        [SerializeField] private string _cometDataPath;

        private PlayerData _player;
        private AsteroidData _asteroid;
        private CometData _comet;

        [SerializeField] private Vector2 _leftTopAngle;
        [SerializeField] private Vector2 _rightBottomAngle;
        [SerializeField] private float _waveDuration;
        [SerializeField] private float _spawnDelay;

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

        public AsteroidData Asteroid
        {
            get
            {
                if (_asteroid == null)
                {
                    _asteroid = Load<AsteroidData>("Data/" + _asteroidDataPath);
                }

                return _asteroid;
            }
        }

        public CometData Comet
        {
            get
            {
                if (_comet == null)
                {
                    _comet = Load<CometData>("Data/" + _cometDataPath);
                }

                return _comet;
            }
        }

        private T Load<T>(string path) where T: UnityEngine.Object
        {
            return Resources.Load<T>(Path.ChangeExtension(path, null));
        }

    }
}
