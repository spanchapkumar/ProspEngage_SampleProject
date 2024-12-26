using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using ProspEngage.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ProspEngage.DataAccess
{
    public class UserManagementDbContext : DbContext, IUserManagementDbContext
    {
        private readonly IConfiguration _configuration;
        

        public UserManagementDbContext(DbContextOptions<UserManagementDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                var connectionString = _configuration.GetConnectionString("DefaultConnection");

                // Use Active Directory Interactive Authentication
                var sqlConnection = new SqlConnection(connectionString);
                // sqlConnection.AccessToken = GetAccessToken(); // Fetch MFA Token
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        private string GetAccessToken()
        {
            var app = PublicClientApplicationBuilder.Create("YOUR_CLIENT_ID")
                .WithAuthority(AzureCloudInstance.AzurePublic, "YOUR_TENANT_ID")
                .WithDefaultRedirectUri()
                .Build();

            var result = app.AcquireTokenInteractive(new[] { "https://database.windows.net//.default" }).ExecuteAsync().Result;
            return result.AccessToken;
        }


        public DbSet<User> Users { get; set; }
        public DbSet<RoleMaster> Roles { get; set; }
        public DbSet<ProfileMaster> Profiles { get; set; }
        // Implementation of IUserManagementDbContext Methods

        // Get All Users
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await Users.ToListAsync();
        }

        // Get User by Id
        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await Users.FirstOrDefaultAsync(u => u.UserId == userId);
        }

        // Add User
        public async Task AddUserAsync(User user)
        {
            await Users.AddAsync(user);
            await SaveChangesAsync();
        }

        // Update User
        public async Task UpdateUserAsync(User user)
        {
            Users.Update(user);
            await SaveChangesAsync();
        }

        // Delete User
        public async Task DeleteUserAsync(int userId)
        {
            var user = await GetUserByIdAsync(userId);
            if (user != null)
            {
                Users.Remove(user);
                await SaveChangesAsync();
            }
        }

        // Override SaveChangesAsync to handle cancellation
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}
