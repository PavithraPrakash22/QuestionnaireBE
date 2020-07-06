using Microsoft.EntityFrameworkCore;
using QuestionnaireMW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionnaireMW.Context
{
    public class QuestionnaireContext : DbContext
    {
        public QuestionnaireContext(DbContextOptions<QuestionnaireContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasIndex(u => u.UserEmail)
                .IsUnique();

        }

        public DbSet<User> Users { get; set; }
        public DbSet<AnswerResponse> AnswerResponses { get; set; }
    }
}
