using Microsoft.EntityFrameworkCore;
using Patient_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Models.DbContexts
{
    public class PatientDbContext : DbContext
    {
        public PatientDbContext(DbContextOptions<PatientDbContext> options):base(options)
        {

        }

        public DbSet<Allergies> tblAllergies { get; set; } = default!;
        public DbSet<Disease_Information> tblDisease_Information { get; set; } = default!;
        public DbSet<NCD> tblNCD { get; set; } = default!;
        public DbSet<Patients_Information> tblPatients_Information { get; set; } = default!;
        public DbSet<NCD_Details> tblNCD_Details { get; set; } = default!;
        public DbSet<Allergies_Details> tblAllergies_Details { get; set; } = default!;



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data
            modelBuilder.Entity<Disease_Information>().HasData(
                new Disease_Information { DiseaseId = 1, DiseaseName = "Diabetes" },
                new Disease_Information { DiseaseId = 2, DiseaseName = "Hypertension" },
                new Disease_Information { DiseaseId = 3, DiseaseName = "Arthritis" },
                new Disease_Information { DiseaseId = 4, DiseaseName = "Heart Disease" },
                new Disease_Information { DiseaseId = 5, DiseaseName = "Respiratory Infections" }
            );

            modelBuilder.Entity<NCD>().HasData(
                new NCD { NCD_Id = 1, NCD_Name = "Asthma" },
                new NCD { NCD_Id = 2, NCD_Name = "Cancer" },
                new NCD { NCD_Id = 3, NCD_Name = "Disorders of ear" },
                new NCD { NCD_Id = 4, NCD_Name = "Disorder of eye" },
                new NCD { NCD_Id = 5, NCD_Name = "Mental illness" }
            );

            modelBuilder.Entity<Allergies>().HasData(
                new Allergies { AllergyId = 1, AllergyName = "Drugs - Penicillin" },
                new Allergies { AllergyId = 2, AllergyName = "Drugs - Others" },
                new Allergies { AllergyId = 3, AllergyName = "Animals" },
                new Allergies { AllergyId = 4, AllergyName = "Food" },
                new Allergies { AllergyId = 5, AllergyName = "Ointments" },
                new Allergies { AllergyId = 6, AllergyName = "Plant" },
                new Allergies { AllergyId = 7, AllergyName = "Sprays" },
                new Allergies { AllergyId = 8, AllergyName = "Others" },
                new Allergies { AllergyId = 9, AllergyName = "No Allergies" }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
