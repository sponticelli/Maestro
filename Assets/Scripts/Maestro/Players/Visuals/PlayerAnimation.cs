using LiteNinja.MathUtils;
using UnityEngine;

namespace Maestro.Players
{
    public class PlayerAnimation : MonoBehaviour, IMove
    {
        [Header("Sprite Sheets")]
        [SerializeField] private Sprite[] _standingSprites;
        [SerializeField] private Sprite[] _runningSprites;
        
        [Header("Components")]
        [SerializeField] private SpriteRenderer _spriteRenderer;

        private float frameCounter;
        private int frameInc;

        private void Awake()
        {
            if (!_spriteRenderer) _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void Move(Vector2 direction, float speed)
        {
            switch (speed)
            {
                case 0:
                    StandingAnimation(direction, speed);
                    return;
                case > 0:
                    RunningAnimation(direction, speed);
                    break;
            }
        }

        private void RunningAnimation(Vector2 direction, float speed)
        {
            var directionIndex = CalcDirectionIndex(direction);
            frameCounter += speed * Time.deltaTime;
            if (frameCounter > 0.0008)
            {
                ++frameInc;
                frameCounter = 0.0f;
                if (frameInc > 9)
                    frameInc = 0;
            }
            var frameIndex = directionIndex * 10 + frameInc;
            _spriteRenderer.sprite = _runningSprites[frameIndex];
        }
        
        private void StandingAnimation(Vector2 direction, float speed)
        {
            var directionIndex = CalcDirectionIndex(direction);
            _spriteRenderer.sprite = _standingSprites[directionIndex];
        }

        private static int CalcDirectionIndex(Vector2 direction)
        {
            var index = 0;
            var angle = MathHelper.Angle(Vector2.zero, direction);
            switch (angle)
            {
                case < 22.5:
                case >= 337.5:
                    index = 6;
                    break;
                case >= 22.5 and < 67.5:
                    index = 7;
                    break;
                case >= 67.5 and < 112.5:
                    index = 0;
                    break;
                case >= 112.5 and < 157.5:
                    index = 1;
                    break;
                case >= 157.5 and < 202.5:
                    index = 2;
                    break;
                case >= 202.5 and < 247.5:
                    index = 3;
                    break;
                case >= 247.5 and < 292.5:
                    index = 4;
                    break;
                case >= 292.5 and < 337.5:
                    index = 5;
                    break;
            }

            return index;
        }

        
    }
}