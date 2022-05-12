using System.Data.Entity;
using CarbonUnits.Models.Dictionaries;
using CarbonUnits.Models.AccountPath;
using CarbonUnits.Models.UserPath;
using CarbonUnits.Models.MemberPath;
using CarbonUnits.Models.OrderPath;

namespace CarbonUnits.Models
{
    public class CarbonUnitsContext: DbContext
    {
        
        public DbSet<Member> Members{ get; set; }
    
        public DbSet<ContactPerson> ContactPerson { get; set; }
        public DbSet<PersonDocumentsTypes> PersonDocumentsTypes { get; set; }
        public DbSet<OrganizationType> OrganizationTypes { get; set; }
        public DbSet<MemberType> MemberTypes { get; set; }
        public DbSet<MemberCitizen> MemberCitizens { get; set; }
        public DbSet<AccountStates> AccountStates { get; set; } 
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<MemberHash> MemberHashes { get; set; }

        public DbSet<MemberBusinessData> MemberBusinessData { get; set; }
        public DbSet<AccountBusinessData> AccountBusinessData { get; set; }
        public DbSet<IODocumentsTypes> IODocumentsTypes { get; set; }
        public DbSet<ServiceCodes> ServiceCodes { get; set; }
        public DbSet<ServicePurposes> ServicePurposes { get; set; }
        public DbSet<OrderProcessStatuses> OrderProcessStatuses { get; set; }
        public DbSet<OrderStates> OrderStates { get; set; }
        public DbSet<OrderStateDescription> OrderStateDescription { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<MembersContactPersons> membersContactPersons { get; set; }
    }
}
