using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AtomicSeller.Helpers;
using AtomicSeller.ViewModels;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using AtomicSeller.Helpers.eCommerceConnectors;
using MiraklAPI.Models;

namespace AtomicSeller.Controllers
{
    public class HomeController : BaseController
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult PutTrackingNumber()
        {
            string strCarrierCode = "";
            string strCarrierName = "UPS";
            string strCarrierUrl = "https://wwwapps.ups.com/WebTracking/track?track=yes";
            string strTrackingNumber = "1Z2356F1ZJ98L9733M5";
            string orderId = "206272578-A";// 206301878-A 206301879-A

            PutTrackingNumberResponse _Result = new Mirakl().Mirakl_PutTrackingNumber(orderId, strCarrierCode, strCarrierName, strCarrierUrl, strTrackingNumber);

            if (string.IsNullOrEmpty(_Result.Header.ReturnMessage))
                FlashMessage.Flash(TempData, new FlashMessage("", FlashMessageType.Success, "Ok", true));
            else
                FlashMessage.Flash(TempData, new FlashMessage(_Result.Header.ReturnMessage, FlashMessageType.Warning, "Error", true));

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult GetLabel()
        {
            // 206301877-A 206301878-A 206301879-A 206301881-A 206301880-A
            string orderId = "206301878-A";
            GetLabelResponse _Result = new Mirakl().Mirakl_GetLabel(orderId);

            if (string.IsNullOrEmpty(_Result.Header.ReturnMessage))
                FlashMessage.Flash(TempData, new FlashMessage("", FlashMessageType.Success, "Ok", true));
            else
                FlashMessage.Flash(TempData, new FlashMessage(_Result.Header.ReturnMessage, FlashMessageType.Warning, "Error", true));

            return RedirectToAction("Index", "Home");
        }

        
    }
}