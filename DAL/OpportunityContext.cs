using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OpportunityTracker.Models;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace OpportunityTracker.DAL
{
    public class OpportunityContext : IdentityDbContext{
        public OpportunityContext(DbContextOptions<OpportunityContext> options) : base(options){ }

        public DbSet<Opportunity> opportunities {get;set;}

    }
}