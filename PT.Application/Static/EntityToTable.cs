using PT.Domain.ProjectTracker;
using PT.Domain.ProjectTrackerTools;

namespace PT.Application.Static
{
    public static class EntityToTable
    {
        private static readonly Dictionary<Type, string> EntityTableMapping = new()
        {
            { typeof(Feature), "Features" },
            { typeof(Log), "Logger" },
            //{ typeof(RoleFeature), "Role_Features" },
            { typeof(Role), "Roles" },
            //{ typeof(UserRole), "User_Roles" },
            { typeof(User), "Users" },
        };

        public static string Convert<T>()
        {
            Type entityType = typeof(T);
            if (EntityTableMapping.TryGetValue(entityType, out string? tableName))
            {
                return tableName;
            }
            else
            {
                throw new Exception($"No se encontró una tabla asociada para el tipo {entityType.FullName}");
            }
        }
    }
}
