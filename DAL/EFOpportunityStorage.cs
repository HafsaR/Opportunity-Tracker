using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

using OpportunityTracker.Models;

namespace OpportunityTracker.DAL{
    public class EFOpportunityStorage : IStoreOpportunity{
        readonly OpportunityContext _context;

        public EFOpportunityStorage(OpportunityContext myContext)
        {
            _context = myContext;
            
        }

        public List<Opportunity> getAllOpportunities(Guid userId){
            var result = _context.opportunities.OrderByDescending(x=>x.Date)
                        .Where(x => x.UserId == userId).ToList();

            return result;

        }

        public Opportunity getById(Guid id){
            var result = _context.opportunities
                        .FirstOrDefault(x=>x.Id==id);
            return result;
        }

        public void createOpportunity(Opportunity newOpportunity){
            _context.Add(newOpportunity);
            _context.SaveChanges();
        }

        public void updateOpportunity(Opportunity updateOpportunity){
            _context.Update(updateOpportunity);
            _context.SaveChanges();
        }

        public void deleteOpportunity(Guid id){
            var opportunity = getById(id);
            _context.Remove(opportunity);
            _context.SaveChanges();
        }

    }
}