using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using System.Diagnostics;
using System.Security.Claims;
using To_Do_List.Models;
using Microsoft.AspNetCore.Authorization;

namespace To_Do_List.Controllers
{
    public class HomeController : Controller
    {
        private readonly ToDoListContext _context;

        public HomeController(ToDoListContext context)
        {
            _context = context;
        }

        // =========================
        // LOGIN
        // =========================

        [HttpGet]
        public IActionResult login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> login(string LoginEmail, string LoginPassword)
        {
            var user = await _context.TblUsers
                .FirstOrDefaultAsync(e =>
                    e.UserEmail == LoginEmail &&
                    e.UserPassword == LoginPassword);

            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserEmail)
                };

                var identity = new ClaimsIdentity(
                    claims,
                    "myCookieAuth");

                var principal = new ClaimsPrincipal(identity);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddDays(7)
                };

                await HttpContext.SignInAsync(
                    "myCookieAuth",
                    principal,
                    authProperties);

                return RedirectToAction(nameof(Main));
            }

            ViewBag.LoginError = "Invalid email or password.";
            return View();
        }

        // =========================
        // LOGOUT
        // =========================

        [Authorize]
        public async Task<IActionResult> logout()
        {
            await HttpContext.SignOutAsync("myCookieAuth");

            return RedirectToAction(nameof(login));
        }

        // =========================
        // INDEX
        // =========================

        public IActionResult Index()
        {
            if (User.Identity?.IsAuthenticated == true)
            {
                return RedirectToAction(nameof(Main));
            }

            return View();
        }

        // =========================
        // DASHBOARD
        // =========================

        [Authorize]
        public async Task<IActionResult> Main()
        {
            var loginUser = User.FindFirstValue(ClaimTypes.Name);

            if (string.IsNullOrWhiteSpace(loginUser))
            {
                return RedirectToAction(nameof(login));
            }

            ViewBag.userName = await _context.TblUsers
                .Where(u => u.UserEmail == loginUser)
                .Select(u => u.UserName)
                .FirstOrDefaultAsync();

            ViewBag.welcome = "Welcome, ";

            var query = _context.TblTasks
                .Where(t => t.TaskUser == loginUser);

            var totalTasks = await query.ToListAsync();

            ViewBag.totalTasks = totalTasks.Count;
            ViewBag.totalTasksList = totalTasks;

            ViewBag.pendingTasks = await query
                .Where(t => t.Status != null &&
                            t.Status.ToLower() == "pending")
                .CountAsync();

            ViewBag.completedTasks = await query
                .Where(t => t.Status != null &&
                            t.Status.ToLower() == "completed")
                .CountAsync();

            var today = DateOnly.FromDateTime(DateTime.Today);
            var sevenDaysLater =
                DateOnly.FromDateTime(DateTime.Today.AddDays(7));

            var categories = await _context.TblCategories
                .Where(c =>
                    _context.TblTasks.Any(t =>
                        t.TaskUser == loginUser &&
                        t.TaskCategory == c.CategoryId)
                    || c.User == null)
                .ToListAsync();

            ViewBag.categories = categories;

            ViewBag.todaysCompletedCount = await query
                .Where(t =>
                    t.TaskDate == today &&
                    t.Status != null &&
                    t.Status.ToLower() == "completed")
                .CountAsync();

            var todaysTasks = await query
                .Where(t => t.TaskDate == today)
                .OrderBy(t =>
                    (t.Status ?? "").Trim().ToLower() == "completed"
                        ? 1
                        : 0)
                .ThenBy(t => t.TaskTime)
                .ToListAsync();

            ViewBag.todaysTasksCount = todaysTasks.Count;

            ViewBag.nextSevenDaysTasks = await query
                .Where(t =>
                    t.TaskDate > today &&
                    t.Status == "pending" &&
                    t.TaskDate <= sevenDaysLater)
                .OrderBy(t => t.TaskDate)
                .ThenBy(t => t.TaskTime)
                .ToListAsync();

            return View(todaysTasks);
        }

        // =========================
        // ADD CATEGORY FROM MAIN
        // =========================

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Main(TblCategory category)
        {
            if (ModelState.IsValid)
            {
                var loginUser = User.FindFirstValue(ClaimTypes.Name);

                if (string.IsNullOrWhiteSpace(loginUser))
                {
                    return RedirectToAction(nameof(login));
                }

                category.User = loginUser;

                _context.TblCategories.Add(category);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Main));
            }

            return View(category);
        }

        // =========================
        // REGISTER
        // =========================

        [HttpGet]
        public IActionResult register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> register(TblUser user)
        {
            if (await _context.TblUsers
                .AnyAsync(e => e.UserEmail == user.UserEmail))
            {
                ViewBag.emailError =
                    "This email is already registered, please use another email or login.";

                return View(user);
            }

            if (user.UserPassword != user.ConfirmPassword)
            {
                ViewBag.errorPassword =
                    "Please use the same password in both inputs.";

                return View(user);
            }

            _context.TblUsers.Add(user);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Choice));
        }

        // =========================
        // CHOICE
        // =========================

        [HttpGet]
        public IActionResult Choice()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Choice(string usageType)
        {
            if (string.IsNullOrWhiteSpace(usageType))
            {
                ViewBag.Error = "Please select an option.";

                return View();
            }

            HttpContext.Session.SetString("UsageType", usageType);

            return RedirectToAction(nameof(Main));
        }

        // =========================
        // NEW TASK
        // =========================

        [Authorize]
        [HttpGet]
        public IActionResult NewTask()
        {
            var loginUser = User.FindFirstValue(ClaimTypes.Name);

            if (string.IsNullOrWhiteSpace(loginUser))
            {
                return RedirectToAction(nameof(login));
            }

            ViewBag.Categories = new SelectList(
                _context.TblCategories
                    .Where(c => c.User == loginUser || c.User == null),
                "CategoryId",
                "CategoryName");

            ViewBag.TaskUser = loginUser;

            return View(new TblTask());
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> NewTask(TblTask task)
        {
            var loginUser = User.FindFirstValue(ClaimTypes.Name);

            if (string.IsNullOrWhiteSpace(loginUser))
            {
                return RedirectToAction(nameof(login));
            }

            ViewBag.Categories = new SelectList(
                _context.TblCategories
                    .Where(c => c.User == loginUser || c.User == null),
                "CategoryId",
                "CategoryName");

            ViewBag.TaskUser = loginUser;

            if (task.TaskCategory == null)
            {
                var defaultCategory = await _context.TblCategories
                    .FirstOrDefaultAsync(c => c.User == null);

                if (defaultCategory != null)
                {
                    task.TaskCategory = defaultCategory.CategoryId;
                }
            }

            // FIXED: Priority was being checked incorrectly
            if (string.IsNullOrWhiteSpace(task.Priority))
            {
                task.Priority = "p2";
            }

            if (task.TaskDate < DateOnly.FromDateTime(DateTime.Today))
            {
                TempData["invalidTask"] =
                    "Date must be today or later.";

                return RedirectToAction(nameof(NewTask));
            }

            if (task.TaskDate == DateOnly.FromDateTime(DateTime.Today) &&
                task.TaskTime < TimeOnly.FromDateTime(DateTime.Now))
            {
                TempData["invalidTask"] =
                    "Please select a valid time. This time has already passed.";

                return RedirectToAction(nameof(NewTask));
            }

            if (string.IsNullOrWhiteSpace(task.Status))
            {
                task.Status = "pending";
            }

            task.TaskUser = loginUser;

            _context.TblTasks.Add(task);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Main));
        }

        // =========================
        // CATEGORY
        // =========================

        [Authorize]
        [HttpGet]
        public IActionResult category()
        {
            ViewBag.User = User.FindFirstValue(ClaimTypes.Name);

            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> category(TblCategory category)
        {
            var loginUser = User.FindFirstValue(ClaimTypes.Name);

            if (string.IsNullOrWhiteSpace(loginUser))
            {
                return RedirectToAction(nameof(login));
            }

            ViewBag.User = loginUser;

            category.User = loginUser;

            _context.TblCategories.Add(category);

            await _context.SaveChangesAsync();

            return View();
        }

        // =========================
        // TODAY TASKS
        // =========================

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> todayTasks(
            string status,
            int category)
        {
            var loginUser = User.FindFirstValue(ClaimTypes.Name);

            if (string.IsNullOrWhiteSpace(loginUser))
            {
                return RedirectToAction(nameof(login));
            }

            var query = _context.TblTasks
                .Where(t => t.TaskUser == loginUser);

            var today = DateOnly.FromDateTime(DateTime.Today);

            var todaysTotalTasks = await query
                .Where(t => t.TaskDate == today)
                .OrderBy(t => t.TaskTime)
                .ToListAsync();

            var todaysPendingTasks = await query
                .Where(t =>
                    t.TaskDate == today &&
                    t.Status != null &&
                    t.Status.ToLower() == "pending")
                .ToListAsync();

            var todaysCompletedTasks = await query
                .Where(t =>
                    t.TaskDate == today &&
                    t.Status != null &&
                    t.Status.ToLower() == "completed")
                .ToListAsync();

            ViewBag.SelectedStatus = status;
            ViewBag.SelectedCategory = category;

            if (category != 0)
            {
                todaysTotalTasks = todaysTotalTasks
                    .Where(t => t.TaskCategory == category)
                    .OrderBy(t => t.TaskTime)
                    .ToList();

                todaysPendingTasks = todaysPendingTasks
                    .Where(t => t.TaskCategory == category)
                    .OrderBy(t => t.TaskTime)
                    .ToList();

                todaysCompletedTasks = todaysCompletedTasks
                    .Where(t => t.TaskCategory == category)
                    .OrderBy(t => t.TaskTime)
                    .ToList();
            }

            List<TblTask> tasksToShow;

            if (status == "completed")
            {
                tasksToShow = todaysCompletedTasks;
            }
            else if (status == "all")
            {
                tasksToShow = todaysTotalTasks
                    .OrderBy(t =>
                        (t.Status ?? "").Trim().ToLower() == "completed"
                            ? 1
                            : 0)
                    .ThenBy(t => t.TaskTime)
                    .ToList();
            }
            else
            {
                tasksToShow = todaysPendingTasks;
            }

            ViewBag.categories = await _context.TblCategories
                .Where(c => c.User == loginUser || c.User == null)
                .ToListAsync();

            return View(tasksToShow);
        }

        // =========================
        // FUTURE TASKS
        // =========================

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> futureTasks(
            string status,
            int category)
        {
            var loginUser = User.FindFirstValue(ClaimTypes.Name);

            if (string.IsNullOrWhiteSpace(loginUser))
            {
                return RedirectToAction(nameof(login));
            }

            var query = _context.TblTasks
                .Where(t => t.TaskUser == loginUser);

            var today = DateOnly.FromDateTime(DateTime.Today);

            var weekStart =
                today.AddDays(-(int)today.DayOfWeek + (int)DayOfWeek.Monday);

            var weekEnd = weekStart.AddDays(6);

            var monthStart =
                new DateOnly(today.Year, today.Month, 1);

            var monthEnd = monthStart.AddMonths(1);

            var yearStart =
                new DateOnly(today.Year, 1, 1);

            var yearEnd = yearStart.AddYears(1);

            var futureTasks = await query
                .Where(t =>
                    t.TaskDate > today &&
                    t.Status == "pending")
                .OrderBy(t => t.TaskDate)
                .ThenBy(t => t.TaskTime)
                .ToListAsync();

            // FIXED: tomorrow date comparison
            var tomorrow = today.AddDays(1);

            var tomorrowTasks = await query
                .Where(t =>
                    t.TaskDate == tomorrow &&
                    t.Status == "pending")
                .OrderBy(t => t.TaskTime)
                .ToListAsync();

            var thisWeekTasks = await query
                .Where(t =>
                    t.TaskDate > today &&
                    t.TaskDate <= weekEnd &&
                    t.Status == "pending")
                .OrderBy(t => t.TaskDate)
                .ThenBy(t => t.TaskTime)
                .ToListAsync();

            var thisMonthTasks = await query
                .Where(t =>
                    t.TaskDate > today &&
                    t.TaskDate < monthEnd &&
                    t.Status == "pending")
                .OrderBy(t => t.TaskDate)
                .ThenBy(t => t.TaskTime)
                .ToListAsync();

            var thisYearTasks = await query
                .Where(t =>
                    t.TaskDate > today &&
                    t.TaskDate < yearEnd &&
                    t.Status == "pending")
                .OrderBy(t => t.TaskDate)
                .ThenBy(t => t.TaskTime)
                .ToListAsync();

            ViewBag.SelectedStatus = status ?? "all";
            ViewBag.SelectedCategory = category;

            if (category != 0)
            {
                futureTasks = futureTasks
                    .Where(t => t.TaskCategory == category)
                    .ToList();

                tomorrowTasks = tomorrowTasks
                    .Where(t => t.TaskCategory == category)
                    .ToList();

                thisWeekTasks = thisWeekTasks
                    .Where(t => t.TaskCategory == category)
                    .ToList();

                thisMonthTasks = thisMonthTasks
                    .Where(t => t.TaskCategory == category)
                    .ToList();

                thisYearTasks = thisYearTasks
                    .Where(t => t.TaskCategory == category)
                    .ToList();
            }

            List<TblTask> tasksToShow;

            if (status == "Tomorrow")
            {
                tasksToShow = tomorrowTasks
                    .OrderBy(t => t.TaskTime)
                    .ToList();
            }
            else if (status == "ThisWeek")
            {
                tasksToShow = thisWeekTasks
                    .OrderBy(t => t.TaskDate)
                    .ThenBy(t => t.TaskTime)
                    .ToList();
            }
            else if (status == "ThisMonth")
            {
                tasksToShow = thisMonthTasks
                    .OrderBy(t => t.TaskDate)
                    .ThenBy(t => t.TaskTime)
                    .ToList();
            }
            else if (status == "ThisYear")
            {
                tasksToShow = thisYearTasks
                    .OrderBy(t => t.TaskDate)
                    .ThenBy(t => t.TaskTime)
                    .ToList();
            }
            else
            {
                tasksToShow = futureTasks;
            }

            ViewBag.categories = await _context.TblCategories
                .Where(c => c.User == loginUser || c.User == null)
                .ToListAsync();

            return View(tasksToShow);
        }

        // =========================
        // UPDATE TASK STATUS
        // =========================



        [HttpPost]
        [Authorize]
        public async Task<IActionResult> updateTaskStatusHome(int id)
        {
            var loginUser = User.FindFirstValue(ClaimTypes.Name);

            if (string.IsNullOrWhiteSpace(loginUser))
            {
                return RedirectToAction(nameof(login));
            }

            if (id == 0)
            {
                return RedirectToAction(nameof(Main));
            }

            var task = await _context.TblTasks
                .FirstOrDefaultAsync(t =>
                    t.TaskId == id &&
                    t.TaskUser == loginUser);

            if (task == null)
            {
                return NotFound();
            }

            task.Status = "completed";

            task.CompletedDate =
                task.Status == "completed"
                    ? DateOnly.FromDateTime(DateTime.Today)
                    : null;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Main));
        }










        [HttpPost]
        [Authorize]
        public async Task<IActionResult> updateTaskStatus(int id)
        {
            var loginUser = User.FindFirstValue(ClaimTypes.Name);

            if (string.IsNullOrWhiteSpace(loginUser))
            {
                return RedirectToAction(nameof(login));
            }

            if (id == 0)
            {
                return RedirectToAction(nameof(todayTasks));
            }

            var task = await _context.TblTasks
                .FirstOrDefaultAsync(t =>
                    t.TaskId == id &&
                    t.TaskUser == loginUser);

            if (task == null)
            {
                return NotFound();
            }

            task.Status =
                task.Status == "completed"
                    ? "pending"
                    : "completed";

            task.CompletedDate =
                task.Status == "completed"
                    ? DateOnly.FromDateTime(DateTime.Today)
                    : null;

            await _context.SaveChangesAsync();

            if (task.TaskDate > DateOnly.FromDateTime(DateTime.Today))
            {
                return RedirectToAction(nameof(futureTasks));
            }

            return RedirectToAction(nameof(todayTasks));
        }

        // =========================
        // DELETE TASK
        // =========================

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> deleteTask(
            int id,
            string view)
        {
            var loginUser = User.FindFirstValue(ClaimTypes.Name);

            if (string.IsNullOrWhiteSpace(loginUser))
            {
                return RedirectToAction(nameof(login));
            }

            if (id != 0)
            {
                var task = await _context.TblTasks
                    .FirstOrDefaultAsync(t =>
                        t.TaskId == id &&
                        t.TaskUser == loginUser);

                if (task != null)
                {
                    _context.TblTasks.Remove(task);

                    await _context.SaveChangesAsync();
                }
            }

            if (view == "todayView")
            {
                return RedirectToAction(nameof(todayTasks));
            }

            if (view == "futureView")
            {
                return RedirectToAction(nameof(futureTasks));
            }

            if (view == "completedView")
            {
                return RedirectToAction(nameof(completedTasks));
            }

            if (view == "pendingView")
            {
                return RedirectToAction(nameof(PendingTasks));
            }

            return RedirectToAction(nameof(Main));
        }

        // =========================
        // EDIT TASK - GET
        // =========================

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> editTask(
            int id,
            string view)
        {
            var loginUser = User.FindFirstValue(ClaimTypes.Name);

            if (string.IsNullOrWhiteSpace(loginUser))
            {
                return RedirectToAction(nameof(login));
            }

            var task = await _context.TblTasks
                .FirstOrDefaultAsync(t =>
                    t.TaskId == id &&
                    t.TaskUser == loginUser);

            if (task == null)
            {
                return NotFound();
            }

            ViewBag.Categories = new SelectList(
                _context.TblCategories
                    .Where(c => c.User == loginUser || c.User == null),
                "CategoryId",
                "CategoryName",
                task.TaskCategory);

            ViewBag.TaskUser = loginUser;
            ViewBag.viewName = view;

            return View(task);
        }

        // =========================
        // EDIT TASK - POST
        // =========================

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> editTask(
            TblTask task,
            string view)
        {
            var loginUser = User.FindFirstValue(ClaimTypes.Name);

            if (string.IsNullOrWhiteSpace(loginUser))
            {
                return RedirectToAction(nameof(login));
            }

            var existingTask = await _context.TblTasks
                .FirstOrDefaultAsync(t =>
                    t.TaskId == task.TaskId &&
                    t.TaskUser == loginUser);

            if (existingTask == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                existingTask.TaskTitle = task.TaskTitle;
                existingTask.TaskDiscription = task.TaskDiscription;
                existingTask.TaskCategory = task.TaskCategory;
                existingTask.TaskDate = task.TaskDate;
                existingTask.TaskTime = task.TaskTime;
                existingTask.Priority = task.Priority;
                existingTask.Status = task.Status;

                if (existingTask.Status == "pending")
                {
                    existingTask.CompletedDate = null;

                    if (existingTask.TaskDate <
                        DateOnly.FromDateTime(DateTime.Today))
                    {
                        view = "pendingView";
                    }
                    else if (existingTask.TaskDate ==
                             DateOnly.FromDateTime(DateTime.Today))
                    {
                        view = "todayView";
                    }
                    else
                    {
                        view = "futureView";
                    }
                }
                else if (existingTask.Status == "completed")
                {
                    if (existingTask.CompletedDate == null)
                    {
                        existingTask.CompletedDate =
                            DateOnly.FromDateTime(DateTime.Today);
                    }

                    if (existingTask.TaskDate ==
                        DateOnly.FromDateTime(DateTime.Today))
                    {
                        view = "todayView";
                    }
                    else
                    {
                        view = "completedView";
                    }
                }

                await _context.SaveChangesAsync();

                if (view == "futureView")
                {
                    return RedirectToAction(nameof(futureTasks));
                }

                if (view == "todayView")
                {
                    return RedirectToAction(nameof(todayTasks));
                }

                if (view == "pendingView")
                {
                    return RedirectToAction(nameof(PendingTasks));
                }

                return RedirectToAction(nameof(completedTasks));
            }

            ViewBag.Categories = new SelectList(
                _context.TblCategories
                    .Where(c => c.User == loginUser || c.User == null),
                "CategoryId",
                "CategoryName",
                task.TaskCategory);

            ViewBag.TaskUser = loginUser;
            ViewBag.viewName = view;

            return View(task);
        }

        // =========================
        // COMPLETED TASKS
        // =========================

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> completedTasks(
            int id,
            DateOnly? date)
        {
            var loginUser = User.FindFirstValue(ClaimTypes.Name);

            if (string.IsNullOrWhiteSpace(loginUser))
            {
                return RedirectToAction(nameof(login));
            }

            var categories = await _context.TblCategories
                .Where(c => c.User == loginUser || c.User == null)
                .ToListAsync();

            ViewBag.categories = categories;

            var completedTasks = await _context.TblTasks
                .Where(t =>
                    t.Status == "completed" &&
                    t.TaskUser == loginUser)
                .ToListAsync();

            ViewBag.SelectedCategory = id;
            ViewBag.SelectedDate =
                date?.ToString("yyyy-MM-dd");

            if (date.HasValue)
            {
                completedTasks = completedTasks
                    .Where(t => t.CompletedDate == date)
                    .ToList();
            }

            if (id != 0)
            {
                completedTasks = completedTasks
                    .Where(t => t.TaskCategory == id)
                    .ToList();
            }

            ViewBag.completedTasks = completedTasks.Count;

            return View(completedTasks);
        }

        // =========================
        // PENDING TASKS
        // =========================

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> PendingTasks(
            int id,
            DateOnly? date)
        {
            var loginUser = User.FindFirstValue(ClaimTypes.Name);

            if (string.IsNullOrWhiteSpace(loginUser))
            {
                return RedirectToAction(nameof(login));
            }

            var categories = await _context.TblCategories
                .Where(c => c.User == loginUser || c.User == null)
                .ToListAsync();

            ViewBag.categories = categories;

            var today =
                DateOnly.FromDateTime(DateTime.Today);

            var pendingTasks = await _context.TblTasks
                .Where(t =>
                    t.Status == "pending" &&
                    t.TaskDate < today &&
                    t.TaskUser == loginUser)
                .ToListAsync();

            ViewBag.SelectedCategory = id;
            ViewBag.SelectedDate =
                date?.ToString("yyyy-MM-dd");

            if (date.HasValue)
            {
                pendingTasks = pendingTasks
                    .Where(t => t.TaskDate == date)
                    .ToList();
            }

            if (id != 0)
            {
                pendingTasks = pendingTasks
                    .Where(t => t.TaskCategory == id)
                    .ToList();
            }

            ViewBag.pendingTasks = pendingTasks.Count;

            return View(pendingTasks);
        }

        // =========================
        // PRIVACY
        // =========================

        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        // =========================
        // ERROR
        // =========================

        [ResponseCache(
            Duration = 0,
            Location = ResponseCacheLocation.None,
            NoStore = true)]
        public IActionResult Error()
        {
            return View(
                new ErrorViewModel
                {
                    RequestId =
                        Activity.Current?.Id ??
                        HttpContext.TraceIdentifier
                });
        }
    }
}