using PT.Infraestructure.Persistence.Common;
using System.Data;

namespace PT.Infraestructure.Persistence.ProjectTracker.Features
{
    public class FeaturesRepository : BaseRepository, IFeaturesRepository
    {
        public FeaturesRepository(IDbTransaction dbTransaction) : base(dbTransaction)
        {
        }
    }
}
