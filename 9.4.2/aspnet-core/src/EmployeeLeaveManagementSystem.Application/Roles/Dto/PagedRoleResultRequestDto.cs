﻿using Abp.Application.Services.Dto;

namespace EmployeeLeaveManagementSystem.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

