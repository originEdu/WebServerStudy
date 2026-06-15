using Microsoft.EntityFrameworkCore;
using WebStudy.Models;

namespace WebStudy.Data
{
    // ASP.NET Core DB 관련 명령어 : 마이그레이션 -> 내 데이터 클래스 모양 그대로 DB 테이블을 알아서 만들어줘!
    public class ApplicationDbContext : DbContext
    {
        public DbSet<GameResult> GameResults { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
