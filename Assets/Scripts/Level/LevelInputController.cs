using Helpers;
using UnityEngine;

namespace Level
{
    public class LevelInputController 
    {
        private readonly ILevelController _levelController;
        private readonly IInputController _inputController;

        public LevelInputController(ILevelController levelController, 
                                    IInputController inputController)
        {
            _levelController = levelController;
            _inputController = inputController;

            _inputController.OnAxisDown += AxisDown;
            _inputController.OnAxisUp += AxisDown;
        }


        private void AxisDown(Vector2 direction)
        {
            var character = _levelController.GetCurrentCharacter();
            
            if (character != null)
            {
                // character.Move(h);
            }
        }

        private void AxisUp(Vector2 direction)
        {

        }
    }
}