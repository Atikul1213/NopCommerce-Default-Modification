﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Core.Domain.Employee

{
    public class Employee : BaseEntity
    {
        public string Name { get; set; }
        public string Designation { get; set; }
        public int Age { get; set; }
        public bool IsCertified { get; set; }

        public int PictureId { get; set; }

        public int EmployeeStatusId { get; set; }
        public EmployeeStatus EmployeeStatus 
        { 
            get => (EmployeeStatus)EmployeeStatusId;
            set => EmployeeStatusId=(int) value;
        }

    }

    public enum EmployeeStatus
    {
        Active = 10,
        Inactive = 20,
        Blocked = 30
    };


}
