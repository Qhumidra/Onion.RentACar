namespace Onion.RentACar.Domain.Entities
{
    public class AppUserRole : BaseEntity
    {
        public int AppUserId { get; set; }
        public int AppRoleId { get; set; }
    }
}
