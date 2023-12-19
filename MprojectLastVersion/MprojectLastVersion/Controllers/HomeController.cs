using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MprojectLastVersion.Models;
using MprojectLastVersion.DataDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MprojectLastVersion.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public ActionResult KayitOl()
        {

            return View();
        }
       [HttpPost]
        public ActionResult KayitOl(User users, bool secim)
        {
            try
            {
                using (MailProjectContext dbmodel = new MailProjectContext())
                {

                    if (dbmodel.Users.Where(x => x.EmailAddress == users.EmailAddress).FirstOrDefault() != null)
                    {

                        ViewBag.Message2 = string.Format("Bu Mail Adresi İle Bir Kayıt Mevcut");
                        return View();

                    }
                    else if (users.EmailAddress == null && users.Password != null)
                    {

                        ViewBag.Message2 = string.Format("E-Mail Adresinizi Girdikten Sonra Tekrara Deneyiniz.");
                        return View();

                    }
                    else if (users.EmailAddress != null && users.Password == null)
                    {

                        ViewBag.Message2 = string.Format("Şifrenizi Girdikten Sonra Tekrara Deneyiniz.");
                        return View();


                    }
                    else if (users.EmailAddress == null && users.Password == null)
                    {
                        ViewBag.Message2 = string.Format("Lütfen E-Mail Ve Şifrenizi Zorunlu Bilgilerdir.");
                        return View();
                    }
                    else if (dbmodel.Users.Where(x => x.EmailAddress == users.EmailAddress).FirstOrDefault() == null)
                    {
                        User kayit = new User
                        {
                            FristName = users.FristName,
                            LastName = users.LastName,
                            EmailAddress = users.EmailAddress,
                            CreateDate = DateTime.Now,
                            Status = secim,
                            Password = users.Password,
                            LastLoginDate = DateTime.Now


                        };

                        dbmodel.Users.Add(kayit);
                        dbmodel.SaveChanges();
                        TempData["KullaniciId"] = dbmodel.Users.Where(x => x.EmailAddress == users.EmailAddress && x.Password == users.Password).FirstOrDefault().Id;
                        return View("Index");
                    }
                    else
                        ViewBag.Message2 = string.Format("hata.");
                    return View();



                }
            }
            catch
            {

                throw;
            }


        }
  
        
        public ActionResult LogIn(User users)
        {
            if (TempData["KullaniciId"] == null || Convert.ToInt32(TempData["KullaniciId"]) == 0)
            {

                try
                {
                    using (MailProjectContext dbmodel = new MailProjectContext())
                    {


                        if (dbmodel.Users.Where(x => x.EmailAddress == users.EmailAddress && x.Password == users.Password).FirstOrDefault() != null)
                        {
                            TempData["KullaniciId"] = dbmodel.Users.Where(x => x.EmailAddress == users.EmailAddress && x.Password == users.Password).FirstOrDefault().Id;


                            var updatelog = dbmodel.Users.FirstOrDefault(x => x.Id == dbmodel.Users.Where(x => x.EmailAddress == users.EmailAddress && x.Password == users.Password).FirstOrDefault().Id);
                            /*   users.LastLoginDate= DateTime.Now;
                                if (dbmodel.Users.Where(x=>x.Id==Convert.ToInt32(updatelog)).FirstOrDefault().EmailAddress== users.EmailAddress)
                                {
                                    dbmodel.Entry(users).State = EntityState.Modified;
                                    /*  User us = new User
                                      {
                                          LastLoginDate = DateTime.Now,
                                      };

                                      dbmodel.Entry(us);
                                    dbmodel.SaveChanges();
                                }
                            */
                            /*  var guncelle = from x in dbmodel.Users

                                             where x.Id == Convert.ToInt32(updatelog)
                                             select x;*/


                            User kullanici = dbmodel.Users.Single(x => x.Id == Convert.ToInt32(TempData["KullaniciId"]));
                            kullanici.LastLoginDate = DateTime.Now;
                            dbmodel.SaveChanges();

                            return RedirectToAction("MainPage");


                        }
                        else if (users.EmailAddress == null && users.Password != null)
                        {

                            ViewBag.Message = string.Format("E-Mail Adresinizi Girdikten Sonra Tekrara Deneyiniz.");
                            return View();

                        }
                        else if (users.EmailAddress != null && users.Password == null)
                        {

                            ViewBag.Message = string.Format("Şifrenizi Girdikten Sonra Tekrara Deneyiniz.");
                            return View();


                        }
                        else if (users.EmailAddress == null && users.Password == null)
                        {
                            ViewBag.Message = string.Format("Lütfen E-Mail Ve Şifrenizi Girip Tekrar Deneyiniz.");
                            return View();
                        }
                        else

                            ViewBag.Message = string.Format("Bilgilerinizin Dogrulugunu Kontrol Ediniz.");
                        return View();

                    }

                }
                catch (Exception ex)
                {

                    return View(ex);
                }
            }
            else
            { 
            //    return RedirectToAction("Dashboard");
            return RedirectToAction("MainPage");
        }
        }

        public ActionResult CreateG()
        {
            return View();

        }
        [HttpPost]
        public ActionResult CreateG(string name)
        {

            using (MailProjectContext dBmodel = new MailProjectContext())
            {
                Group ekle = new Group();
                ekle.Name = name;
                ekle.CreateUserId = Convert.ToInt32(TempData["KullaniciId"]);
                ekle.CreateDate = DateTime.Now;
                dBmodel.Groups.Add(ekle);
                dBmodel.SaveChanges();
                return RedirectToAction("Groups");
            }
        }
            public ActionResult Create()
        {
          
            using (MailProjectContext dBmodel = new MailProjectContext())
            {

                DoubleModel listele = new DoubleModel();
                Campaign cp = new Campaign();
              listele.Mgroup = dBmodel.Groups.ToList();
                listele.Camp = dBmodel.Campaigns.ToList();



                return View(listele);
            }

            if (Convert.ToInt32(TempData["KullaiciId"]) <= 0 || TempData["KullaiciId"] == null)

            { return RedirectToAction("Index"); }
        }
        [HttpPost]
        public ActionResult Create(DoubleModel campaign,string mod,string seciligroup,string Name, string subject, string fromname, string fromemailaddress, string content, string mailsendaddress)
        {
            try
            {
                // TODO: Add insert logic here
                using (MailProjectContext dBmodel = new MailProjectContext())
                {
                    bool i;
                    if (mod == "ACTIVE")
                    { i = true; }
                    else
                        i = false;
                    int gid;
                    gid = dBmodel.Groups.Where(x => x.Name == seciligroup).FirstOrDefault().Id;


                    Campaign createc = new Campaign {

                        Name = Name,
                        Subject = subject,
                        FromName = fromname,
                        FromEmailAddress = fromemailaddress,
                        Content = content,
                        MailSendAddress = mailsendaddress,
                        GroupId = gid,
                        CreateUserId = Convert.ToInt32(TempData["KullaniciId"]),
                        CreateDate = DateTime.Now,
                        Status = i
                      
                    

                    };
                    dBmodel.Campaigns.Add(createc);
                    dBmodel.SaveChanges();

                }

                return RedirectToAction("Campaigns");
            }
            catch
            {
                return View();
            }
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public ActionResult MainPage()
        {
             using (MailProjectContext contx = new MailProjectContext())
            {

         //       TempData["ccount"] =  contx.Campaigns.ToList().Count();
           //     TempData["gcount"] =  contx.Groups.ToList().Count();
             //   TempData["mcount"] =  contx.MailAddresses.ToList().Count();

            }
          /*  if (Convert.ToInt32(TempData["KullaiciId"]) <= 0 || TempData["KullaiciId"] == null)

            { return RedirectToAction("LogIn"); }*/

            return View();

        }
        public ActionResult Dedit(int id)
        {
           /* if (Convert.ToInt32(TempData["KullaiciId"]) <= 0 || TempData["KullaiciId"] == null)

            { return RedirectToAction("Index"); }*/
            using (MailProjectContext dBmodel = new MailProjectContext())
            {
                return View(dBmodel.Campaigns.Where(x => x.Id == id).FirstOrDefault());
            }
            }
        [HttpPost]

        public ActionResult Dedit(Campaign campaign)
        {
           /* var campaigns = from c in Campaign
                            where c.Id == id
                            select c;
            foreach (Campaign item in campaigns)
            {
                item.Content = campaign.Content;
            }*/
            try
            {
                using (MailProjectContext dBmodel = new MailProjectContext())
                {
                    dBmodel.Entry(campaign).State = EntityState.Modified;
                    dBmodel.SaveChanges();
                }
                return RedirectToAction("Campaigns");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Campaigns()
        {
          
            using (MailProjectContext context= new MailProjectContext())
            {
                return View(context.Campaigns.ToList());
            }
           /* if (Convert.ToInt32(TempData["KullaiciId"]) <= 0 || TempData["KullaiciId"] == null)

            { return RedirectToAction("Index"); }*/

        }
        public ActionResult Groups()
        {

            using (MailProjectContext context = new MailProjectContext())
            {
                return View(context.Groups.ToList());
            }
            /* if (Convert.ToInt32(TempData["KullaiciId"]) <= 0 || TempData["KullaiciId"] == null)

             { return RedirectToAction("Index"); }*/

        }
        public ActionResult EditG(int id)
        {
            using (MailProjectContext dBmodel = new MailProjectContext())
            {

                return View(dBmodel.Campaigns.Where(x => x.Id == id).FirstOrDefault());
            }
        }
    [HttpPost]
        public ActionResult EditG(Group group)
        {

                try
                {
                    using (MailProjectContext dBmodel = new MailProjectContext())
                    {
                        dBmodel.Entry(group).State = EntityState.Modified;
                        dBmodel.SaveChanges();
                        
                    }
                    return RedirectToAction("Groups");
                }
                catch
                {
                    return View();
                }
            
        }
        public ActionResult DetailsG(int id)
        {
            using (MailProjectContext cntx = new MailProjectContext())

            {
                var groups = from c in cntx.Groups
                               where c.Id == id
                               select c;
                // return View(cntx.Campaigns.Where(x => x.Id == id).ToList());
                //

                return View(groups.ToList());

            }
        }

        public ActionResult Details(int id)
        {
            using (MailProjectContext cntx = new MailProjectContext())

            {
                var campaign = from c in cntx.Campaigns
                          where c.Id == id
                            select c;
                // return View(cntx.Campaigns.Where(x => x.Id == id).ToList());
                //

                return View(campaign.ToList());
            
            }
        }
        public ActionResult DeleteG(int id)
        {
            using (MailProjectContext dBmodel = new MailProjectContext())
            {
                var kont = dBmodel.MailAddressGroups.Where(x=>x.GroupId==id).Count();
                if (kont >0)
                { return RedirectToAction("Groups"); }
                else
                {
                    Group gr = dBmodel.Groups.Where(x => x.Id == id).FirstOrDefault();
                    dBmodel.Groups.Remove(gr);
                    dBmodel.SaveChanges();
                    return RedirectToAction("Groups");
                }
            }
        }
        public ActionResult Delete(int id)
        {
            using (MailProjectContext dBmodel = new MailProjectContext())
            {

                Campaign cam = dBmodel.Campaigns.Where(x => x.Id == id).FirstOrDefault();
                dBmodel.Campaigns.Remove(cam);
                dBmodel.SaveChanges();
                return RedirectToAction("Campaigns");
            }
        }
        public ActionResult MailAddressDetails()
        {

            using (MailProjectContext context = new MailProjectContext())
            {
                return View(context.MailAddresses.ToList());
            }
        }
        public ActionResult DeleteM(int id)
        {
            using (MailProjectContext dBmodel = new MailProjectContext())
            {

                MailAddress ma = dBmodel.MailAddresses.Where(x => x.Id == id).FirstOrDefault();
                dBmodel.MailAddresses.Remove(ma);
                dBmodel.SaveChanges();
                return RedirectToAction("MailAddressDetails");
            }
        }
        public ActionResult CreateM()
        {
            using (MailProjectContext dBmodel = new MailProjectContext())
            {
                Class C1 = new Class();

                C1.grup = dBmodel.Groups.Select(s=> new Group { Id=s.Id,Name=s.Name }).ToList();

                return View(C1);
            }
        }
        [HttpPost]
        public ActionResult CreateM(Class C1,string mailaddress,string firstname,string lastname,string secim2,string secim1,Group data,string[] chk)
        {
            using (MailProjectContext dBmodel = new MailProjectContext())
            {
                bool d;
               
                if (secim2 =="1")
                { d = true; }
                else
                    d = false;
                MailAddress ma = new MailAddress
                {

                    FirstName = firstname,
                    LastName = lastname,
                    MailAddress1 = mailaddress,
                    CreateDate=DateTime.Now,
                    Status=d

                };
                dBmodel.MailAddresses.Add(ma);
                dBmodel.SaveChanges();
                for (int i = 0; i < chk.Count(); i++)
                {
                    int grupidbul = dBmodel.Groups.Where(c => c.Name == Convert.ToString(chk[i])).FirstOrDefault().Id;
                    var gelenid = dBmodel.MailAddresses.Where(x => x.MailAddress1 == mailaddress).FirstOrDefault().Id;
                    MailAddressGroup MG = new MailAddressGroup
                    {
                        MailAddressId = gelenid,
                        GroupId = grupidbul,
                        SubscriptionDate = DateTime.Now,
                        SubscriptionStatus = true,
                        CreateDate = DateTime.Now


                    };
                    dBmodel.MailAddressGroups.Add(MG);
                    dBmodel.SaveChanges();

                }

                return RedirectToAction("MailAddressDetails");
                
            }

        }
        public ActionResult DetailsM(int id)
        {
            using (MailProjectContext cx = new MailProjectContext())
            {
                var MailAddressback = from c in cx.MailAddresses
                               where c.Id == id
                               select c;
                return View(MailAddressback.ToList());
            }
        }
        public ActionResult EditM(int id)
        {
            using (MailProjectContext dBmodel = new MailProjectContext())
            {

                return View(dBmodel.MailAddresses.Where(x => x.Id == id).FirstOrDefault());
            }
        }
        [HttpPost]
        public ActionResult EditM(MailAddress mailAddress1, string mailaddress, string firstname, string lastname, string select,string date,int id)
        {
            try
            {
                bool d;

                if (select == "1")
                { d = true; }
                else
                    d = false;
                using (MailProjectContext dBmodel = new MailProjectContext())
                {
                    List<MailAddress> updatem =(from m in dBmodel.MailAddresses
                                           where m.Id == id
                                           select m).ToList();
                    foreach (MailAddress m in updatem)
                    {
                        m.FirstName = firstname;
                        m.LastName = lastname;
                        m.Status = d;
                        m.CreateDate=Convert.ToDateTime(date);
                        m.MailAddress1 = mailaddress;
                    }
                    dBmodel.SaveChanges();
                  

                }
                return RedirectToAction("MailAddressDetails");
            }
            catch
            {
                return View();
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public ActionResult test()
        {
            using (MailProjectContext dBmodel = new MailProjectContext())
            {
                Class cs = new Class();
                cs.grup = dBmodel.Groups.ToList();
                cs.madres = dBmodel.MailAddresses.ToList();
                return View(cs);
            }
        }
        [HttpPost]
        public ActionResult test(string mailaddress, string firstname, string lastname, string secim3)
        {
            using (MailProjectContext dBmodel = new MailProjectContext())
            {
                bool d;

                if (secim3 == "1")
                { d = true; }
                else
                    d = false;
                MailAddress ma = new MailAddress
                {

                    FirstName = firstname,
                    LastName = lastname,
                    MailAddress1 = mailaddress,
                    CreateDate = DateTime.Now,
                    Status = d

                };
                dBmodel.MailAddresses.Add(ma);
                dBmodel.SaveChanges();
                return RedirectToAction("MailAddressDetails");

            }

        }
    }
}