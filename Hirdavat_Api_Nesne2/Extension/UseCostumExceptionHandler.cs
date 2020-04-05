using Hirdavat_Api_Nesne2.Dto;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Hirdavat_Api_Nesne2.Extension
{
    public static class UseCustomExceptionHandler
    {

        //extension metotlar var olan objeler üzerine extra yazdığımz metotlardır.
        //.dan sonra aşağı ok işrareti ile gösterilir
        //extension metotlar mutlata statik kod olmalı
        public static void UxeException(this IApplicationBuilder app)
        {
            //uygulama üzerinde  bir hata meydana gelirse  config üzerinden run çalışsıyor
            app.UseExceptionHandler(c =>
            {

                //run metodu request delege istiyor     
                c.Run(async contxt =>
                {
                    contxt.Response.StatusCode = 500;
                    contxt.Response.ContentType = "WebApplication/json";
                    var erroro = contxt.Features.Get<IExceptionHandlerFeature>();


                    if (erroro != null)
                    {
                        var ex = erroro.Error;
                        ErrorDto rrdt = new ErrorDto();
                        rrdt.status = 500;
                        rrdt.Errors.Add(ex.Message);


                        //response.write kullandığımızdan dolayı çevirmek zorundayız 
                        //jsonconvert newtonsorft  objeleri jason serilaze etme
                        //jason dataları deserilase etme 
                        //respons.wreteasyncn kullandığımızdan dolayı manual convert yapıyoruz 
                        await contxt.Response.WriteAsync(JsonConvert.SerializeObject(rrdt));
                    }

                    //400 client tarafında 
                    //300 yönlendirme hatası 
                    //200 başarılı durum kodu
                    //100 ile başlayanlar bilgilendirme

                });

            });


        }
    }
}
