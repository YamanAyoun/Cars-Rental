using Cars_Rental.Models;
using Cars_Rental.Models.Interface;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cars_Rental.Data
{
    public class CarRentDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Admin> Admins { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Customer> customers { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<BookingCar> BookingCar { get; set; }

        public CarRentDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Company>().HasData(
              new Company { Id = 1, UserName = "BMW Rental", Email = "BMWRental@Gmail.com", Password = "Bmw123", ProfilePicture = "https://behappylimo.com/wp-content/uploads/2023/05/car-rental-vector-13423582.jpg", Rate = 0, Address = "Amman", PhoneNumber = "962791234567", CommercialRegistrationNumber = 123456789 },
              new Company { Id = 2, UserName = "BENZ Rental", Email = "BENZRental@Gmail.com", Password = "Benz123", ProfilePicture = "https://behappylimo.com/wp-content/uploads/2023/05/car-rental-vector-13423582.jpg", Rate = 4, Address = "Irbid", PhoneNumber = "962791234567", CommercialRegistrationNumber = 123456789 },
              new Company { Id = 3, UserName = "TOYOTA Rental", Email = "TOYOTARental@Gmail.com", Password = "Toyota123", ProfilePicture = "https://behappylimo.com/wp-content/uploads/2023/05/car-rental-vector-13423582.jpg", Rate = 2, Address = "Jarash", PhoneNumber = "962791234567", CommercialRegistrationNumber = 123456789 },
              new Company { Id = 4, UserName = "KIA Rental", Email = "KIARental@Gmail.com", Password = "Kia123", ProfilePicture = "https://behappylimo.com/wp-content/uploads/2023/05/car-rental-vector-13423582.jpg", Rate = 1, Address = "Amman", PhoneNumber = "962791234567", CommercialRegistrationNumber = 123456789 }
              );

            modelBuilder.Entity<Car>().HasData(
            new Car { Id = 1, CompanyId = 1, Name = "KIA", Color = "Red", Year = 2022, Model = "sportage", ImageUrl = "https://behappylimo.com/wp-content/uploads/2023/05/car-rental-vector-13423582.jpg", PricePerDay = 25, PlateNumber = "Jo-12-1234" },
            new Car { Id = 2, CompanyId = 2, Name = "BMW", Color = "Black", Year = 2022, Model = "m5", ImageUrl = "https://behappylimo.com/wp-content/uploads/2023/05/car-rental-vector-13423582.jpg", PricePerDay = 35, PlateNumber = "Jo-13-123" },
            new Car { Id = 3, CompanyId = 3, Name = "Toyota", Color = "Blue", Year = 2022, Model = "camry", ImageUrl = "https://behappylimo.com/wp-content/uploads/2023/05/car-rental-vector-13423582.jpg", PricePerDay = 30, PlateNumber = "Jo-14-24685" },
            new Car { Id = 4, CompanyId = 3, Name = "Mercedes", Color = "White", Year = 2022, Model = "s-class", ImageUrl = "https://behappylimo.com/wp-content/uploads/2023/05/car-rental-vector-13423582.jpg", PricePerDay = 75, PlateNumber = "Jo-10-10" }
              );
            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, UserName = "Sami", Email = "sami@gmail", PhoneNumber = "0700808070", Gender = 'M', NationalNumber = 996, Address = "Amman", Password = "Sami123" },
                new Customer { Id = 2, UserName = "Ali", Email = "ali@gmail", PhoneNumber = "0716148123", Gender = 'M', NationalNumber = 988, Address = "Amman", Password = "Ali123" },
                new Customer { Id = 3, UserName = "Mohammed", Email = "mohammed@gmail", PhoneNumber = "0762355853", Gender = 'M', NationalNumber = 995, Address = "Jarash", Password = "Mohammed123" }
                );

            modelBuilder.Entity<Admin>().HasData(
              new Admin { Id = 1, Name = "Admin", Email = "Admin@Gmail.com", Password = "Admin123" }
             );
        }
    }
}
