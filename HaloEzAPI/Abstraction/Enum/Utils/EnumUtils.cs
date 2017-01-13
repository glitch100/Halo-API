namespace HaloEzAPI.Abstraction.Enum.Utils
{
    public class EnumUtils
    {
        public static T ParseEnum<T>(string value)
        {
            return (T)System.Enum.Parse(typeof(T), value, true);
        }
    }
}
