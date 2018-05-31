// ***********************************************************************
// Assembly         : ACEDrivingSchool
// Author           : Ben
// Created          : 05-29-2018
//
// Last Modified By : Ben
// Last Modified On : 05-29-2018
// ***********************************************************************

using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ACEDrivingSchool.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    /// <summary>
    /// Class ApplicationUser.
    /// </summary>
    /// <seealso cref="Microsoft.AspNet.Identity.EntityFramework.IdentityUser" />
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// generate user identity as an asynchronous operation.
        /// </summary>
        /// <param name="manager">The manager.</param>
        /// <returns>Task&lt;ClaimsIdentity&gt;.</returns>
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    /// <summary>
    /// Class ApplicationDbContext.
    /// </summary>
    /// <seealso cref="Microsoft.AspNet.Identity.EntityFramework.IdentityDbContext{ACEDrivingSchool.Models.ApplicationUser}" />
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        /// <summary>
        /// Gets or sets the customers.
        /// </summary>
        /// <value>The customers.</value>
        public DbSet<Customer> Customers { get; set; }
        /// <summary>
        /// Gets or sets the staff members.
        /// </summary>
        /// <value>The staff members.</value>
        public DbSet<Staff> StaffMembers { get; set; }
        /// <summary>
        /// Gets or sets the instructors.
        /// </summary>
        /// <value>The instructors.</value>
        public DbSet<Instructor> Instructors { get; set; }

        /// <summary>
        /// Gets or sets the durations.
        /// </summary>
        /// <value>The durations.</value>
        public DbSet<Duration> Durations { get; set; }
        /// <summary>
        /// Gets or sets the lessons.
        /// </summary>
        /// <value>The lessons.</value>
        public DbSet<Lesson> Lessons { get; set; }
        /// <summary>
        /// Gets or sets the lesson types.
        /// </summary>
        /// <value>The lesson types.</value>
        public DbSet<LessonType> LessonTypes { get; set; }
        /// <summary>
        /// Gets or sets the transmission types.
        /// </summary>
        /// <value>The transmission types.</value>
        public DbSet<TransmissionType> TransmissionTypes { get; set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>ApplicationDbContext.</returns>
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}