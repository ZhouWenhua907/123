using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using lotteryDemo;
using common;

namespace lotteryDemo
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // 在应用程序启动时运行的代码
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterOpenAuth();

            Appconfig.Load();
            DBOperator.ConnectString = Appconfig.ConnectString;

            BaseEntity.IsDebug = Appconfig.IsDeug;
            BaseEntity.DBTimeout = Appconfig.DBTimeout;
            BaseEntity.ConnectString = Appconfig.ConnectString;

            
            
        }

        void Application_End(object sender, EventArgs e)
        {
            //  在应用程序关闭时运行的代码

        }

        void Application_Error(object sender, EventArgs e)
        {
            // 在出现未处理的错误时运行的代码

        }
    }
}
