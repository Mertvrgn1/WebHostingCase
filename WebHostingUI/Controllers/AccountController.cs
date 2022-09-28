using AspNetCoreHero.ToastNotification.Abstractions;
using WebHosting.EntityLayer.DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebHostingUI.Helper;
using System;

namespace WebHostingUI.Controllers
{
    public class AccountController : Controller
    {


        AccountAPI _api = new AccountAPI();
        private readonly INotyfService _notyf;


        [HttpGet]
        public async Task<IActionResult> GetAllHostingAccounts()
        {
            ICollection<string> hostingDomainNames = new List<string>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/account/GetAllAccounts");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                hostingDomainNames = JsonConvert.DeserializeObject<List<string>>(results);
            }

            return View(hostingDomainNames);
        }

        [HttpGet]
        public async Task<IActionResult> GetAccountByHostingDomainName(string HostingDomainName)
        {
            HostingDetailDto getAccount = new HostingDetailDto();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/account/GetAccount?HostingDomainName=" + HostingDomainName);
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                getAccount = JsonConvert.DeserializeObject<HostingDetailDto>(results);
            }
            var model = getAccount.HostingDomainName.ToString();
            ViewBag.HostingDomainName = model;
            return View(getAccount);

        }

        [HttpGet]
        public IActionResult CreateHostingAccount()
        {

            return View();

        }


        /* AJAX METHODU KULLANMADAN YAPILIŞI*/

        //[HttpPost]
        //public async Task<IActionResult> CreateHostingAccount(HostingDto dto)
        //{

        //    HttpClient client = _api.Initial();
        //    var postTask = client.PostAsJsonAsync<HostingDto>("api/account/CreateAccount", dto);
        //    postTask.Wait();
        //    var result = postTask.Result;
        //    if (result.IsSuccessStatusCode)
        //    {

        //        return RedirectToAction("GetAllHostingAccounts", "Account");
        //    }
        //    else
        //    {
        //        return View();

        //    }


        //    return View();
        //}



        [HttpPost]
        public JsonResult CreateHostingAccount(HostingDto dto)
        {

            HttpClient client = _api.Initial();

            var postTask = client.PostAsJsonAsync<HostingDto>("api/account/CreateAccount", dto);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
             
                return Json("success");
                //return RedirectToAction("GetAllHostingAccounts", "Account");

            }
            else
            {
               
                return Json("failure");
            }


        }


        [HttpPost]
        public async Task<IActionResult> DeleteHostingAccount(HostingDto dto)
        {

            HttpClient client = _api.Initial();
            var postTask = client.PostAsJsonAsync<HostingDto>("api/account/DeleteAccount", dto);
            postTask.Wait();
            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                
                return RedirectToAction("GetAllHostingAccounts", "Account");
            }
            else
            {
                return View();

            }


        }




    }
}
