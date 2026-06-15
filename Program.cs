
using Microsoft.EntityFrameworkCore;
using WebStudy.Data;

namespace WebStudy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args); //WebAPI 만들기 위한 인스턴스 생성

            var connectinonString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                throw new InvalidOperationException("Connection string 'DefaultConnection' not found");

            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectinonString));

            builder.Services.AddControllers(); //컨트롤러 사용여부

            WebApplication app = builder.Build();

            //app.UseHttpsRedirection(); //HTTPS 보안연결 설정

            app.MapControllers(); //컨트롤러를 엔드포인터와 같이 바인딩 시켜주는 개념임

            app.Run();
        }
    }
}

//namespace WebStudy
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            WebApplicationBuilder builder = WebApplication.CreateBuilder(args); 

//            builder.Services.AddControllers(); 
//            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//            builder.Services.AddEndpointsApiExplorer();
//            builder.Services.AddSwaggerGen();

//            WebApplication app = builder.Build();

//            // Configure the HTTP request pipeline.
//            if (app.Environment.IsDevelopment())
//            {
//                app.UseSwagger();
//                app.UseSwaggerUI();
//            }

//            app.UseHttpsRedirection();

//            app.UseAuthorization();

//            app.MapControllers();

//            app.Run();
//        }
//    }
//}

