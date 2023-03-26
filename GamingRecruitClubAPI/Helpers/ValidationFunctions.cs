﻿using GamingRecruitClubAPI.Models;

namespace GamingRecruitClubAPI.Helpers
{
    public class ValidationFunctions
    {
        public static void ExceptionsWhenDateIsNotValid(DateTime? start, DateTime? end)
        {
            if (start.HasValue && end.HasValue && start > end)
            {
                throw new ModelValidationException(Helpers.ErrorMessagesEnum.StartEndDatesError);
            }
        }
    }
}
