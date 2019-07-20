using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abc.Northwind.Business.Abstract;
using Abc.Northwind.Business.Concrete;
using Abc.Northwind.DataAccess.Abstract;
using Abc.Northwind.DataAccess.Concrete.EntityFramework;
using Abc.Northwind.WebUI.Entities;
using Abc.Northwind.WebUI.Middlewares;
using Abc.Northwind.WebUI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Abc.Northwind.WebUI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        //dependecy injection burada gerçekleşiyor
        public void ConfigureServices(IServiceCollection services)
        {
            //alttaki servisi singleton olarakta tanımlayabilirdik AddSingleton diyerek

            services.AddScoped<IProductService, ProductManager>();// senden iproductservice istendiğinde product manageri ver newleme yapıyor onu ver
                                                                  //scoped : bir kullanıcı istekte bulundugunda productManager oluşur a kullanıcısı 2. isteği yaptıgında onun için 2.productManager oluşturur.
                                                                  //yani nesne ornekleri her istekte yenide oluşturulur.
                                                                  //transient ve scoped farkı a kullanıcısı aynı noktada aynı anda 2 Iproductservice türünde birşeye ihtiyaç duyarsa ona bir instance verilir Scopedda

            services.AddScoped<IProductDal, EfProductDal>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EfCategoryDal>();
            services.AddSingleton<ICartSessionService, CartSessionService>();
            services.AddSingleton<ICartService, CartService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddDbContext<CustomIdentityDbContext>(options=>
                options.UseSqlServer("server=(localdb)\\MSSQLLocalDB;Database=Northwind;Trusted_Connection=true"));
            services.AddIdentity<CustomerIdentityUser, CustomerIdentityUser>()
                .AddEntityFrameworkStores<CustomIdentityDbContext>().AddDefaultTokenProviders();
            services.AddSession();
            services.AddDistributedMemoryCache();
            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        { //bunlar middleware yaşam döngüsünü kendimiz ekleyip çıkarıyoruz .net mvc de hepsi yükleniyordu buda performans kaybına neden oluyordu
            if (env.IsDevelopment()) //hata yönetimi
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles(); //static file kullanımı için
            app.UseFileServer();
            app.UseNodeModules(env.ContentRootPath);
            app.UseIdentity();
            app.UseSession();
            app.UseMvcWithDefaultRoute();//route
        }
    }
}
