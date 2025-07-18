import { Injectable } from '@angular/core';
import { EmployeeServicesService } from '../service-proxies/api/employeeServices.service';
import { EmployeeDto } from '../service-proxies/model/employeeDto';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmployeeDataService {
  constructor(private employeeApi: EmployeeServicesService) {}

  getAll(): Observable<EmployeeDto[]> {
    return this.employeeApi.apiServicesAppEmployeeServicesGetAllEmployeeGet();
  }

  getById(id: string): Observable<EmployeeDto> {
    return this.employeeApi.apiServicesAppEmployeeServicesGetEmployeeByIdGet(id);
  }

  create(employee: EmployeeDto): Observable<EmployeeDto> {
    return this.employeeApi.apiServicesAppEmployeeServicesCreateEmployeePost(employee);
  }

  update(id: string, employee: EmployeeDto): Observable<EmployeeDto> {
    return this.employeeApi.apiServicesAppEmployeeServicesUpdateEmployeeByIdPut(id, employee);
  }

  delete(id: string): Observable<any> {
    return this.employeeApi.apiServicesAppEmployeeServicesDeleteEmployeeByIdDelete(id);
  }
}

