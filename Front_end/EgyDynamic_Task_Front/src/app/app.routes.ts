import { Routes } from '@angular/router';
import { CustomerComponent } from './Pages/customer/customer.component';
import { EditCustomerComponent } from './Pages/edit-customer/edit-customer.component';
import { EmployeeLoginComponent } from './Pages/employee-login/employee-login.component';
import { AddCustomerComponent } from './Pages/add-customer/add-customer.component';
import { noNavigateToLoginPageIfTokenGuard } from './_Guard/no-navigate-to-login-page-if-token.guard';
import { noNavigateWithoutLoginGuard } from './_Guard/no-navigate-without-login.guard';

export const routes: Routes = [
    {path:"edit/Customer",component:EditCustomerComponent,title:"Edit Customer", canActivate: [noNavigateWithoutLoginGuard]},
    {path:"add/Customer",component:AddCustomerComponent,title:"Add Customer", canActivate: [noNavigateWithoutLoginGuard]},
    {path:"CustomerList",component:CustomerComponent,title:"Customer", canActivate: [noNavigateWithoutLoginGuard]},
    {path:"", component:EmployeeLoginComponent, title:"Login", canActivate: [noNavigateToLoginPageIfTokenGuard]}
];
