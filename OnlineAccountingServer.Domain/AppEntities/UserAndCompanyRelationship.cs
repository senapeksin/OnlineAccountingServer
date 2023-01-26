using OnlineAccountingServer.Domain.Abstractions;
using OnlineAccountingServer.Domain.AppEntities.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineAccountingServer.Domain.AppEntities
{
    public class UserAndCompanyRelationship : BaseEntity
    {
        [ForeignKey("AppUser")]

        // Bir kullanıcı birden fazla şirkette yetkili olabilsin ki şirketler arasında geçiş sağlayabilelim.
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        [ForeignKey("Company")]
        public string CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
