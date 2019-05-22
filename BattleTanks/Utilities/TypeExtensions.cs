using System;

namespace BattleTanks.Utilities
{
    public static class TypeExtensions
    {
        public static bool Implements(this Type type, Type assignableType)
        {
            return assignableType.IsAssignableFrom(type);
        }

        public static bool Implements<I>(this Type type)
        {
            return Implements(type, typeof(I));
        }
    }
}
