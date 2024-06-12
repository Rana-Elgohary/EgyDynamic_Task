import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Customer } from '../../_Model/customer';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CustomerServiceService } from '../../_Services/customer-service.service';
import { AccountServiceService } from '../../_Services/account-service.service';

@Component({
  selector: 'app-edit-customer',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './edit-customer.component.html',
  styleUrl: './edit-customer.component.css'
})
export class EditCustomerComponent {
  customer: Customer | undefined;

  constructor(private router: Router, private customerService: CustomerServiceService, private account:AccountServiceService ) { 
    const navigation = this.router.getCurrentNavigation();
    if (navigation?.extras?.state) {
      this.customer = navigation.extras.state['customer'];
    }
  }

  editCustomer() {
    if(this.customer != undefined){
      this.customer["اخر_تعديل_في"] = new Date()
      this.customer["اخر_تعديل"] = +this.account.r.id
      this.customerService.getCustomerById(this.customer["كود_العميل"]).subscribe(
        resp => {
          if(this.customer != undefined){
            this.customer["ادخال_بواسطة"] = resp["ادخال_بواسطة"]
          
            this.customerService.editCustomer(this.customer).subscribe(
              response => {
                this.router.navigate(['/CustomerList']);
              },
              error => {
                console.error('Error updating customer:', error);
              }
            );
          }
        }
      )
    }
  }

  cancle(){
    this.router.navigate(['/CustomerList']);    
  }
}
