import { Component, OnInit} from '@angular/core';
import { Employee } from '../../../models/employee.model';
import { CommonModule } from '@angular/common';
import { EmployeesService } from '../../../Services/employees.service';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-employees-list',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './employees-list.component.html',
  styleUrl: './employees-list.component.css'
})
export class EmployeesListComponent implements OnInit {
  employees: Employee[] = [];
  constructor(private employeeService: EmployeesService) {}

  ngOnInit(): void {
    this.employeeService.getAllEmployees().subscribe({
      next: (employees) => {
        this.employees = employees;
      },
      error: (Response) => {
        console.log(Response);
      }
    })
  }

}
