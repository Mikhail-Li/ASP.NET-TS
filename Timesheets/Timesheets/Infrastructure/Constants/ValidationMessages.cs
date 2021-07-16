using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Infrastructure.Constants
{
    public static class ValidationMessages
    {
        public const string SheetAmount = "Amount should be between 0 and 8 hours.";
        public const string InvalidSheetDate = "Date is invalid";
        public const string InvalidValue = "Incorrect value";
        public const string InvalidUsername = "Username cannot be empty.";
        public const string InvalidPassword = "Password cannot be empty.";
        public const string InvalidPasswordLength = "Password Length is invalid";
        public const string InvalidRole = "Role cannot be empty.";
        public const string InvalidDateStart = "DateStart is invalid.";
        public const string InvalidDateEnd = "DateEnd is invalid.";
        public const string InvalidIsDeleted = "Field IsDeleted must be true or false.";
    }
}
