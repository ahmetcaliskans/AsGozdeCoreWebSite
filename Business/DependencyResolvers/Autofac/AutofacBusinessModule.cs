using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<SessionManager>().As<ISessionService>();
            builder.RegisterType<EfSessionDal>().As<ISessionDal>();

            builder.RegisterType<OfficeManager>().As<IOfficeService>();
            builder.RegisterType<EfOfficeDal>().As<IOfficeDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            //builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<BranchManager>().As<IBranchService>();
            builder.RegisterType<EfBranchDal>().As<IBranchDal>();

            builder.RegisterType<PaymentTypeManager>().As<IPaymentTypeService>();
            builder.RegisterType<EfPaymentTypeDal>().As<IPaymentTypeDal>();

            builder.RegisterType<CollectionDefinitionManager>().As<ICollectionDefinitionService>();
            builder.RegisterType<EfCollectionDefinitionDal>().As<ICollectionDefinitionDal>();

            builder.RegisterType<DriverInformationManager>().As<IDriverInformationService>();
            builder.RegisterType<EfDriverInformationDal>().As<IDriverInformationDal>();

            builder.RegisterType<CollectionManager>().As<ICollectionService>();
            builder.RegisterType<EfCollectionDal>().As<ICollectionDal>();

            builder.RegisterType<CollectionDetailManager>().As<ICollectionDetailService>();
            builder.RegisterType<EfCollectionDetailDal>().As<ICollectionDetailDal>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }

    }
}
