using System;

namespace OpportunityTracker.Models
{
    public class Opportunity
    {
         public Guid Id{get;set;}
        public Guid UserId {get;set;}

        public string CompanyName { get;set;}

        public string Role { get;set;}

        public string Link { get;set;}

        public string Note { get;set;}
         public string Status{get;set;}
         public string JobDescription{get;set;}

         public DateTime Date{get;set;}
    }
}
