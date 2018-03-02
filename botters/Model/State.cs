using System.Collections.Generic;
using System.Linq;

namespace botters
{
    public class State
    {
        public readonly InitData InitData;
        public readonly int Gold;
        public readonly int EnemyGold;
        public readonly int RoundType;
        public readonly List<Unit> Units;

        public State(int gold, int enemyGold, int roundType, List<Unit> units, InitData initData)
        {
            Gold = gold;
            EnemyGold = enemyGold;
            RoundType = roundType;
            Units = units;
            InitData = initData;
        }

        public State MakeCopy()
        {
            return new State(Gold, EnemyGold, RoundType, Units.Select(u => u.MakeCopy()).ToList(), InitData);
        }
    }
}