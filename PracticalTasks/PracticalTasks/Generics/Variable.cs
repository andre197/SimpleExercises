namespace Generics
{
    public class Variable : INamed<int>
    {
        public string Name { get; set; }

        public int Value { get; set; }

        public static int operator *(Variable v1, Variable v2 = null)
                    => v1.Value;

        public static Variable operator +(Variable v1, Variable v2)
        {
            v1.Value += v2.Value;
            return v1;
        }

        public static bool operator ==(Variable v1, Variable v2)
        {
            if (v1.Name.Equals(v2.Name) && (v1.Value == v2.Value)) return true;

            return false;
        }

        public static bool operator !=(Variable v1, Variable v2)
        {
            if (v1.Name.Equals(v2.Name) && (v1.Value == v2.Value)) return false;

            return true;
        }
    }
}
