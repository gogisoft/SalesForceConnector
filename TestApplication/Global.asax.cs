using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using SalesForceConnector;
using System.Configuration;

namespace TestApplication
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            InitializeConfiguration();
        }
        private void InitializeConfiguration()
        {
            ConnectorConfig.Instance.ClientID = ConfigurationManager.AppSettings["ClientID"];
            ConnectorConfig.Instance.ClientSecret = ConfigurationManager.AppSettings["ClientSecret"];
            ConnectorConfig.Instance.GrantType = ConfigurationManager.AppSettings["GrantType"];
            ConnectorConfig.Instance.Password = ConfigurationManager.AppSettings["Password"];
            ConnectorConfig.Instance.SecurityToken = ConfigurationManager.AppSettings["SecurityToken"];
            ConnectorConfig.Instance.URL = ConfigurationManager.AppSettings["URL"];
            ConnectorConfig.Instance.UserName = ConfigurationManager.AppSettings["UserName"];
            //Initialize the Connector
            var instance = SalesForceConnector.Connector.Instance;
        }
    }
}