using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tourist_Project_MVC.Models;

namespace Tourist_Project_MVC.Data
{
    public class TouristContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Tourist> Tourists { get; set; }
        public DbSet<TripPlan> TripPlans { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<TripDestination> TripDestinations { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }
        public DbSet<Reward> Rewards { get; set; }
        public DbSet<Redemption> Redemptions { get; set; }
        public DbSet<Mission> Missions { get; set; }
        public DbSet<UserMission> UserMissions { get; set; }

        public TouristContext(DbContextOptions<TouristContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Fix decimal precision warning
            modelBuilder.Entity<Destination>()
                .Property(d => d.TicketPrice)
                .HasColumnType("decimal(10, 2)");

            // 1. Seed Destinations
            modelBuilder.Entity<Destination>().HasData(
                new { Id = 1, Name = "Eiffel Tower", City = "Paris", Lat = 48.8584f, Long = 2.2945f, description = "Iconic iron tower." },
                new { Id = 2, Name = "Colosseum", City = "Rome", Lat = 41.8902f, Long = 12.4922f, description = "Ancient Roman amphitheater." }
            );

            // 2. Seed Sponsors
            modelBuilder.Entity<Sponsor>().HasData(
                new { Id = 1, Name = "Global Travel Co.", Type = "Agency", Address = "123 Main St, London", ContactNumber = 5550192 },
                new { Id = 2, Name = "EcoStay Hotels", Type = "Hospitality", Address = "456 Green Rd, Berlin", ContactNumber = 5550143 }
            );

            // 3. Seed Tourists
            modelBuilder.Entity<Tourist>().HasData(
                new { Id = 1, Name = "John Doe", Nationality = "American", IdNumber = "US123456", Passport = "P987654", Email = "john.doe@example.com", Password = "HashedPassword123", point_Balance = 150, RegisterDate = DateTime.Parse("2026-01-15") },
                new { Id = 2, Name = "Jane Smith", Nationality = "British", IdNumber = "UK789101", Passport = "P112233", Email = "jane.smith@example.com", Password = "HashedPassword456", point_Balance = 50, RegisterDate = DateTime.Parse("2026-02-20") }
            );

            // 4. Seed Missions
            modelBuilder.Entity<Mission>().HasData(
                new { Id = 1, MissionType = "Photography", Title = "Parisian Explorer", Description = "Take a photo at the top of the Eiffel Tower", PointsReward = 100, DestinationId = 1 },
                new { Id = 2, MissionType = "Exploration", Title = "Gladiator Walk", Description = "Visit the underground chambers of the Colosseum", PointsReward = 120, DestinationId = 2 }
            );

            // 5. Seed Rewards
            modelBuilder.Entity<Reward>().HasData(
                new { Id = 1, RewardType = "Discount", Title = "10% Hotel Discount", Description = "Get 10% off your next stay at EcoStay", PointsRequired = 100, QuantityAvailable = 50, ExpirationDate = DateTime.Parse("2027-12-31"), SponsorId = 2 },
                new { Id = 2, RewardType = "Experience", Title = "Free City Tour", Description = "Complimentary walking tour by Global Travel Co.", PointsRequired = 80, QuantityAvailable = 20, ExpirationDate = DateTime.Parse("2026-11-30"), SponsorId = 1 }
            );

            // 6. Seed Trip Plans
            modelBuilder.Entity<TripPlan>().HasData(
                new { Id = 1, Title = "Summer Europe Trip", StartDate = DateTime.Parse("2026-07-01"), EndDate = DateTime.Parse("2026-07-15"), TouristId = 1 }
            );

            // 7. Seed User Missions
            modelBuilder.Entity<UserMission>().HasData(
                new { Id = 1, Status = "Completed", PointsEarned = 100, Completed_At = DateTime.Parse("2026-06-10"), TouristId = 1, MissionId = 1 },
                new { Id = 2, Status = "In Progress", PointsEarned = 0, Completed_At = DateTime.MinValue, TouristId = 2, MissionId = 2 }
            );

            // 8. Seed Redemptions
            modelBuilder.Entity<Redemption>().HasData(
                new { Id = 1, Code = "ECO10-XYZ", PointsRedeemed = 100, Status = "Active", RedemptionDate = DateTime.Parse("2026-06-12"), RewardId = 1, TouristId = 1 }
            );

            // 9. Seed Trip Destinations
            modelBuilder.Entity<TripDestination>().HasData(
                new { Id = 1, Visit_Order = 1, ArrivalDate = DateTime.Parse("2026-07-02"), DepartureDate = DateTime.Parse("2026-07-06"), TripPlanId = 1, DestinationId = 1 },
                new { Id = 2, Visit_Order = 2, ArrivalDate = DateTime.Parse("2026-07-07"), DepartureDate = DateTime.Parse("2026-07-12"), TripPlanId = 1, DestinationId = 2 }
            );

            // 10. Seed Roles
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "role-admin-id", Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = "STATIC-ROLE-STAMP-1" },
                new IdentityRole { Id = "role-user-id", Name = "User", NormalizedName = "USER", ConcurrencyStamp = "STATIC-ROLE-STAMP-2" }
            );

            // 11. Seed Admin User
            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "admin-user-id",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    Email = "admin@yourteam.com",
                    NormalizedEmail = "ADMIN@YOURTEAM.COM",
                    PasswordHash = "AQAAAAEAACcQAAAAEOM7OCjj2Qn35RIy2ZkWbwA5OiG6BP0kf501wx6tAaZeWYV8w4SiIUX35viVhiAmgw==", // Static hash for Admin123Password!
                    SecurityStamp = "STATIC-STAMP-12345", 
                    ConcurrencyStamp = "STATIC-CONCURRENCY-12345" 
                }
            );

            // 12. Link Admin User to Admin Role
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "role-admin-id", 
                    UserId = "admin-user-id"
                }
            );
        }
    }
}