using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMS.Models;
using System.ComponentModel.DataAnnotations;

namespace CMS.Controllers
{
    #region CustomersResult
    public class CustomersResult
    {
        public string Classification;
        public string Name;
        public string Phone;
        public string Gender;
        public string City;
        public string Region;
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime LastPurchase;
        public string Seller;
    }

    #endregion

    public class HomeController : Controller
    {
        private CMSDbContext db = new CMSDbContext();
        public ActionResult Index(string searchString, string Gender, string City, string Region,string LastPurchaseFrom, string LastPurchaseTo, string Classification, string Seller)
        {
            if (Session["userID"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {

                #region Gender 
                var GenderLst = new List<string>();
                var GenderQry = from g in db.Gender
                                select g.Name;

                GenderLst.AddRange(GenderQry.Distinct());

                ViewBag.Gender = new SelectList(GenderLst);

                #endregion

                #region City 
                var CityLst = new List<string>();
                var CityQry = from c in db.City
                              select c.Name;

                CityLst.AddRange(CityQry.Distinct());

                ViewBag.City = new SelectList(CityLst);

                #endregion

                #region Region 
                var RegionLst = new List<string>();
                var RegionQry = from r in db.Region
                                select r.Name;

                RegionLst.AddRange(RegionQry.Distinct());

                ViewBag.Region = new SelectList(RegionLst);

                #endregion

                #region Classification 
                var ClassLst = new List<string>();
                var ClassQry = from c in db.Classification
                               select c.Name;

                ClassLst.AddRange(ClassQry.Distinct());

                ViewBag.Classification = new SelectList(ClassLst);

                #endregion

                #region Seller 
                var SellerLst = new List<string>();
                var SellerQry = from us in db.UserSys
                                join ur in db.UserRole on us.UserRoleId equals ur.Id
                                where ur.IsAdmin == false
                                select us.Login;

                SellerLst.AddRange(SellerQry.Distinct());

                ViewBag.Seller = new SelectList(SellerLst);

                #endregion

                #region Query

                var customers = from ct in db.Customer
                                join cl in db.Classification on ct.ClassificationId equals cl.Id
                                join g in db.Gender on ct.GenderId equals g.Id
                                join cty in db.City on ct.CityId equals cty.Id
                                join reg in db.Region on ct.RegionId equals reg.Id
                                join us in db.UserSys on ct.UserId equals us.Id
                                select new
                                {
                                    Classification = cl.Name,
                                    CustomerName = ct.Name,
                                    Phone = ct.Phone,
                                    Gender = g.Name,
                                    City = cty.Name,
                                    Region = reg.Name,
                                    LastPurchase = ct.LastPurchase,
                                    //LastPurchase = String.Format("dd/MM/yyyy", ct.LastPurchase),
                                    Seller = us.Login
                                };

                #endregion

                #region Where

                if (!String.IsNullOrEmpty(searchString))
                {
                    customers = customers.Where(s => s.CustomerName.Contains(searchString));
                }

                if (!String.IsNullOrEmpty(Gender))
                {
                    customers = customers.Where(s => s.Gender.Contains(Gender));
                }

                if (!String.IsNullOrEmpty(City))
                {
                    customers = customers.Where(s => s.City.Contains(City));
                }

                if (!String.IsNullOrEmpty(Region))
                {
                    customers = customers.Where(s => s.Region.Contains(Region));
                }

                if (!String.IsNullOrEmpty(Classification))
                {
                    customers = customers.Where(s => s.Classification.Contains(Classification));
                }

                if (!String.IsNullOrEmpty(Seller))
                {
                    customers = customers.Where(s => s.Seller.Contains(Seller));
                }

                //TODO: Insert date range


                #endregion

                #region Return Model 

                List<CustomersResult> cmodel = new List<CustomersResult>();
                foreach (var item in customers)
                {
                    cmodel.Add(new CustomersResult
                    {
                        Classification = item.Classification,
                        Name = item.CustomerName,
                        Phone = item.Phone,
                        Gender = item.Gender,
                        City = item.City,
                        Region = item.Region,
                        LastPurchase = item.LastPurchase,
                        Seller = item.Seller
                    });
                }

                return View(cmodel);

                #endregion
            }
        }

        #region Login 

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserSys user)
        {
            if (ModelState.IsValid)
            {
                using (CMSDbContext dbc = new CMSDbContext())
                {
                    string passEncrypted = Utils.Security.EncryptWithMD5Hash(user.Password);

                    var loggedUser = dbc.UserSys.Where(a => a.Email.Equals(user.Email) && a.Password.Equals(passEncrypted)).FirstOrDefault();
                    if (loggedUser != null)
                    {
                        Session["userID"] = loggedUser.Id.ToString();
                        Session["userName"] = loggedUser.Login.ToString();

                        var isAdmin = dbc.UserRole.Where(r => r.Id.Equals(loggedUser.UserRoleId) && r.IsAdmin == true).FirstOrDefault();
                        if (isAdmin != null)
                        {
                            Session["userIsAdmin"] = "TRUE";
                        }
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.Message = "The email and/or password entered is invalid. Please try again.";
                        //ModelState.AddModelError("", "The email and/or password entered is invalid. Please try again.");
                    }
                }
            }
            return View(user);
        }

        #endregion

        public ActionResult About()
        {
            ViewBag.Message = "This is a simple test for demonstration purposes. Requested by Stefanini company.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Aldo Wojciechowski - 2020, December.";

            return View();
        }
    }
}