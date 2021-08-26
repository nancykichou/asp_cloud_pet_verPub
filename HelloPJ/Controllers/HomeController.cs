using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using HelloPJ.Models;
using System.Threading;


namespace HelloPJ.Controllers
{
    //測試輸出用print
    //System.Diagnostics.Debug.WriteLine();
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (!ServerManager.server_status)
            {
                ServerManager.server_status = true;
                ServerManager.Start_Pet();
            }

            AccountManager db = new AccountManager();
            string user_id = db.get_login_info();
            //如果尚未登入，跳轉到登入頁
            if (user_id != "")
            {
                return RedirectToAction("Page_Home", "Home");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Index(Account user)
        {
            try
            {
                //確認登入是否成功，回傳0為失敗
                AccountManager db = new AccountManager();
                var user_id = db.Login(user);
                if (user_id != "0")
                {
                    db.add_login_info(user_id);
                    return RedirectToAction("Page_Home", "Home");
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("錯誤訊息：" + e.ToString());
            }
            ViewData["index_message"] = "登入失敗";
            return View();
        }

        public IActionResult Index_Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index_Registration(Account user)
        {
            if (user.user_name == null || user.user_passwd == null)
            {
                ViewData["index_message"] = "帳號與密碼不可為空";
                return View();
            }
            if (user.user_name.Replace(" ", "").Length < 6)
            {
                ViewData["index_message"] = "帳號長度不足";
                return View();
            }
            string message = "";
            try
            {
                AccountManager db = new AccountManager();
                message = db.newAccount(user);
            }
            catch
            {
                ViewData["index_message"] = "發生錯誤";
            }
            ViewData["index_message"] = message;
            return View();
        }

        public IActionResult Page_Home()
        {
            AccountManager db = new AccountManager();
            string user_id = db.get_login_info();
            //如果尚未登入，跳轉到登入頁
            if (user_id == "")
            {
                return RedirectToAction("index", "Home");
            }

            PetManager dbP = new PetManager();
            ItemManager dbI = new ItemManager();
            try
            {
                List<Pet> pet_list = dbP.UserPetsInfo(user_id);
                ViewData["pet_list"] = pet_list;
                List<Item> food_list = dbI.UserItemGet(user_id, "food");
                ViewData["food_list"] = food_list;
                List<Item> toy_list = dbI.UserItemGet(user_id, "toy");
                ViewData["toy_list"] = toy_list;
                List<Item> furniture_list = dbI.UserItemGet(user_id, "furniture");
                ViewData["furniture_list"] = furniture_list;
            }
            catch
            {

            }
            ViewData["user_id"] = user_id;
            Debug.WriteLine("目前的使用者："+user_id);
            return View();
        }

        [HttpPost]
        public IActionResult Page_Home(int item_id)
        {
            string user_id = new AccountManager().get_login_info();
            ItemManager db = new ItemManager();
            try
            {
                db.UserItemUse(user_id, item_id.ToString());
            }
            catch { 
            }
            return RedirectToAction("Page_Home", "Home");
        }

        [HttpPost]
        public ActionResult LongPolling(string pet_id)
        {
            return Json(new
            {
                pet = pet_id,
                imgurl = ServerManager.pet_dict[pet_id].pet_pic,
                px = ServerManager.pet_dict[pet_id].position_left,
                py = ServerManager.pet_dict[pet_id].position_top
            });
        }
        [HttpPost]
        public ActionResult FurnitureReturn(string furniture_id, string furniture_left, string furniture_top)
        {
            new ItemManager().Set_Furniture(furniture_id,furniture_top,furniture_left);
            return RedirectToAction("Page_Home", "Home");
        }


        [HttpPost]
        public IActionResult Set_Furniture(int item_id)
        {
            string user_id = new AccountManager().get_login_info();
            ItemManager db = new ItemManager();
            try
            {
                db.Set_Furniture(user_id, item_id);
            }
            catch
            {
            }
            return RedirectToAction("Page_Home", "Home");
        }

        public IActionResult Page_Pet()
        {
            return View();
        }

        public IActionResult Page_Store(int message = 0)
        {
            string user_id = new AccountManager().get_login_info();
            string seller_message = "";
            switch (message)
            {
                case 0:
                    seller_message = "我是寵物店員~~\n這邊的寵物都都不需要花錢\n只要你用愛心認養就能帶回家喔~~";
                    break;
                case 1:
                    seller_message = "感謝您的購買!!\n請餵飽飽您的寵物，不要讓牠們挨餓囉~~";
                    break;
                case 2:
                    seller_message = "感謝您的購買!!\n請多多陪伴您的寵物不要冷落牠們\n否則...\n牠們是會離家出走的喔!!";
                    break;
                case 3:
                    seller_message = "感謝您的購買!!\n感謝您願意給寵物們\n一個溫暖又溫馨的家~~";
                    break;
                case 4:
                    seller_message = "感謝您的愛心!!\n請好好地愛護牠喔~~";
                    break;
                case 85:
                    seller_message = "您已經有隻寵物了!!\n請先好好愛護牠喔~~";
                    break;
                case 86:
                    seller_message = "您已經擁有囉!!\n不需要再買了~~";
                    break;
                case 87:
                    seller_message = "請輸入正經的數字!!!!";
                    break;
            }

            //如果尚未登入，跳轉到登入頁
            //string user_id = new AccountManager().get_login_info();
            //如果尚未登入，跳轉到登入頁
            if (user_id == "")
            {
                return RedirectToAction("index", "Home");
            }

            /*
            HttpContext.Session.SetInt32("message_show", 50);
            List<Message> message_list = new MessageManager().getMessage("store", Convert.ToInt32(HttpContext.Session.GetInt32("message_show")));
            */

            ItemManager db = new ItemManager();
            try
            {
                List<Item> food_list = db.StoreShowItem("food");
                ViewData["food_list"] = food_list;
                List<Item> toy_list = db.StoreShowItem("toy");
                ViewData["toy_list"] = toy_list;
                List<Item> furniture_list = db.StoreShowItem("furniture");
                ViewData["furniture_list"] = furniture_list;
                List<Item> pet_list = db.StoreShowItem("pet");
                ViewData["pet_list"] = pet_list;
            }
            catch
            {

            }
            ViewData["seller_message"] = seller_message;
            ViewData["user_id"] = user_id;
            return View();
        }

        [HttpPost]
        public IActionResult Page_Buy(string user_id, string item_id, string num)
        {
            ItemManager db = new ItemManager();
            int return_num = 0;
            try
            {
                if (Convert.ToInt32(num) > 0)
                {
                    return_num = db.StoreBuyItem(user_id, item_id, Convert.ToInt32(num));
                }
            }
            catch
            {
                return_num = 87;
            }

            return RedirectToAction("Page_Store", "Home", new { message =  return_num});
        }
        [HttpPost]
        public IActionResult Page_getPet(string user_id, int pet_type, string pet_name)
        {
            ItemManager db = new ItemManager();
            try
            {
                if (db.PetCheck(user_id))
                {
                    return RedirectToAction("Page_Store", "Home", new { message = 85 });
                }
                else
                {
                    int pet_id = db.StoreGetPet(user_id, pet_name, pet_type);
                    Thread newThread = new Thread(ServerManager.New_Pet);
                    newThread.Start(pet_id);
                }
            }
            catch
            {

            }

            return RedirectToAction("Page_Store", "Home", new { message = 4 });
        }

        public IActionResult Page_Park()
        {
            AccountManager db = new AccountManager();
            string user_id = db.get_login_info();
            //如果尚未登入，跳轉到登入頁
            if (user_id == "")
            {
                return RedirectToAction("index", "Home");
            }

            try
            {
                List<Message> message_list = new MessageManager().getMessage("park", 50);
                ViewData["message_list"] = message_list;
            }
            catch (Exception e)
            {
                Debug.WriteLine("錯誤訊息：" + e.ToString());
            }
            ViewData["user_id"] = user_id;
            ViewData["account_name"] = db.getName(Convert.ToInt32(user_id));
            return View();
        }

        public IActionResult Page_Park_talking()
        {
            AccountManager db = new AccountManager();
            string user_id = db.get_login_info();
            //如果尚未登入，跳轉到登入頁
            if (user_id == "")
            {
                return RedirectToAction("index", "Home");
            }

            try
            {
                List<Message> message_list = new MessageManager().getMessage("park", 50);
                ViewData["message_list"] = message_list;
            }
            catch (Exception e)
            {
                Debug.WriteLine("錯誤訊息：" + e.ToString());
            }
            ViewData["user_id"] = user_id;
            ViewData["account_name"] = db.getName(Convert.ToInt32(user_id));
            return PartialView("Page_Park_talking");
        }

        [HttpPost]
        public IActionResult Send_Message(int user_id, string account_name, string message)
        {
            Message mes = new Message { user_id = user_id, account_name = account_name, message = message };
            MessageManager db = new MessageManager();
            try
            {
                db.newMessage(mes, "park");
            }
            catch(Exception e)
            {
                Debug.WriteLine("錯誤訊息：" + e.ToString());
            }

            return RedirectToAction("Page_Park", "Home");
        }

        public IActionResult Page_User()
        {
            AccountManager db = new AccountManager();
            string user_id = db.get_login_info();
            //如果尚未登入，跳轉到登入頁
            if (user_id == "")
            {
                return RedirectToAction("index", "Home");
            }
            ViewData["user_id"] = "目前使用者已花費的金錢為："+db.getMoney(user_id);

            return View();
        }

        public IActionResult Log_out()
        {
            AccountManager db = new AccountManager();
            db.delete_login_info();

            return RedirectToAction("index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
