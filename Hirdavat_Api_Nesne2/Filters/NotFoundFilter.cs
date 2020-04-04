using Hirdavat.Core.Servisler;
using Hirdavat_Api_Nesne2.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hirdavat_Api_Nesne2.Filters
{
    public class NotFoundFilter : ActionFilterAttribute
    {
        private readonly IProductServis _IproductServis;

        public NotFoundFilter(IProductServis ıproductServis)
        {
            _IproductServis = ıproductServis;
        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {


            int id = (int)context.ActionArguments.Values.FirstOrDefault();
            var prodct = await _IproductServis.GetByIdAsync(id);


            //Prodct null değilse yani böyle bir ürün var ise  
            if (prodct != null)
            {

                // gelen requesti bir sonraki adıma atıyor.
                await next();

            }
            else
            {
                ErrorDto rrdto = new ErrorDto();
                rrdto.status = 404;

                //dolar işaretini kullandık içinde değişken var 
                rrdto.Errors.Add($"id'si{id} olan ürün veri tabanında bulunamadı");


                context.Result = new NotFoundObjectResult(rrdto);
            }




        }


    }
}
