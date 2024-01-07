﻿using FindInternship.Common;
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
        private readonly UserManager<User> userManager;
        

        public PrivateChatController(IPrivateChatService privateChatService, ITeacherService teacherService, ICompanyService companyService, IStudentService studentService, IClassService classService, IUserService userService, UserManager<User> userManager)
        {
            this.privateChatService = privateChatService;
            this.teacherService = teacherService;
            this.companyService = companyService;
            this.studentService = studentService;
            this.classService = classService;
            this.userService = userService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> UsersToChat()
        {
            string userId = User.GetId();
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
                users.Add(studentTeacher);

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
            string userId = User.GetId();
            string toUserId = await userService.GetUserIdByUsernameAsync(toUsername);

            if (toUserId == null)
            {
                TempData[ErrorMessage] = "Непрвилен потребител";
                return RedirectToAction("UsersToChat");
            }

            var model = new PrivateChatViewModel()
            {
                FromUser = await userManager.GetUserAsync(this.HttpContext.User),
                ToUser = await userManager.FindByIdAsync(toUserId),
                ChatMessages = await privateChatService.ExtractAllMessagesAsync(group)

            };

            //var model = new PrivateChatViewModel();

            return View(model);
        }




    }
}