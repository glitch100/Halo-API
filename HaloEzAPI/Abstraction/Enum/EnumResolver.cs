namespace HaloEzAPI.Abstraction.Enum
{
    public static class EnumResolver
    {
        public static OwnerType GetOwnerType(int value)
        {
            switch (value)
            {
                case 1:
                    return OwnerType.UserGenerated;
                case 2:
                    return OwnerType.UserGenerated;
                case 3:
                    return OwnerType.Official;
                default :
                    return OwnerType.Unknown;
            }
        }
    }
}