﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInternship.Common
{
    public static class ModelValidationConstants
    {
        public static class UserConstants
        {
            public const int UserNameMaxLength = 50;
            public const int UserNameMinLength = 2;

            public const int EmailMaxLength = 50;
            public const int EmailMinLength = 8;


            public const int AddressMaxLength = 100;
            public const int AddressMinLength = 5;

            public const int PasswordMinLength = 3;
            public const int PasswordMaxLength = 16;

            public const int CityMaxLength = 160;
            public const int CityMinLength = 2;

            public const int CountryMaxLength = 56;
            public const int CountryMinLength = 2;

            public const int SchoolNameMinLength = 5;
            public const int SchoolNameMaxLength = 50;

            public const int SpecialityMinLength = 3;
            public const int SpecialityMaxLength = 50;

            
        }

        public static class RequestConstants
        {
            public const int RequestTopicMaxLength = 50;
            public const int RequestTopicMinLength = 5;

            public const int RequestMessageMaxLength = 2000;
            public const int RequestMessageMinLength = 10;

        }

        public static class GroupConstants
        {
            public const int GroupNameMaxLength = 100;
        }

        public static class RoomConstants
        {
            public const int RoomNameMaxLength = 50;
        }

        public static class CompanyConstants
        {
            public const int CompanyDescriptionMaxLength = 2000;
            public const int CompanyDescriptionMinLength = 20;

            public const int CompanyServicesMaxLength = 300;
            public const int CompanyServicesMinLength = 20;


        }

        public static class ClassConstants
        {
            public const int SpecialtityMaxLength = 50;
            public const int SpecialtityMinLength = 10;

            public const int SchoolMaxLength = 100;
            public const int SchoolMinLength = 10;
        }

        public static class ChatMessageConstants
        {
            public const int ContentMaxLength = 2000;
            public const int ContentMinLength = 1;

            public const int ReceiverUserNameMaxLength = 50;
            public const int ReceiverUserNameMinLength = 2;


        }
        public static class ChatImageConstants
        {
            public const int ChatImageNameMaxLength = 100;
            public const int ChatImageNameMinLength = 4;
        }

        public static class MeetingConstants
        {
            public const int MeetingAddressMaxLength = 100;
            public const int MeetingAddressMinlength = 10;

            public const int MeetingTitleMaxLength = 50;
            public const int MeetingTitleMinLength = 4;

            public const int MeetingDescriptionMaxLength = 1000;
            public const int MeetingDescriptionMinLength = 5;
        }

        public static class MeetingMaterialConstants
        {
            public const int MaterialNameMaxLength = 50;
            public const int MaterialNameMinLength = 4;
        }

        public static class LectorConstants
        {
            public const int NameMaxLength = 100;
            public const int NameMinLength = 3;

            public const int DescriptionMaxLength = 400;
            public const int DescriptionMinLength = 4;

           
        }
        public static class CompanyInternsConstants
        {
            public const int NameMaxLength = 100;
            public const int NameMinLength = 3;
        }

        public static class PostConstants
        {
            public const int PostTopicMaxLength = 100;
            public const int PostTopicMinLength = 3;

            public const int PostContentMaxLength = 10000;
            public const int PostContentMinLength = 4;
        }

        public static class RoomMessageConstants
        {
            public const int RoomMessageMaxLength = 2000;
            public const int RoomMessageMinLength = 1;
        }

        
    }
}
