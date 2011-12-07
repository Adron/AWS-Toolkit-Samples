using System.Data.Objects;
using AWS_MVC_Web_Applicaiton.Data;

namespace AWS_MVC_Web_Applicaiton.Models
{
    public partial class PilesOfDataEntities : IObjectContext
    {
        IObjectSet<TEntity> IObjectContext.CreateObjectSet<TEntity>()
        {
            return CreateObjectSet<TEntity>();
        }
    }
}