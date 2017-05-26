using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebAPIDemo.Models;

namespace WebAPIDemo.Controllers
{
    public class ContentsController : ApiController
    {
        DataContext db = new DataContext();
        public class UserDM
        {
            public List<UserDM> list { get; set; }
            public int NowPage { get; set; }
            public int AllPage { get; set; }
            public string USRId { get; set; }
            public string Name { get; set; }
            public string Sex { get; set; }
            public string Birthday { get; set; }
            public string Mobile { get; set; }
            public string Email { get; set; }
            public string Address { get; set; }
            public bool Check { get; set; }
        }
        public UserDM Get()
        {
            UserDM asd = new UserDM();
            IQueryable<UserDM> list = from Userss in db.USers
                                      select new UserDM
                                      {
                                          USRId = Userss.USRId,
                                          Address = Userss.Address,
                                          Birthday = Userss.Birthday,
                                          Email = Userss.Email,
                                          Sex = Userss.Sex,
                                          Name = Userss.Name,
                                          Check = false,
                                        Mobile = Userss.Mobile
                                        
                                    };
            
            asd.NowPage = 1;
            asd.AllPage = list.Count();
            if (asd.AllPage % 10 == 0)
            {
                asd.AllPage = asd.AllPage / 10;
            }
            else
            {
                asd.AllPage = asd.AllPage / 10 + 1;
            }
            if (asd.AllPage == 0)
            {
                asd.NowPage = 0;
            }
            asd.Check = false;
            asd.list = list.OrderByDescending(x => x.USRId).Skip(0*10).Take(10).ToList();
            return asd;

        }
        public UserDM Get(string type,string value,int NowPage)
        {
            if (NowPage == 0)
            {
                NowPage = 1;
            }
            UserDM asd = new UserDM();
            IQueryable<UserDM> list = null;
         
            if (type == "Name")
            {
                list = from Userss in db.USers
                                          where Userss.Name== value
                                          select new UserDM
                                          {
                                              USRId = Userss.USRId,
                                              Address = Userss.Address,
                                              Birthday = Userss.Birthday,
                                              Email = Userss.Email,
                                              Sex = Userss.Sex,
                                              Check = false,
                                              Name = Userss.Name,
                                              Mobile = Userss.Mobile
                                          };
            }
            if (type == "Sex")
            {
                 list = from Userss in db.USers
                                          where Userss.Sex == value
                                          select new UserDM
                                          {
                                              USRId = Userss.USRId,
                                              Address = Userss.Address,
                                              Birthday = Userss.Birthday,
                                              Email = Userss.Email,
                                              Check = false,
                                              Sex = Userss.Sex,
                                              Name = Userss.Name,
                                              Mobile = Userss.Mobile
                                          };
            }
            if (type == "Birthday")
            {
                list = from Userss in db.USers
                                          where Userss.Birthday == value
                                          select new UserDM
                                          {
                                              USRId = Userss.USRId,
                                              Address = Userss.Address,
                                              Birthday = Userss.Birthday,
                                              Email = Userss.Email,
                                              Check = false,
                                              Sex = Userss.Sex,
                                              Name = Userss.Name,
                                              Mobile = Userss.Mobile
                                          };
            }
            if (type == "Mobile")
            {
                 list = from Userss in db.USers
                                          where Userss.Mobile == value
                                          select new UserDM
                                          {
                                              USRId = Userss.USRId,
                                              Address = Userss.Address,
                                              Birthday = Userss.Birthday,
                                              Email = Userss.Email,
                                              Check = false,
                                              Sex = Userss.Sex,
                                              Name = Userss.Name,
                                              Mobile = Userss.Mobile
                                          };
            }
            if (type == "Email")
            {
                list = from Userss in db.USers
                                          where Userss.Email == value
                                          select new UserDM
                                          {
                                              USRId = Userss.USRId,
                                              Check = false,
                                              Address = Userss.Address,
                                              Birthday = Userss.Birthday,
                                              Email = Userss.Email,
                                              Sex = Userss.Sex,
                                              Name = Userss.Name,
                                              Mobile = Userss.Mobile
                                          };
            }
            if (type == "Address")
            {
              list = from Userss in db.USers
                                          where Userss.Address == value
                                          select new UserDM
                                          {
                                              USRId = Userss.USRId,
                                              Address = Userss.Address,
                                              Birthday = Userss.Birthday,
                                              Email = Userss.Email,
                                              Sex = Userss.Sex,
                                              Name = Userss.Name,
                                              Check = false,
                                              Mobile = Userss.Mobile
                                          };
            }
            if (value == "" || value == null)
            {
                list = from Userss in db.USers
                       select new UserDM
                       {
                           USRId = Userss.USRId,
                           Address = Userss.Address,
                           Birthday = Userss.Birthday,
                           Email = Userss.Email,
                           Sex = Userss.Sex,
                           Name = Userss.Name,
                           Check = false,
                           Mobile = Userss.Mobile
                       };
            }
            asd.NowPage = NowPage;
            asd.AllPage = list.Count();
            if (asd.AllPage % 10 == 0)
            {
                asd.AllPage = asd.AllPage / 10;
            }
            else
            {
                asd.AllPage = asd.AllPage / 10 + 1;
            }

            asd.list = list.OrderByDescending(x => x.USRId).Skip((asd.NowPage-1) * 10).Take(10).ToList();
            if (asd.AllPage == 0)
            {
                asd.NowPage = 0;
            }
            if (asd.NowPage == 0)
            {
                asd.NowPage = 1;
            }
            if (asd.AllPage == 0)
            {
                asd.NowPage = 0;
            }
            asd.Check = false;
            return asd;
        }//搜索加分页

        public void Put(User Userss)//添加信息
        {
            Userss.USRId = Guid.NewGuid().ToString();
            db.USers.Add(Userss);
            db.SaveChanges();
        }

        public void Delete(string id)//删除信息
        {
            User info = new User();
            var Userss = db.USers.Where(x => x.USRId == id).FirstOrDefault();
            db.USers.Remove(Userss);
            db.SaveChanges();
        }


    }
}