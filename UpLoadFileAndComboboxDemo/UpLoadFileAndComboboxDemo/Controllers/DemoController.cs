using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace UpLoadFileAndComboboxDemo.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        #region-------文件上传相关内容----------
        //文件上传相关内容  
        public async Task<IActionResult> UpLoadFile(IFormFile file)
        {
            if (file.Length > 0)
            {
                //Directory.GetCurrentDirectory()  
                //获取到当前项目程序的根路径（物理路径）
                //用这个方法，就不会使路径写死，这样无论项目存放在哪，都可以

                //Path.Combine(str1,str2)
                //此方法用于合并两个路径，且str2开头不需要写斜杠
                string basePath = Directory.GetCurrentDirectory();
                //string path = @"\wwwroot\files\" + file.FileName;
                string filePath = Path.Combine(basePath, @"wwwroot\files\" + file.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            return Ok(new { size = file.Length });
        }


        //复习文件上传：手敲第二遍。
        public async Task<IActionResult> Test(IFormFile file)
        {

            if (file.Length > 0)
            {
                string basePath = Directory.GetCurrentDirectory();
                string filePath = Path.Combine(basePath, @"wwwroot\files\" + file.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                return Ok("ok");
            }
            else
            {
                return Ok("no");
            }
        }

        #endregion

        #region--------------动态给select下拉框赋值-------------
        public IActionResult Combobox()
        {
            return View();
        }

        //获取数据源
        public string GetSelectItems()
        {
            List<Dept> dept = new List<Dept>() {
            new Dept(){ Id=1,Name="张三丰"},
            new Dept(){ Id=2,Name="吴磊"},
            new Dept(){ Id=3,Name="张国荣"}
            };
            List<SelectItem> selectItems = new List<SelectItem>();
            selectItems = dept.Where(a => a.Id > 1)
                .Select(a =>
                new SelectItem
                {
                    Value = a.Id.ToString(),
                    Text = a.Name
                })
                .ToList();
            return JsonConvert.SerializeObject(selectItems);
        }
        #endregion
    }

    public class SelectItem
    {
        public bool Selected { get; set; }
        public string Text { get; set; }
        public string Value { get; set; }
    }

    public class Dept
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}