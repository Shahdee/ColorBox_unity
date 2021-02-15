using Helpers;
using UnityEngine;

namespace Characters
{
    public class CharacterController : ICharacter, IUpdatable
    {
        public ECharacterType CharacterType => _characterType;

        private const float MovingSpeed = 5; // unit/sec
        private const float SpeedDecrease = 0.1f; // %
        
        private CharacterView _view;
        private ECharacterType _characterType;

        public CharacterController(ECharacterType characterType,
                                    CharacterView view)
        {
            _view = view;
            _characterType = characterType;
        }

        public void CustomUpdate(float deltaTime)
        {
            var viewportPoint = Camera.main.WorldToViewportPoint(_view.transform.position);
            
            if (viewportPoint.y < 0)
            {
                var nextViewportPoint = viewportPoint;
                nextViewportPoint.y = 1;
                var worldPoint =  Camera.main.ViewportToWorldPoint(nextViewportPoint);
                Teleport(worldPoint);
            }
        }

        public void Jump(float direction)
        {
            
        }

        public void Move(float direction)
        {
            var currentVelocity = _view.Velocity;
            
            if (direction > 0 || direction < 0)
                currentVelocity.x = Mathf.Sign(direction) * MovingSpeed;
            else
            {
                Debug.Log(currentVelocity);
                
                if (currentVelocity.x > 0)
                    currentVelocity.x = Mathf.Max(0, currentVelocity.x - MovingSpeed * SpeedDecrease);
            }
            
            _view.SetVelocity(currentVelocity);
        }

        public void Teleport(Vector3 position)
        {
            _view.SetPosition(position);
            _view.SetVelocity(Vector2.zero);
        }
    }
}