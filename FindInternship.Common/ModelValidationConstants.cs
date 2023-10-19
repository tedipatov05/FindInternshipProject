using System;
using System.Collections.Generic;
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

            public const int CityMaxLength = 169;
            public const int CityMinLength = 1;

            public const int CountryMaxLength = 56;
            public const int CountryMinLength = 4;

            
        }

        public static class RequestConstants
        {
            public const int RequestTopicMaxLength = 50;
            public const int RequestTopicMinLength = 10;

            public const int RequestMessageMaxLength = 2000;
        }

        public static class GroupConstants
        {
            public const int GroupNameMaxLength = 100;
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
            public const int ContentMaxLength = 300;
            public const int ContentMinLength = 1;

            public const int ReceiverUserNameMaxLength = 50;
            public const int ReceiverUserNameMinLength = 2;


        }
        public static class ChatImageConstants
        {
            public const int ChatImageNameMaxLength = 20;
            public const int ChatImageNameMinLength = 4;
        }

        public static class MeetingConstants
        {
            public const int MeetingAddressMaxLength = 100;
            public const int MeetingAddressMinlength = 10;

            public const int MeetingTitleMaxLength = 50;
            public const int MeetingTitleMinLength = 4;
        }

        
    }
}
