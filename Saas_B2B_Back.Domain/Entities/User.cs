using Saas_B2B_Back.Domain.Common;
using static Saas_B2B_Back.Domain.Common.Util;


namespace Saas_B2B_Back.Domain.Entities
{
    public class User : BaseEntity
    {

        public new long Id { get; set; }
        public string? NationalCode { get; set; }


        public required string Firstname { get; set; }


        public required string Lastname { get; set; }

        public SexType? SexCode { get; set; }

        public string? Email { get; set; }


        public required string PasswordHash { get; set; }


        public required string PhoneNumber { get; set; }

        public bool? IsProvider { get; set; }

        public bool? IsDeleted { get; set; } = false;

        public int UserGroupId { get; set; } = 1;

        public  DateTime LastSignedinAt { get; set; }

        public virtual ICollection<UserAddress>? Address { get; set; }

        public virtual ICollection<Order>? Order { get; set; }

    }

}
