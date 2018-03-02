using System.Linq;

namespace botters
{
    public static class Const {

    }
    public class Ai
    {
        public string GetNextMove(State state, Countdown countdown)
        {
            if (state.RoundType < 0) return "IRONMAN";
            return "ATTACK_NEAREST UNIT";
        }
    }
}