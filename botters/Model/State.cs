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

        public IEnumerable<Unit> Get(UnitType unitType, int team) => Units.Where(u => u.Team == team && u.UnitType == unitType);
        public IEnumerable<Unit> GetMy(UnitType unitType) => Get(unitType, InitData.Team);
        public IEnumerable<Unit> GetHis(UnitType unitType) => Get(unitType, 1-InitData.Team);

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