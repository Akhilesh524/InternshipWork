import { Component, OnInit } from '@angular/core';
import { ManagerDataService } from '../services/manager-data.service';
import { LeaveRequestsDto } from '../service-proxies/model/leaveRequestsDto';

@Component({
  selector: 'app-manager',
  templateUrl: './manager.component.html',
})
export class ManagerComponent implements OnInit {
  leaveRequests: LeaveRequestsDto[] = [];

  constructor(private managerService: ManagerDataService) {}

  ngOnInit(): void {
    this.loadLeaveRequests();
  }

  loadLeaveRequests(): void {
    this.managerService.getAllLeaveRequests().subscribe({
      next: (res: any) => {
        this.leaveRequests = res.result ?? res;
        console.log('📝 Manager Leave Requests:', this.leaveRequests);
      },
      error: (err) => {
        console.error('❌ Failed to fetch leave requests:', err);
      }
    });
  }

  approve(requestId: string): void {
    this.managerService.approveOrRejectLeave(requestId, true).subscribe(() => {
      this.loadLeaveRequests();
    });
  }

  reject(requestId: string): void {
    this.managerService.approveOrRejectLeave(requestId, false).subscribe(() => {
      this.loadLeaveRequests();
    });
  }
}
