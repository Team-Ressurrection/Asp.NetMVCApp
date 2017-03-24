﻿using SalaryCalculator.Configuration.Mappings;
using SalaryCalculator.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalaryCalculatorWeb.Areas.Admin.Models
{
    public class UsersViewModel : IMapFrom<User>
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string CompanyName { get; set; }

        public string CompanyAddress { get; set; }
    }
}