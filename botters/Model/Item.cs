namespace botters
{
    public class Item
    {
        public readonly string ItemName;
        public readonly int ItemCost;
        public readonly int Damage;
        public readonly int Health;
        public readonly int MaxHealth;
        public readonly int Mana;
        public readonly int MaxMana;
        public readonly int MoveSpeed;
        public readonly int ManaRegeneration;
        public readonly bool IsPotion;

        public Item(string itemName, int itemCost, int damage, int health, int maxHealth, int mana, int maxMana, int moveSpeed, int manaRegeneration, bool isPotion)
        {
            ItemName = itemName;
            ItemCost = itemCost;
            Damage = damage;
            Health = health;
            MaxHealth = maxHealth;
            Mana = mana;
            MaxMana = maxMana;
            MoveSpeed = moveSpeed;
            ManaRegeneration = manaRegeneration;
            IsPotion = isPotion;
        }
    }
}