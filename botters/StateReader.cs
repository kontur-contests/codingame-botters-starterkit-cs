using System;
using System.Linq;

namespace botters
{
    public class StateReader : BaseStateReader
    {
        public StateReader(string input) : base(input)
        {
        }

        public StateReader() : base(Console.ReadLine)
        {
        }

        public InitData ReadInitData()
        {
            int team = ReadInt();
            var staticObjects = ReadInt().Times(i => ReadStaticObject()).ToList();
            var items = ReadInt().Times(i => ReadItem()).ToList();
            Console.Error.WriteLine();
            return new InitData(team, staticObjects, items);
        }

        private Item ReadItem()
        {
            var parts = readLine().Split(' ');
            string itemName = parts[0]; // contains keywords such as BRONZE, SILVER and BLADE, BOOTS connected by "_" to help you sort easier
            int itemCost = int.Parse(parts[1]); // BRONZE items have lowest cost, the most expensive items are LEGENDARY
            int damage = int.Parse(parts[2]); // keyword BLADE is present if the most important item stat is damage
            int health = int.Parse(parts[3]);
            int maxHealth = int.Parse(parts[4]);
            int mana = int.Parse(parts[5]);
            int maxMana = int.Parse(parts[6]);
            int moveSpeed = int.Parse(parts[7]); // keyword BOOTS is present if the most important item stat is moveSpeed
            int manaRegeneration = int.Parse(parts[8]);
            bool isPotion = int.Parse(parts[9]) == 1; // 0 if it's not instantly consumed
            return new Item(itemName, itemCost, damage, health, maxHealth, mana, maxMana, moveSpeed, manaRegeneration, isPotion);
        }

        private Entity ReadStaticObject()
        {
            var parts = readLine().Split();
            var pos = new Vec(int.Parse(parts[1]), int.Parse(parts[2]));
            var radius = int.Parse(parts[3]);
            string entityType = parts[0];
            if (entityType == "Bush")
                return new Bush(pos, radius);
            else if (entityType == "Spawn")
                return new Spawn(pos, radius);
            else
                throw new Exception(entityType);
        }

        /// <summary>
        /// Для тестов
        /// </summary>
        public static State Read(string init, string state)
        {
            var initData = new StateReader(init).ReadInitData();
            return new StateReader(state).ReadState(initData);
        }

        public State ReadState(InitData initData)
        {
            int gold = ReadInt();
            int enemyGold = ReadInt();
            int roundType = ReadInt(); // a positive value will show the number of heroes that await a command
            var units = ReadInt().Times(i => ReadUnit()).ToList();
            Console.Error.WriteLine();
            return new State(gold, enemyGold, roundType, units, initData);
        }

        private Unit ReadUnit()
        {
            var parts = readLine().Split(' ');
            int unitId = int.Parse(parts[0]);
            int team = int.Parse(parts[1]);
            UnitType unitType = ParseUnitType(parts[2]);
            int x = int.Parse(parts[3]);
            int y = int.Parse(parts[4]);
            int attackRange = int.Parse(parts[5]);
            int health = int.Parse(parts[6]);
            int maxHealth = int.Parse(parts[7]);
            int shield = int.Parse(parts[8]); // useful in bronze
            int attackDamage = int.Parse(parts[9]);
            int movementSpeed = int.Parse(parts[10]);
            int stunDuration = int.Parse(parts[11]); // useful in bronze
            int goldValue = int.Parse(parts[12]);
            int countDown1 = int.Parse(parts[13]); // all countDown and mana variables are useful starting in bronze
            int countDown2 = int.Parse(parts[14]);
            int countDown3 = int.Parse(parts[15]);
            int mana = int.Parse(parts[16]);
            int maxMana = int.Parse(parts[17]);
            int manaRegeneration = int.Parse(parts[18]);
            var heroType = ParseHeroType(parts[19]); // DEADPOOL, VALKYRIE, DOCTOR_STRANGE, HULK, IRONMAN
            int isVisible = int.Parse(parts[20]); // 0 if it isn't
            int itemsOwned = int.Parse(parts[21]); // useful from wood1
            return new Unit(unitId, team, unitType, new Vec(x, y), attackRange, health, maxHealth, shield, attackDamage, 
                movementSpeed, stunDuration, goldValue, countDown1, countDown2, countDown3, mana, maxMana, manaRegeneration, 
                heroType, isVisible, itemsOwned);
        }

        private UnitType ParseUnitType(string type)
        {
            switch (type)
            {
                case "UNIT": return UnitType.Unit;
                case "HERO": return UnitType.Hero;
                case "TOWER": return UnitType.Tower;
                case "GROOT": return UnitType.Groot;
                default: throw new Exception(type);
            }
        }
        private HeroType ParseHeroType(string type)
        {
            switch (type)
            {
                case "DEEADPOOL": return HeroType.Deadpool;
                case "DOCTOR_STRANGE": return HeroType.DoctorStrange;
                case "HULK": return HeroType.Hulk;
                case "IRONMAN": return HeroType.IronMan;
                case "VALKYRIE": return HeroType.Valkyrie;
                case "-": return HeroType.NA;
                default: throw new Exception(type);
            }
        }
    }
}