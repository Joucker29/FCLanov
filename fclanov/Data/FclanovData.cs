using Microsoft.EntityFrameworkCore;
using fclanov.Models;

namespace fclanov.Data
{
    public class FclanovData : DbContext
    {
        public DbSet<Models.Admin> Admins { get; set; }







        public FclanovData (DbContextOptions<FclanovData> options) : base(options) { }

}
}
