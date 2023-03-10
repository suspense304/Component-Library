using System.Linq.Expressions;

namespace Component_Library
{
    public interface IFilter<TableItem>
    {
        Expression<Func<TableItem, bool>> GetFilter();
    }
}
