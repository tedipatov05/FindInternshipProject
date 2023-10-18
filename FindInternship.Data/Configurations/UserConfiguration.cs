﻿using FindInternship.Data.Models;
using FindInternship.Data.Models.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(GetUsers());
        }

        private List<User> GetUsers()
        {
            var users = new List<User>();
            var passwordHasher = new PasswordHasher<User>();

            var user = new User()
            {
                Id = "080a469a-b5a2-44cc-a660-eea8e6fd05a5",
                UserName = "petar",
                NormalizedUserName = "PETAR",
                Email = "petarpetrov@abv.bg",
                NormalizedEmail = "PETARPETROV@ABV.BG",
                PhoneNumber = "0885763826",
                Name = "Петър Петров",
                City = "Казанлък",
                Country = "България",
                Address = "ул. Ал. Стамболийски 30 ет.3 ап.11",
                Gender = Gender.Мъж.ToString(),
                RegisteredOn = DateTime.UtcNow,
                BirthDate = DateTime.ParseExact("2008-04-12 13:24", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                ProfilePictureUrl = "https://res.cloudinary.com/ddriqreo7/image/upload/v1697607303/projectImages/xbhwflepot9qpwmiiq6u.jpg"
            };

            user.PasswordHash = passwordHasher.HashPassword(user, "1234567");
            users.Add(user);


            var user2 = new User()
            {
                Id = "93418f37-da3b-4c78-b0ae-8f0022b09681",
                UserName = "georgi",
                NormalizedUserName = "ZDRAVKA",
                Email = "georgidimitov@abv.bg",
                NormalizedEmail = "GEORGIDIMITROV@ABV.BG",
                PhoneNumber = "0885789826",
                Name = "Георги Димитров",
                City = "Казанлък",
                Country = "България",
                Address = "ул.Възраждане 6 ет.2 ап.8",
                Gender = Gender.Мъж.ToString(),
                RegisteredOn = DateTime.UtcNow,
                BirthDate = DateTime.ParseExact("1968-02-8 11:20", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                ProfilePictureUrl = "https://res.cloudinary.com/ddriqreo7/image/upload/v1697608565/projectImages/mvorrsshjbw1e8bzfzgq.jpg"
            };

            user2.PasswordHash = passwordHasher.HashPassword(user2, "3456789");
            users.Add(user2);

            var user3 = new User()
            {
                Id = "cb5ee792-90f6-4e50-8af1-da2f99d9f892",
                UserName = "NewTechies",
                NormalizedUserName = "NEWTECHIES",
                Email = "newtechies@abv.bg",
                NormalizedEmail = "NEWTECHIES@ABV.BG",
                PhoneNumber = "0885789546",
                Name = "New Techies",
                City = "Казанлък",
                Country = "България",
                Address = "ул. Стара планина 63",
                Gender = null,
                RegisteredOn = DateTime.UtcNow,
                BirthDate = DateTime.ParseExact("20015-02-8 11:20", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                ProfilePictureUrl = "https://res.cloudinary.com/ddriqreo7/image/upload/v1697608565/projectImages/mvorrsshjbw1e8bzfzgq.jpg"
            };

            user3.PasswordHash = passwordHasher.HashPassword(user3, "techies123");
            users.Add(user3);

            return users;


        }
    }
}
