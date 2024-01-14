using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudinaryDotNet;
using FindInternship.Core.Contracts;
using FindInternship.Core.Hubs;
using FindInternship.Core.Models.PrivateChat;
using FindInternship.Data.Models;
using FindInternship.Data.Repository;
using Ganss.Xss;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using static FindInternship.Common.ApplicationConstants;

namespace FindInternship.Core.Services
{
    public class PrivateChatService : IPrivateChatService
    {
        private Dictionary<string, string> iconsFiles = new Dictionary<string, string>()
        {
            {"PDF", "bi bi-file-pdf-fill"},
            {"PNG", "bi bi-file-earmark-image"},
            {"JPG", "bi bi-file-earmark-image"},
            {"JPEG", "bi bi-file-earmark-image"},
            {"ZIP", "bi bi-file-zip"},
            {"RAR", "bi bi-file-zip"},
            {"DOCX", "bi bi-file-earmark-fill"},
            {"DOC", "bi bi-file-earmark-fill"},
            {"PPT", "bi bi-filetype-ppt"},
            {"TXT", "bi bi-file-text"},
            {"TEXT", "bi bi-file-text"},
            {"XLS", "bi bi-filetype-xls"},
            {"XLSX", "bi bi-filetype-xlsx"},
        };


        private readonly IRepository repo;
        private readonly IHubContext<PrivateChatHub> hubContext;
        private readonly Cloudinary cloudinary;
        private readonly IImageService imageService;
        private readonly IDocumentService documentService;

        public PrivateChatService(IRepository repo, IHubContext<PrivateChatHub> hubContext, Cloudinary cloudinary, IImageService imageService, IDocumentService documentService)
        {
            this.repo = repo;
            this.hubContext = hubContext;
            this.cloudinary = cloudinary;
            this.imageService = imageService;
            this.documentService = documentService;

        }

        public async Task<List<UsersToChatViewModel>> GetUsersToChatAsync(string classId, string currentUserId)
        {
            var currentUser = await repo.All<User>()
                .Include(u => u.ChatMessages)
                .FirstOrDefaultAsync(u => u.Id == currentUserId);

            Func<string, List<ChatMessage>> predicate = (username) => currentUser.ChatMessages.Where(m =>
                m.UserId == currentUserId && m.ReceiverUsername == username).ToList();

            var users = repo.All<Student>()
                .Include(s => s.User)
                .Include(s => s.User.ChatMessages)
                .AsEnumerable()
                .Where(s => s.ClassId == classId && s.User.IsActive && s.UserId != currentUserId)
                .Select(s => new UsersToChatViewModel()
                {
                    UserId = s.UserId,
                    Name = s.User.UserName,
                    ProfilePicture = s.User.ProfilePictureUrl,
                    LastMessageToUser = s.User.ChatMessages
                        .Where(c => c.UserId == s.UserId && c.ReceiverUsername == currentUser.UserName)
                        .Union(predicate(s.User.UserName))
                        .OrderBy(m => m.SendedOn)
                        .LastOrDefault()


                })
                .ToList();

            return users;


        }


        public async Task<UsersToChatViewModel> GetTeacherToChatAsync(string classId, string currentUserId)
        {

            var currentUser = await repo.All<User>()
                .Include(u => u.ChatMessages)
                .FirstOrDefaultAsync(u => u.Id == currentUserId);

            Func<string, List<ChatMessage>> predicate = (username) => currentUser.ChatMessages.Where(m =>
                m.UserId == currentUserId && m.ReceiverUsername == username).ToList();

            var teacher = repo.All<Teacher>()
                .Include(t => t.User)
                .Where(t => t.ClassId == classId && t.User.IsActive)
                .Include(t => t.User.ChatMessages)
                .AsEnumerable()
                .Select(t => new UsersToChatViewModel()
                {
                    UserId = t.UserId,
                    Name = t.User.UserName,
                    ProfilePicture = t.User.ProfilePictureUrl,
                    LastMessageToUser = t.User.ChatMessages.Where(c => c.UserId == t.UserId && c.ReceiverUsername == currentUser.UserName)
                        .Union(predicate(t.User.UserName))
                        .OrderBy(m => m.SendedOn).LastOrDefault()


                })
                .FirstOrDefault();

            return teacher;

        }

        public async Task<UsersToChatViewModel> GetCompanyToChatAsync(string classId, string currentUserId)
        {
            var currentUser = await repo.All<User>()
                .Include(c => c.ChatMessages)
                .FirstOrDefaultAsync(u => u.Id == currentUserId);

            Func<string, List<ChatMessage>> predicate = (username) => currentUser.ChatMessages.Where(m =>
                m.UserId == currentUserId && m.ReceiverUsername == username).ToList();


            var company = repo.All<Company>()
                .Include(t => t.User)
                .Where(t => t.Classes.Any(c => c.Id == classId) && t.User.IsActive)
                .Include(t => t.User.ChatMessages)
                .AsEnumerable()
                .Select(t => new UsersToChatViewModel()
                {
                    UserId = t.UserId,
                    Name = t.User.UserName,
                    ProfilePicture = t.User.ProfilePictureUrl,
                    LastMessageToUser = t.User.ChatMessages
                        .Where(c => c.UserId == t.UserId && c.ReceiverUsername == currentUser.UserName)
                        .Union(predicate(t.User.UserName))
                        .OrderBy(m => m.SendedOn)
                        .LastOrDefault()
                        
                })
                .FirstOrDefault();

            return company;
        }

        public async Task<ICollection<ChatMessage>> ExtractAllMessagesAsync(string groupName)
        {
            var targetGroup = await repo.All<Group>()
                .FirstOrDefaultAsync(g => g.Name == groupName);

            if (targetGroup != null)
            {
                var messages = await repo.All<ChatMessage>()
                    .Where(ch => ch.GroupId == targetGroup.Id)
                    .Include(m => m.User)
                    .OrderByDescending(ch => ch.SendedOn)
                    .Take(MessageCountPerScroll)
                    .OrderBy(m => m.SendedOn)
                    .ToListAsync();


                return messages;
            }

            return new List<ChatMessage>();
        }

        public async Task<ICollection<LoadMoreMessagesViewModel>> LoadMoreMessagesAsync(string group, int messagesSkipCount, User user)
        {

            var targetGroup = await repo.All<Group>()
                .FirstOrDefaultAsync(g => g.Name.ToLower() == group.ToLower());

            if (targetGroup != null)
            {
                var messages = await repo.All<ChatMessage>()
                    .Where(c => c.GroupId == targetGroup.Id)
                    .OrderByDescending(m => m.SendedOn)
                    .Skip(messagesSkipCount)
                    .Take(MessageCountPerScroll)
                    .Include(m => m.User)
                    .Select(m => new LoadMoreMessagesViewModel()
                    {
                        Id = m.Id,
                        Content = m.Content,
                        CurrentUsername = user.UserName,
                        FromImageUrl = m.User.ProfilePictureUrl,
                        FromUsername = m.User.UserName,
                        SendedOn = m.SendedOn.ToLocalTime().ToString("dd/mm/yyyy hh:mm")
                    })
                    .ToListAsync();

                return messages;
            }

            return new List<LoadMoreMessagesViewModel>();
        }

        public async Task SendMessageToUser(string fromUsername, string toUsername, string message, string group)
        {
            var toUser = await repo.All<User>()
                .FirstOrDefaultAsync(u => u.UserName.ToLower() == toUsername.ToLower() && u.IsActive);

            var fromUser = await repo.All<User>()
                .FirstOrDefaultAsync(u => u.UserName.ToLower() == fromUsername.ToLower() && u.IsActive);

            var targetGroup = await repo.All<Group>()
                .FirstOrDefaultAsync(g => g.Name.ToLower() == group.ToLower());


            var newMessage = new ChatMessage()
            {
                User = fromUser,
                Group = targetGroup,
                SendedOn = DateTime.Now,
                Content = new HtmlSanitizer().Sanitize(message.Trim()),
                ReceiverImageUrl = toUser.ProfilePictureUrl,
                ReceiverUsername = toUser.UserName,

            };

            await repo.AddAsync(newMessage);
            await repo.SaveChangesAsync();

            await hubContext.Clients.User(toUser.Id).SendAsync("ReceiveMessage", fromUsername,
                fromUser.ProfilePictureUrl, new HtmlSanitizer().Sanitize(message.Trim()));


        }

        public async Task ReceiveNewMessage(string fromUsername, string message, string group)
        {
            var fromUser = await repo.All<User>()
                .FirstOrDefaultAsync(u => u.UserName.ToLower() == fromUsername.ToLower());

            string fromId = fromUser.Id;
            string fromUserImage = fromUser.ProfilePictureUrl;


            
            await hubContext.Clients.User(fromId).SendAsync("SendMessage", fromUser.Id, fromUsername, fromUserImage, message.Trim());
        }

        public async Task<bool> SendMessageWitFilesToUser(IList<IFormFile> files, string group, string toUsername, string fromUsername, string message)
        {

            var toUser = await repo.All<User>()
                .FirstOrDefaultAsync(u => u.UserName == toUsername && u.IsActive);
            var toUserId = toUser.Id;

            var fromUser = await repo.All<User>()
                .FirstOrDefaultAsync(u => u.UserName == fromUsername && u.IsActive);
            var fromUserId = fromUser.Id;

            var targetGroup = await repo.All<Group>()
                .FirstOrDefaultAsync(g => g.Name.ToUpper() == group.ToUpper());

            var chatMessage = new ChatMessage()
            {
                User = fromUser,
                Group = targetGroup,
                SendedOn = DateTime.Now,
                ReceiverUsername = toUsername,
                ReceiverImageUrl = toUser.ProfilePictureUrl
            };

            bool result = files.Count > 0;

            StringBuilder messageContent = new StringBuilder();

            if (message != null)
            {
                messageContent.AppendLine($"{new HtmlSanitizer().Sanitize(message.Trim())}<hr style=\"margin-bottom: 8px !important;\" />");
            }

            StringBuilder imagesContent = new StringBuilder();
            StringBuilder filesContent = new StringBuilder();

            List<ChatImage> chatImages = new(); 

            foreach (var file in files)
            {
                var chatFile = new ChatImage()
                {
                    ChatMessageId = chatMessage.Id,
                    GroupId = targetGroup.Id,

                };

                string fileUrl = null;

                if (file.ContentType.Contains("image", StringComparison.CurrentCultureIgnoreCase))
                {
                    fileUrl = await imageService.UploadImageAsync(file, "projectImages", file.Name);

                    chatFile.Name = file.FileName;

                    imagesContent.AppendLine($"<span><img src=\"{fileUrl}\" style=\"margin-right: 10px; width: 90%; height: 90%; margin-top: 5px;\"></span>");

                }
                else
                {
                    var fileExtension = Path.GetExtension(file.Name);

                    fileUrl = await documentService.UploadDocumentAsync(file, "projectDocuments");
                    chatFile.Name = file.FileName;

                    filesContent.AppendLine($"<a href=\"{fileUrl}\">\r\n<span class=\"input-group-text pl-2 pr-2\" style=\"margin-left: 10px;\">\r\n<div style=\"display: flex; flex-direction: row;\">\r\n<i class=\"{iconsFiles[fileExtension.ToUpper()]}\"></i>\r\n<div class=\"pl-1 pt-1 text-dark\" style=\"font-size: small;\">{file.FileName}</div>\r\n\r\n</div>\r\n\r\n      </span>\r\n\r\n</a>");

                    

                }
                chatFile.ImageUrl = fileUrl;
                chatImages.Add(chatFile);
                chatMessage.Images.Add(chatFile);

            }

            


            if (imagesContent.Length == 0)
            {
                messageContent.AppendLine(filesContent.ToString().Trim());
            }
            else
            {
                messageContent.AppendLine(imagesContent.ToString().Trim());

                if (filesContent.Length != 0)
                {
                    messageContent.AppendLine("<hr style=\"margin-bottom: 8px !important;\" />");
                    messageContent.AppendLine(filesContent.ToString().Trim());
                }
            }

            chatMessage.Content = new HtmlSanitizer().Sanitize(messageContent.ToString().Trim());

            await hubContext.Clients.User(toUserId).SendAsync("ReceiveMessage", fromUser.UserName,
                fromUser.ProfilePictureUrl, messageContent.ToString().Trim());

            await this.ReceiveNewMessage(fromUser.UserName, messageContent.ToString().Trim(), group);

            await repo.AddAsync(chatMessage);
            await repo.AddRangeAsync(chatImages);

            await repo.SaveChangesAsync();

            return result;

        }

        public async Task<bool> IsAbleToChatAsync(string userName, string group, User user)
        {
            var targetUser = await repo.All<User>()
                .FirstOrDefaultAsync(u => u.UserName == userName);

            var groupUser = new List<string>() { targetUser.UserName, user.UserName };

            var targetGroup1 = string.Join('-', groupUser);

            groupUser.Reverse();
            var targetGroup2 = string.Join('-', groupUser);

            if (targetGroup1 != group && targetGroup2 != group)
            {
                return false;
            }

            if (user.UserName == targetUser.UserName)
            {
                return false;
            }

            return true;

        }
    }
}
