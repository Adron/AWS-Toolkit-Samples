using System.Data.Objects;
using System.Linq;

namespace AWS_MVC_Web_Applicaiton.Data
{
    public static class RepositoryHelper
    {
        public static IQueryable<T> Include<T>(this IQueryable<T> source, string path)
        {
            if (source is ObjectQuery<T>)
                return ((ObjectQuery<T>)source).Include(path);

            return source;
        }
    }
}