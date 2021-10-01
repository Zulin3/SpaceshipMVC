using Assets.Scripts.Bullets;
using Assets.Scripts.Data;
using Assets.Scripts.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

internal sealed class GameInitialization
    {
        public GameInitialization(Controllers controllers, GameData data)
        {
            var inputController = new InputController();
            controllers.Add(inputController);
            var playerFactory = new PlayerFactory(data.Player);
            var bulletsController = new BulletsController(data.Player.MaxBullets);
            controllers.Add(bulletsController);
            var playerController = new PlayerController(playerFactory, bulletsController._pool, inputController.GetKeyboardInput(), inputController.GetMouseInput(), data.Player);
            controllers.Add(playerController);
            

            Enemy.setGameData(data);
            EnemyPool enemyPool = new EnemyPool(5, data);
            var asteroid1 = enemyPool.GetEnemy("Asteroid");
            asteroid1.ActivateEnemy(new Vector3(2, 2, 0), Quaternion.identity);

            var asteroid2 = enemyPool.GetEnemy("Asteroid");
            asteroid2.ActivateEnemy(new Vector3(3, -3, 0), Quaternion.identity);

            var asteroid3 = enemyPool.GetEnemy("Asteroid");
            asteroid3.ActivateEnemy(new Vector3(-1, -3, 0), Quaternion.identity);

            var comet1 = enemyPool.GetEnemy("Comet");
            comet1.ActivateEnemy(new Vector3(1, 2, 0), Quaternion.identity);

            var comet2 = enemyPool.GetEnemy("Comet");
            comet2.ActivateEnemy(new Vector3(-1, -2, 0), Quaternion.identity);

            var comet3 = enemyPool.GetEnemy("Comet");
            comet3.ActivateEnemy(new Vector3(-3, -2, 0), Quaternion.identity);
        }
    }
