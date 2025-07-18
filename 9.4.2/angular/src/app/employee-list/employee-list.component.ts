// import { Component, OnInit } from '@angular/core';
// import { EmployeeDataService } from '../services/employee-data.service';
// import { EmployeeDto } from '../service-proxies/model/employeeDto';

// @Component({
//   selector: 'app-employee-list',
//   templateUrl: './employee-list.component.html'
// })
// export class EmployeeListComponent implements OnInit {
//   employees: EmployeeDto[] = [];

//   constructor(private employeeService: EmployeeDataService) {}

//   ngOnInit(): void {
//     this.employeeService.getAll().subscribe({
//       next: (res: any) => {
//         // 👇 Check what actual data you receive
//         console.log('✅ API Response:', res);

//         // 👇 If backend wraps response in result
//         this.employees = res.result ?? res;

//         // 👇 Optional: debug it
//         console.log('📦 Employees:', this.employees);
//       },
//       error: (err) => {
//         console.error('❌ Error fetching employees:', err);
//       }
//     });
//   }
// }


import { Component, OnInit } from '@angular/core';
import { EmployeeDataService } from '../services/employee-data.service';
import { EmployeeDto } from '../service-proxies/model/employeeDto';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html'
})
export class EmployeeListComponent implements OnInit {
  employees: EmployeeDto[] = [];

  // Form state
  showCreateForm = false;
  newEmployee: EmployeeDto = {
    firstName: '',
    lastName: '',
    email: ''
    // Add other required fields with default values
  };

  constructor(private employeeService: EmployeeDataService) {}

  ngOnInit(): void {
    this.loadEmployees();
  }

  loadEmployees() {
    this.employeeService.getAll().subscribe({
      next: (res: any) => {
        this.employees = res.result ?? res;
      },
      error: (err) => console.error('❌ Error fetching employees:', err)
    });
  }

  openCreateForm() {
    this.showCreateForm = true;
  }

  closeCreateForm() {
    this.showCreateForm = false;
    this.newEmployee = {
      firstName: '',
      lastName: '',
      email: ''
    };
  }

  createEmployee() {
    this.employeeService.create(this.newEmployee).subscribe({
      next: () => {
        alert('✅ Employee created!');
        this.closeCreateForm();
        this.loadEmployees(); // Refresh list
      },
      error: (err) => {
        console.error('❌ Error creating employee:', err);
        alert('Failed to create employee.');
      }
    });
  }
}





