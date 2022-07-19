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

            builder.RegisterType<CollectionDefinitionTypeManager>().As<ICollectionDefinitionTypeService>();
            builder.RegisterType<EfCollectionDefinitionTypeDal>().As<ICollectionDefinitionTypeDal>();

            builder.RegisterType<CollectionDefinitionAmountManager>().As<ICollectionDefinitionAmountService>();
            builder.RegisterType<EfCollectionDefinitionAmountDal>().As<ICollectionDefinitionAmountDal>();

            builder.RegisterType<DriverInformationManager>().As<IDriverInformationService>();
            builder.RegisterType<EfDriverInformationDal>().As<IDriverInformationDal>();

            builder.RegisterType<DriverPaymentPlanManager>().As<IDriverPaymentPlanService>();
            builder.RegisterType<EfDriverPaymentPlanDal>().As<IDriverPaymentPlanDal>();

            builder.RegisterType<CollectionManager>().As<ICollectionService>();
            builder.RegisterType<EfCollectionDal>().As<ICollectionDal>();

            builder.RegisterType<CollectionDetailManager>().As<ICollectionDetailService>();
            builder.RegisterType<EfCollectionDetailDal>().As<ICollectionDetailDal>();

            builder.RegisterType<Sp_GetListOfDueCoursePaymentManager>().As<Isp_GetListOfDueCoursePaymentService>();
            builder.RegisterType<Efsp_GetListOfDueCoursePaymentDal>().As<Isp_GetListOfDueCoursePaymentDal>();

            builder.RegisterType<Sp_GetPaymentManager>().As<Isp_GetPaymentService>();
            builder.RegisterType<Efsp_GetPaymentDal>().As<Isp_GetPaymentDal>();

            builder.RegisterType<Sp_GetSequentialPaymentManager>().As<Isp_GetSequentialPaymentService>();
            builder.RegisterType<Efsp_GetSequentialPaymentDal>().As<Isp_GetSequentialPaymentDal>();

            builder.RegisterType<Sp_GetListOfDriverInformationByOfficeIdManager>().As<Isp_GetListOfDriverInformationByOfficeIdService>();
            builder.RegisterType<Efsp_GetListOfDriverInformationByOfficeIdDal>().As<Isp_GetListOfDriverInformationByOfficeIdDal>();

            builder.RegisterType<Sp_GetListOfCollectionByOfficeIdManager>().As<Isp_GetListOfCollectionByOfficeIdService>();
            builder.RegisterType<Efsp_GetListOfCollectionByOfficeIdDal>().As<Isp_GetListOfCollectionByOfficeIdDal>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }

    }
}
