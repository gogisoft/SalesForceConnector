using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestApplication.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Accounts()
        {
            var accounts = SalesForceConnector.Connector.Instance.GetAccounts();
            Models.Accounts model = new Models.Accounts();
            model.Objects.AddRange(accounts.OrderBy(p=> p.Name).Take(10));
            return PartialView(model);
        }
        public ActionResult Contacts()
        {
            var contacts = SalesForceConnector.Connector.Instance.GetContacts();
            Models.Contacts model = new Models.Contacts();
            model.Objects.AddRange(contacts.OrderBy(p => p.Name).Take(10));
            return PartialView(model);
        }
        public ActionResult Users()
        {
            var users = SalesForceConnector.Connector.Instance.GetUsers();
            Models.Users model = new Models.Users();
            model.Objects.AddRange(users.OrderBy(p => p.Name).Take(10));
            return PartialView(model);
        }
    }
}
