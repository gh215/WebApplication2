using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using WebApplication2.Models;

namespace WebApplication2.Infrastructure
{
    using Ninject.Modules;
    using Ninject.Web.Common;

    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IValueCalculator>().To<LinqValueCalculator>().InRequestScope();
            Bind<IDiscountHelper>().To<DefaultDiscountHelper>()
                                        .WithConstructorArgument("discountParam", 10M);
            Bind<IDiscountHelper>().To<FlexibleDiscountHelper>()
                                        .WhenInjectedInto<LinqValueCalculator>();
        }
    }

}