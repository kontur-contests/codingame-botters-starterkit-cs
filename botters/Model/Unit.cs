namespace botters
{
    public class Unit
    {
        public readonly int UnitId;
        public readonly int Team;
        public readonly UnitType UnitType;
        public readonly Vec Pos;
        public readonly int AttackRange;
        public readonly int Health;
        public readonly int MaxHealth;
        public readonly int Shield;
        public readonly int AttackDamage;
        public readonly int MovementSpeed;
        public readonly int StunDuration;
        public readonly int GoldValue;
        public readonly int CountDown1;
        public readonly int CountDown2;
        public readonly int CountDown3;
        public readonly int Mana;
        public readonly int MaxMana;
        public readonly int ManaRegeneration;
        public readonly HeroType HeroType;
        public readonly int IsVisible;
        public readonly int ItemsOwned;

        public Unit(int unitId, int team, UnitType unitType, Vec pos, int attackRange, int health, int maxHealth, int shield, int attackDamage, int movementSpeed, int stunDuration, int goldValue, int countDown1, int countDown2, int countDown3, int mana, int maxMana, int manaRegeneration, HeroType heroType, int isVisible, int itemsOwned)
        {
            UnitId = unitId;
            Team = team;
            UnitType = unitType;
            Pos = pos;
            AttackRange = attackRange;
            Health = health;
            MaxHealth = maxHealth;
            Shield = shield;
            AttackDamage = attackDamage;
            MovementSpeed = movementSpeed;
            StunDuration = stunDuration;
            GoldValue = goldValue;
            CountDown1 = countDown1;
            CountDown2 = countDown2;
            CountDown3 = countDown3;
            Mana = mana;
            MaxMana = maxMana;
            ManaRegeneration = manaRegeneration;
            HeroType = heroType;
            IsVisible = isVisible;
            ItemsOwned = itemsOwned;
        }

        public Unit MakeCopy()
        {
            return new Unit(UnitId, Team, UnitType, Pos, AttackRange, Health, MaxHealth, Shield, AttackDamage,
                MovementSpeed, StunDuration, GoldValue, CountDown1, CountDown2, CountDown3, Mana, MaxMana, ManaRegeneration,
                HeroType, IsVisible, ItemsOwned);
        }
    }
}