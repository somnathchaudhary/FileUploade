using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileUplode.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FileUplode.Controllers
{
    public class UploadController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<UploadController> _logger;

        public UploadController (ILogger<UploadController>logger,IWebHostEnvironment env)
        {
            _logger = logger;
            _env = env;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UploadFile(Uploade fileUplode)
        {
            string strpath = System.IO.Path.GetExtension(fileUplode.ProfileImage.FileName);
            if (fileUplode.ProfileImage != null && (strpath == ".jpg" && strpath == ".jpeg" && strpath == ".gif" && strpath == ".png"))
            {

                string FilePath = $"{_env.WebRootPath}/images/{fileUplode.ProfileImage.FileName}";
                var stream = System.IO.File.Create(FilePath);
                fileUplode.ProfileImage.CopyTo(stream);
                return Redirect("/FileUplode/Success");
            }
            return Redirect("/");
        }
        public IActionResult Success()
        {
            return View();
        }

    }
}