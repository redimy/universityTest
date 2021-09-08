namespace API.Entities
{
    public class AppUserRole : Microsoft.AspNetCore.Identity.IdentityUserRole<int>
    {
        public AppUser User { get; set; }
        public AppRole Role { get; set; }
    }
}