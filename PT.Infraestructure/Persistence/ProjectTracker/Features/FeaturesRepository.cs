using PT.Infraestructure.Persistence.Abstractions;
using System.Data;

namespace PT.Infraestructure.Persistence.ProjectTracker.Features
{
    public class FeaturesRepository : RepositoryAbstract, IFeaturesRepository
    {
        public FeaturesRepository(IDbTransaction dbTransaction) : base(dbTransaction)
        {
        }
    }
}
