using FindInternship.Common;
using FindInternship.Core.Contracts;
using FindInternship.Core.Models.PrivateChat;
using FindInternship.Data.Models;
using FindInternship.Web.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static FindInternship.Common.NotificationConstants;

namespace FindInternship.Web.Controllers
{

    public class PrivateChatController : Controller
    {
        private readonly IPrivateChatService privateChatService;
        private readonly ITeacherService teacherService;
        private readonly ICompanyService companyService;
        private readonly IStudentService studentService;
        private readonly IClassService classService;
        private readonly IUserService userService;
        private readonly IGroupService groupService;
        private readonly UserManager<User> userManager;
        

        public PrivateChatController(IPrivateChatService privateChatService, ITeacherService teacherService, ICompanyService companyService, IStudentService studentService, IClassService classService, IUserService userService, UserManager<User> userManager, IGroupService groupService)
        {
            this.privateChatService = privateChatService;
            this.teacherService = teacherService;
            this.companyService = companyService;
            this.studentService = studentService;
            this.classService = classService;
            this.userService = userService;
            this.userManager = userManager;
            this.groupService = groupService;
        }

        public async Task<IActionResult> UsersToChat()
        {
            string userId = User.GetId()!;
            bool isCompany = await companyService.IsCompanyAsync(userId);
            bool isTeacher = await teacherService.IsTeacherAsync(userId);
            bool isStudent = await studentService.IsStudent(userId);
            if (isCompany)
            {
                var classIds = await classService.GetClassIdsByCompanyUserIdAsync(userId);
                List<UsersToChatViewModel> usersToChat = new();
                if (classIds.Count() > 0)
                {
                    foreach (var id in classIds)
                    {
                        var users = await privateChatService.GetUsersToChatAsync(id, userId);
                        var teacher = await privateChatService.GetTeacherToChatAsync(id, userId);
                        users.Add(teacher);
                        usersToChat.AddRange(users);
                    }
                } 
                
                return View(usersToChat);

            }
            else if (isTeacher)
            {
                string classId = await classService.GetClassIdByTeacherUserIdAsync(userId);
                var users = await privateChatService.GetUsersToChatAsync(classId, userId);
                var company = await privateChatService.GetCompanyToChatAsync(classId, userId);
                users.Add(company);

                return View(users);
            }
            else if (isStudent)
            {
                string classId = await classService.GetClassIdByStudentUserIdAsync(userId);
                var users = await privateChatService.GetUsersToChatAsync(classId, userId);
                var studentTeacher = await privateChatService.GetTeacherToChatAsync(classId, userId);
                var company = await privateChatService.GetCompanyToChatAsync(classId, userId);
                users.Add(studentTeacher);
                if(company != null)
                {
                    users.Add(company);
                }

                return View(users);

            }
            else
            {
                TempData[ErrorMessage] = "Неправилен потребител";
                return RedirectToAction("Index", "Home");
            }

        }

        public async Task<IActionResult> Chat(string toUsername, string group)
        {
            string userId = User.GetId()!;
            var toUserId = await userService.GetUserIdByUsernameAsync(toUsername);

            if (toUserId == null)
            {
                TempData[ErrorMessage] = "Непрвилен потребител";
                return RedirectToAction("UsersToChat");
            }

            var groupId = await groupService.GetGroupBetweenUsersAsync(userId, toUserId);
            string? groupName = await groupService.GetGroupNameByIdAsync(groupId);

            var messages = await privateChatService.ExtractAllMessagesAsync(groupName == null ? group : groupName);


            var model = new PrivateChatViewModel()
            {
                FromUser = await userManager.GetUserAsync(this.HttpContext.User),
                ToUser = await userManager.FindByIdAsync(toUserId),
                ChatMessages = messages , 
                Group = groupName == null ? group : groupName,

            };

            return View(model);
        }

        [HttpPost]
        [Route("/PrivateChat/SendMessageWithFiles")]
        public async Task<IActionResult> SendMessageWithFiles(IList<IFormFile> files, string group, string toUsername,
            string fromUsername, string message)
        {
            var currentUser = await userManager.GetUserAsync(this.User);
            bool isAbleToChat = await privateChatService.IsAbleToChatAsync(toUsername, group, currentUser);

            if (!isAbleToChat)
            {
                TempData[ErrorMessage] = "Потребителя не може да плучава съобщения";
                return RedirectToAction("UsersToChat");
            }


            var haveFiles = await privateChatService.SendMessageWitFilesToUser(files, group, toUsername, fromUsername, message);


            return new JsonResult(new {haveFiles});
        }

        [HttpGet]
        [Route("/PrivateChat/LoadMoreMessages")]
        public async Task<IActionResult> LoadMoreMessages(string username, string group, int? messagesSkipCount)
        {
            var currentUser = await this.userManager.GetUserAsync(this.User);
            bool isAbleToChat = await privateChatService.IsAbleToChatAsync(username, group, currentUser);

            if (!isAbleToChat)
            {
                TempData[ErrorMessage] = "Потребителя не може да плучава съобщения";
                return RedirectToAction("UsersToChat");
            }

            if (messagesSkipCount == null)
            {
                messagesSkipCount = 0;
            }

            ICollection<LoadMoreMessagesViewModel> data = 
                await privateChatService.LoadMoreMessagesAsync(group, (int)messagesSkipCount, currentUser);


            return new JsonResult(data);
        }



    }
}
