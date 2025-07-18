import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ManagerServiceService } from '../service-proxies/api/managerService.service';
import { LeaveRequestsDto } from '../service-proxies/model/leaveRequestsDto';

@Injectable({
  providedIn: 'root'
})
export class ManagerDataService {
  constructor(private managerApi: ManagerServiceService) {}

  getAllLeaveRequests(): Observable<LeaveRequestsDto[]> {
    return this.managerApi.apiServicesAppManagerServiceGetAllLeaveRequestsGet();
  }

  approveOrRejectLeave(requestId: string, approve: boolean): Observable<LeaveRequestsDto> {
    return this.managerApi.apiServicesAppManagerServiceApproveOrRejectLeaveRequestPost(requestId, approve);
  }
  
}

