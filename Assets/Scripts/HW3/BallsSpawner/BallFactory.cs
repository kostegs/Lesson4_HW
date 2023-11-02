using System;
using Zenject;

namespace Lesson4.HW3
{
    public class BallFactory
    {
        private BallFactoryConfig _config;
        private DiContainer _container;

        public BallFactory(BallFactoryConfig config, DiContainer container)
        {
            _config = config;
            _container = container;
        }

        public Ball GetBall(BallColors color)
        {
            switch (color)
            {
                case BallColors.Blue:
                    return _container.InstantiatePrefabForComponent<Ball>(_config.BlueBallPrefab);
                case BallColors.Red:
                    return _container.InstantiatePrefabForComponent<Ball>(_config.RedBallPrefab);
                default:
                    throw new ArgumentException(nameof(color));
            }
        }
    }
}
