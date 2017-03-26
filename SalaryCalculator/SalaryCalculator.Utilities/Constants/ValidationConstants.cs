namespace SalaryCalculator.Utilities.Constants
{
    public static class ValidationConstants
    {
        public const int MinimumNameLength = 2;
        public const int MaximumNameLength = 20;
        public const string AllowedNameCharacters = @"[A-Za-z][a-zA-Z]*";

        public const int PersonalIdLength = 10;
        public const string PersonalIdCharacters = @"^[0-9]{10}$";

        public const int MinSocialSecurityIncome = 460;
        public const int MaxSocialSecurityIncome = 2600;

        public const decimal PersonalInsurancePercent = 0.129m;
        public const decimal EmployerInsurancePercent = 0.181m;
        public const decimal IncomeTaxPercent = 0.1m;

        public const decimal MinimumSalaryValue = 1m;
        public const decimal MaximumSalaryValue = 1000000m;

        public const string AdminRole = "Admin";
        public const string UserRole = "user";

        public const int DefaultPageItems = 10;
    }
}
