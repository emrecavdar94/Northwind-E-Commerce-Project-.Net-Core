using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Abc.Northwind.WebUI.Middlewares
{
    //extension olması için static olması gerekir.
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseNodeModules(this IApplicationBuilder app,string root) //extend ettiğimize ulaşmak için this kullanıyoruz
        {
            var path = Path.Combine(root, "node_modules");
            var provider = new PhysicalFileProvider(path);

            var options = new StaticFileOptions();
            options.RequestPath = "/node_modules";//sana böyle bir istek gelirse
            options.FileProvider = provider;//Dosya sunumu yukarıdaki provider tarafından yapılacak
            app.UseStaticFiles(options);//Static File kullanıcam kendi options 'um ile middleware genişletiyorum.
            return app;
        }
    }
}
