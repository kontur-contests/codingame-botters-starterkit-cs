namespace botters
{
    public class Entity
    {
        public Entity(Vec pos, int radius)
        {
            Pos = pos;
            Radius = radius;
        }

        public readonly Vec Pos;
        public readonly int Radius;
    }
}