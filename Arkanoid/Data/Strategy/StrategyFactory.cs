using System.Collections;

namespace Arkanoid.Data.Strategy
{
    public enum Strategies { Regular, Fast, Teleport }
    public class StrategyFactory
    {
        private static Dictionary<Strategies, BallMoveAlgorithm> keyValuePairs = new Dictionary<Strategies, BallMoveAlgorithm>();
        public static BallMoveAlgorithm GetStrategy(Strategies key)
        {
            if (keyValuePairs.ContainsKey(key)) return keyValuePairs[key];

            BallMoveAlgorithm ballMoveAlgorithm;
            switch (key)
            {
                case Strategies.Regular:
                    ballMoveAlgorithm = new RegularBallStrategy();
                    break;
                case Strategies.Fast:
                    ballMoveAlgorithm = new FastBallStrategy();
                    break;
                case Strategies.Teleport:
                    ballMoveAlgorithm = new TeleportSideStrategy();
                    break;
                default:
                    throw new ArgumentException($"Unknown strategy type: {key}");
            }
            keyValuePairs.Add(key,ballMoveAlgorithm);
            return keyValuePairs[key];
        }
    }
}
