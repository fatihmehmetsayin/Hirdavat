using Hirdavat_Api_Nesne2.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hirdavat_Api_Nesne2.Filters
{
    public class ValidationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                ErrorDto errdto = new ErrorDto();
                errdto.status = 400;

                IEnumerable<ModelError> MdlErr = context.ModelState.Values.SelectMany(v => v.Errors);

                MdlErr.ToList().ForEach(x =>

                {
                    errdto.Errors.Add(x.ErrorMessage);

                });

                context.Result = new BadRequestObjectResult(errdto);
            }
        }
    }
}
