using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;

namespace WebService.Contracts.MappingProfiles;

/// <summary>
/// Хелпер для создания дерева выражений для получений описания типа перечисления.
/// </summary>
internal static class EnumHelper
{
    /// <summary>
    /// Создания дерева выражений для получений описания типа перечисления.
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности.</typeparam>
    /// <typeparam name="TEnum">Тип перечисления.</typeparam>
    /// <param name="propertyExpression"></param>
    /// <returns>Дерева выражений для получений описания типа перечисления.</returns>
    public static Expression<Func<TEntity, string>> CreateEnumDescriptionExpression<TEntity, TEnum>(Expression<Func<TEntity, TEnum>> propertyExpression)
        where TEntity : class
        where TEnum : struct
    {
        IEnumerable<Enum> enumValues = Enum.GetValues(typeof(TEnum)).Cast<Enum>();
        Expression resultExpression = Expression.Constant(string.Empty);
        foreach (var enumValue in enumValues)
        {
            resultExpression = Expression.Condition(
                Expression.Equal(propertyExpression.Body, Expression.Constant(enumValue)),
                Expression.Constant(GetDescription(enumValue)),
                resultExpression);
        }

        return Expression.Lambda<Func<TEntity, string>>(resultExpression, propertyExpression.Parameters);
    }

    private static string GetDescription(Enum value)
    {
        FieldInfo? field = value.GetType().GetField(value.ToString())!;
        if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
        {
            return attribute.Description;
        }

        throw new ArgumentException("Decription not found.", nameof(value));
    }
}
