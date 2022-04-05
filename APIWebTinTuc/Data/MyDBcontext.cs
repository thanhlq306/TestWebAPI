using Microsoft.EntityFrameworkCore;

namespace APIWebTinTuc.Data
{
    public class MyDBcontext : DbContext
    {
        public MyDBcontext(DbContextOptions options): base(options) { }

        #region DbSet
        public DbSet<DataBaiViet> dataBaiViets { get; set; }
        public DbSet<LoaiBaiViet> dataLoais { get; set; }
        #endregion
    }
}
