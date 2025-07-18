import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { FounderServiceService } from '../service-proxies/api/founderService.service';
import { EmployeeDto } from '../service-proxies/model/employeeDto';
import { LeaveRequestsDto } from '../service-proxies/model/leaveRequestsDto';
import { LeaveTypesDto } from '../service-proxies/model/leaveTypesDto';

@Injectable({
  providedIn: 'root'
})
export class FounderDataService {
  constructor(private founderApi: FounderServiceService) {}

  getAllEmployees(): Observable<EmployeeDto[]> {
    return this.founderApi.apiServicesAppFounderServiceGetAllEmployeesGet();
  }

  getAllLeaveRequests(): Observable<LeaveRequestsDto[]> {
    return this.founderApi.apiServicesAppFounderServiceGetAllLeaveRequestsGet();
  }

  getAllLeaveTypes(): Observable<LeaveTypesDto[]> {
    return this.founderApi.apiServicesAppFounderServiceGetAllLeaveTypesGet();
  }

  approveOrRejectLeave(requestId: string, approve: boolean): Observable<LeaveRequestsDto> {
    return this.founderApi.apiServicesAppFounderServiceApproveOrRejectLeaveRequestPost(requestId, approve);
  }
}

