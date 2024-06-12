import { Component } from '@angular/core';
import { AccountServiceService } from '../../_Services/account-service.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-employee-login',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './employee-login.component.html',
  styleUrl: './employee-login.component.css'
})
export class EmployeeLoginComponent {
  name:string = ""
  password:string = ""

  constructor(public accountService:AccountServiceService){  }

  Login(){
    this.accountService.Login(this.name, this.password)
  }
}
