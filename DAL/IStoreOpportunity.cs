using System;
using System.Collections.Generic;

using OpportunityTracker.Models;

namespace OpportunityTracker.DAL{
    public interface IStoreOpportunity
    {
        List<Opportunity> getAllOpportunities(Guid userId);

        Opportunity getById(Guid id);

        void createOpportunity(Opportunity opportunityToCreate);

        void updateOpportunity(Opportunity opportunityToUpdate);

        void deleteOpportunity(Guid id);

        
    }
}