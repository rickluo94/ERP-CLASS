using ERP.Dto;
using ERP.Models;
using ERP.Parameters;
using ERP.ViewModels.MakeOrderProcess;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    public class MakeOrderProcessController : Controller
    {
        public IActionResult Index()
        {   
            return View();
        }
        
        public IActionResult List(MakeOrderProcessParameter para)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Error"] = "查詢參數有誤";
                return View();
            }
            
            IEnumerable<MakeOrderProcessListDto> _modelList = new List<MakeOrderProcessListDto>
            {
                new MakeOrderProcessListDto()
                {
                    Id = "1",
                    MpBarcode = "1234",
                    Process = "雷射",
                    IsOver = null,
                    Employee = "小明",
                    MakeOrderEmployee = "admin",
                    Date = DateTime.Now,
                    OrderQty = 10,
                    Cqty = 0,
                },
                new MakeOrderProcessListDto()
                {
                    Id = "2",
                    MpBarcode = "12345",
                    Process = "切割",
                    IsOver = false,
                    Employee = "小漢",
                    MakeOrderEmployee = "admin",
                    Date =  new DateTime(DateTime.Now.AddDays(-10).Year, DateTime.Now.AddDays(-10).Month, DateTime.Now.AddDays(-10).Day, 0,0,0),
                    OrderQty = 20,
                    Cqty = 10,
                },
                new MakeOrderProcessListDto()
                {
                    Id = "3",
                    MpBarcode = "123456",
                    Process = "折彎",
                    IsOver = true,
                    Employee = "大漢",
                    MakeOrderEmployee = "admin",
                    Date = DateTime.Now.AddDays(-5),
                    OrderQty = 30,
                    Cqty = 30,
                },
            };

            var query = _modelList.AsQueryable();

            if (!String.IsNullOrWhiteSpace(para.Id))
            {
                query = query.Where(x => x.Id == para.Id);
            }

            if (!String.IsNullOrWhiteSpace(para.MpBarcode))
            {
                query = query.Where(x => x.MpBarcode == para.MpBarcode);
            }
            
            if (!String.IsNullOrWhiteSpace(para.Process))
            {
                query = query.Where(x => x.Process == para.Process);
            }
            
            if (para.IsOver != null)
            {
                query = query.Where(x => x.IsOver == para.IsOver);
            }

            if (!String.IsNullOrWhiteSpace(para.Employee))
            {
                query = query.Where(x => x.Employee == para.Employee);
            }

            if (para.StartDate != null && para.EndDate != null)
            {
                DateTime startDate = para.StartDate.Value.Date;
                DateTime endDate = para.EndDate.Value.AddDays(1).AddTicks(-1);
                query = query.Where(x => x.Date >= startDate && x.Date <= endDate);
            }

            if (para.OrderQty != null)
            {
                query = query.Where(x => x.OrderQty == para.OrderQty);
            }

            if (para.Cqty != null)
            {
                query = query.Where(x => x.Cqty == para.Cqty);
            }

            var model = new ListViewModel
            {
                Id = para.Id,
                MpBarcode = para.MpBarcode,
                Process = para.Process,
                IsOver = para.IsOver,
                Datas = query.ToList()
            };
            
            return View(model);
        }

        public IActionResult Detail()
        {
            return View();
        }
        
    }
}
