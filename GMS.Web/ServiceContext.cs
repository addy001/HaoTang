using System;
using System.Collections.Generic;
using GMS.Account.Contract;
using GMS.Core.Cache;
using GMS.Core.Service;
using GMS.Cms.Contract;
using GMS.Crm.Contract;
using GMS.OA.Contract;
using GMS.Project.Contract;
using GMS.BasisData.Contract;

namespace GMS.Web
{
    public class ServiceContext
    {
        public static ServiceContext Current
        {
            get
            {
                return CacheHelper.GetItem<ServiceContext>("ServiceContext", () => new ServiceContext());
            }
        }
        
        public IAccountService AccountService
        {
            get
            {
                return ServiceHelper.CreateService<IAccountService>();
            }
        }

        public ICmsService CmsService
        {
            get
            {
                return ServiceHelper.CreateService<ICmsService>();
            }
        }

        public ICrmService CrmService
        {
            get
            {
                return ServiceHelper.CreateService<ICrmService>();
            }
        }

        public IOAService OAService
        {
            get
            {
                return ServiceHelper.CreateService<IOAService>();
            }
        }
        public IBasisDataService BasisDataService
        {
            get 
            {
                return ServiceHelper.CreateService<IBasisDataService>();
            }
        }
        public IProjectService ProjectService
        {
            get
            {
                return ServiceHelper.CreateService<IProjectService>();
            }
        }

    }
}
