using BusinessLayer.Constants;
using Castle.DynamicProxy;
using CoreLayer.Extensions;
using CoreLayer.Utilities.Interceptors;
using CoreLayer.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;
using System.Threading.Tasks;

namespace BusinessLayer.BusinessAspects.Autofac
{
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor; // Hər kəsə bir treat yaranir 

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(','); //Rolları vergül ilə ayırmaq üçün
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>(); // Windows form

        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
