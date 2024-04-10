using Application.Interface;
using Application.ViewModel;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Contexr
{
    public class DynamicContext : DbContext, IDynamicContext
    {

        DbSet<AssessmentTable> IDynamicContext.AssessmentTables => Set<AssessmentTable>();

        DbSet<AssessmentQuestion> IDynamicContext.AssessmentQuestions => Set<AssessmentQuestion>();

        public DbSet<Patient> PatientsTable => Set<Patient>();

        public DbSet<PatientToAssessment> PatientToAssessmentsTable => Set<PatientToAssessment>();

        public DbSet<PatientToAssessmentDetails> PatientToAssessmentDetailsTable => Set<PatientToAssessmentDetails>();

        public DbSet<QuestionResponse> QuestionResponses => Set<QuestionResponse>();

        public DynamicContext(DbContextOptions options) : base(options) { }

        async Task IDynamicContext.SaveChangesAsync()
        {
            await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssessmentTable>(builder =>
            {
                builder.HasKey(a => a.Id);
                builder.Property(a => a.Name).IsRequired();
                builder.HasMany(a => a.AssessmentQuestions)
                        .WithOne(aq => aq.AssessmentTable)
                        .HasForeignKey(aq => aq.AssessmentId);
            });
            modelBuilder.Entity<AssessmentQuestion>(builder =>
            {
                builder.HasKey(aq => aq.Id);
                builder.Property(aq => aq.ResponseType)
                        .HasMaxLength(50)
                        .IsRequired();
                builder.HasOne(aq => aq.AssessmentTable)
                        .WithMany(a => a.AssessmentQuestions)
                        .HasForeignKey(aq => aq.AssessmentId);

            });



            //ptad relation
       
            modelBuilder.Entity<PatientToAssessment>()
               .HasOne(a => a.Patient)
               .WithMany(a => a.patientToAssessments)
               .HasForeignKey(a => a.PatientId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PatientToAssessment>()
             .HasOne(a => a.AssessmentTable)
              .WithMany()
               .HasForeignKey(a => a.AssessmentId)
            .OnDelete(DeleteBehavior.Restrict); ;

            modelBuilder.Entity<PatientToAssessmentDetails>()
                .HasOne(a => a.PatientToAssessment)
                .WithMany(a => a.PatientToAssessmentDetails)
                .HasForeignKey(a => a.PatientAssessmentId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<PatientToAssessmentDetails>()
                 .HasOne(a => a.AssessmentQuestion)
                 .WithMany()
                 .HasForeignKey(a => a.QuestionId)
                 .OnDelete(DeleteBehavior.ClientSetNull);

        }

     
    }
}
