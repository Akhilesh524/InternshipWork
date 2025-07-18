import { Component, OnInit } from '@angular/core';
import { FounderDataService } from '../services/founder-data.service';
import { EmployeeDto } from '../service-proxies/model/employeeDto';
import { LeaveRequestsDto } from '../service-proxies/model/leaveRequestsDto';
import { LeaveTypesDto } from '../service-proxies/model/leaveTypesDto';

@Component({
  selector: 'app-founder',
  templateUrl: './founder.component.html'
})
export class FounderComponent implements OnInit {
  employees: EmployeeDto[] = [];
  leaveRequests: LeaveRequestsDto[] = [];
  leaveTypes: LeaveTypesDto[] = [];

  constructor(private founderService: FounderDataService) {}

  ngOnInit(): void {
    this.loadEmployees();
    this.loadLeaveRequests();
    this.loadLeaveTypes();
  }

  loadEmployees(): void {
    this.founderService.getAllEmployees().subscribe({
      next: (res: any) => {
        this.employees = res.result ?? res;
        console.log('👥 Employees:', this.employees);
      },
      error: (err) => {
        console.error('❌ Error loading employees:', err);
      }
    });
  }

  loadLeaveRequests(): void {
    this.founderService.getAllLeaveRequests().subscribe({
      next: (res: any) => {
        this.leaveRequests = res.result ?? res;
        console.log('📝 Leave Requests:', this.leaveRequests);
      },
      error: (err) => {
        console.error('❌ Error loading leave requests:', err);
      }
    });
  }

  loadLeaveTypes(): void {
    this.founderService.getAllLeaveTypes().subscribe({
      next: (res: any) => {
        this.leaveTypes = res.result ?? res;
        console.log('📄 Leave Types:', this.leaveTypes);
      },
      error: (err) => {
        console.error('❌ Error loading leave types:', err);
      }
    });
  }
}






