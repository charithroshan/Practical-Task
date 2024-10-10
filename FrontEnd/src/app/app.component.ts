import { Component } from '@angular/core';
import { RouterModule, Routes, RouterOutlet } from '@angular/router';
import { EmployeesListComponent } from './Components/Employees/employees-list/employees-list.component';

const routes: Routes = [
  { path: 'employees', component: EmployeesListComponent }
];

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, RouterModule, EmployeesListComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'FrontEnd';
}
