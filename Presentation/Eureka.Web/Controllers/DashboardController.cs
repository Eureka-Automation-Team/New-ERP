using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eureka.Services.Manufacturing;
using Eureka.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Controller = Microsoft.AspNetCore.Mvc.Controller;
using JsonResult = Microsoft.AspNetCore.Mvc.JsonResult;

namespace Eureka.Web.Controllers
{
    public class DashboardController : Controller
    {
        private MESContext context { get; }

        public DashboardController(MESContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            double availableTime;
            double productionProcess;
            double processPer;
            double timeProgress;
            double timePlan;
            double timePlanVsAvailable;
            double actualPercentage;
            int taskActual;
            int taskCount;
            //IEnumerable<MfgJobTasks> data = await context.MfgJobTasks.Where(x => x.StartDate.Date.Equals(DateTime.Now.Date)).ToListAsync();
            IEnumerable<MfgMachines> machine = await context.MfgMachines.ToListAsync();
            availableTime = machine.Sum(x => x.WorkingHr * 60).AsDouble();

            double ts = 0;
            foreach(var item in machine)
            {
                string iString = DateTime.Now.ToString("yyyy-MM-dd")+" "+ item.StartTime.AsDateTime().ToString("HH:mm");
                DateTime oDate = DateTime.ParseExact(iString, "yyyy-MM-dd HH:mm", null);
                double tsi;
                tsi = DateTime.Now.Subtract(oDate).TotalMinutes;
                ts = ts + tsi;
            }

            IEnumerable<MfgJobTasks> data = await context.MfgJobTasks.Where(x => x.ReleaseFlag == 1).ToListAsync();
            
            List<MfgJobTasks> tasksQueuing = data.Where(x => x.McFinishFlag == 0)
                                                .OrderBy(o => o.Priority)
                                                .ThenBy(o => o.StartDate)
                                                .ToList();
            ViewBag.TasksQueuing = tasksQueuing;

            taskCount = data.Count();
            taskActual = data.Where(x => x.StartFlag == 1).Count();
            timePlan = data.Sum(x => x.StandardTime).AsDouble();
            timeProgress = ts;

            ViewBag.AvailableTime = availableTime;
            ViewBag.AvailableTimeHH = string.Format("{0:00}:{1:00}", availableTime / 60, availableTime % 60);

            timePlanVsAvailable = (timePlan / availableTime) * 100;
            processPer = (timeProgress / availableTime) * 100;
            

            ViewBag.TimeProgress = Convert.ToInt32(processPer);
            ViewBag.PlanVsAvailabl = Convert.ToInt32(timePlanVsAvailable);
            
            ViewBag.TotalTask = taskCount;
            ViewBag.ActualTask = taskActual;
            actualPercentage = (taskActual.AsDouble() / taskCount.AsDouble()) * 100;
            ViewBag.ActualPercentage = Convert.ToInt32(actualPercentage);
            productionProcess = (Convert.ToInt32(actualPercentage) * Convert.ToInt32(timePlanVsAvailable)) / 100;
            ViewBag.ProductionProcess = Convert.ToInt32(productionProcess);
            return View();
        }

        public JsonResult GetValues(string sidx, string sord, int page, int rows) //Gets the todo Lists.  
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            IEnumerable<MfgJobTasks> data = context.MfgJobTasks.Where(x => x.ReleaseFlag == 1).ToList();

            IEnumerable<MfgJobTasks> tasksQueuing = data.Where(x => x.McFinishFlag == 1)
                                                .OrderBy(o => o.Priority)
                                                .ThenBy(o => o.StartDate)
                                                .ToList();

            int totalRecords = tasksQueuing.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sord.ToUpper() == "DESC")
            {
                tasksQueuing = tasksQueuing.OrderByDescending(s => s.Priority);
                tasksQueuing = tasksQueuing.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                tasksQueuing = tasksQueuing.OrderBy(s => s.Priority);
                tasksQueuing = tasksQueuing.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = tasksQueuing
            };
            return Json(jsonData, System.Web.Mvc.JsonRequestBehavior.AllowGet);
        }

        public IEnumerable<MfgJobTasks> GetQueuing()
        {
            IEnumerable<MfgJobTasks> result = context.MfgJobTasks.Where(x => x.ReleaseFlag == 1)
                                                .OrderBy(o => o.Priority)
                                                .ThenBy(o => o.StartDate)
                                                .ToList();

            return result.ToArray();
        }

        public async Task<IActionResult> TestTable()
        {
            IEnumerable<MfgJobTasks> data = await context.MfgJobTasks.Where(x => x.ReleaseFlag == 1).ToListAsync();

            List<MfgJobTasks> tasksQueuing = data.Where(x => x.McFinishFlag == 0)
                                                .OrderBy(o => o.Priority)
                                                .ThenBy(o => o.StartDate)
                                                .ToList();
            ViewBag.TasksQueuing = tasksQueuing;

            return View();
        }
    }
}