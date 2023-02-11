namespace Core.Application.Common.CodeContracts
{
    public static class Contract
    {
        public static void MustNotBeNull<T>([ValidatedNotNull]T? entity)
            where T : class
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Entity must not be null.");
            }
        }

        [AttributeUsage(AttributeTargets.All)]
        private sealed class ValidatedNotNullAttribute : Attribute
        {
        }
    }
}
