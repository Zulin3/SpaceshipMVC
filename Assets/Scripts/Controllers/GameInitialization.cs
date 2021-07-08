using Assets.Scripts.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal sealed class GameInitialization
    {
        public GameInitialization(Controllers controllers, GameData data)
        {
            var inputController = new InputController();
            controllers.Add(inputController);
            var playerFactory = new PlayerFactory(data.Player);
            var playerController = new PlayerController(playerFactory, data.Player.Position, inputController.GetKeyboardInput(), inputController.GetMouseInput(), data.Player);
            controllers.Add(inputController);
            controllers.Add(playerController);
        }
    }
