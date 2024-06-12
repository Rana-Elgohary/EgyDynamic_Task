import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CustomerServiceService } from '../../_Services/customer-service.service';
import { AccountServiceService } from '../../_Services/account-service.service';
import { CustomerAdd } from '../../_Model/customer-add';

@Component({
  selector: 'app-add-customer',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './add-customer.component.html',
  styleUrl: './add-customer.component.css'
})
export class AddCustomerComponent {
  constructor(private router:Router, private custServer:CustomerServiceService, private account:AccountServiceService){}
  
  // customer: Customer | undefined;

   customerData = {
    اسم_العميل: '',
    عنوان_العميل: '',
    الموبايل: '',
    تليفون_1: '',
    تليفون_2: '',
    واتس: '',
    ايميل: '',
    الجنسيه: '',
    محل_الاقامه: '',
    توصيف: '',
    الوظيفة: '',
    ادخال_بواسطة: '', //
    تاريخ_الادخال: new Date(), //
    اخر_تعديل: '', //
    اخر_تعديل_في: new Date(),
    رجل_المبيعات: '',
    مصدر_العميل: '',
    تصنيف_العميل: ''
  };
  
  customer = new CustomerAdd(this.customerData);
  
  AddCustomer() {
    this.customer.ادخال_بواسطة = +this.account.r.id
    this.customer.اخر_تعديل = +this.account.r.id
    this.customer.تاريخ_الادخال = new Date()
    this.customer.اخر_تعديل_في = new Date()
    this.custServer.addCustomer(this.customer).subscribe(
      response =>{
        console.log(response);
        this.router.navigateByUrl("/CustomerList")
      }
    )
  }

  cancle() {
    this.router.navigate(['/CustomerList']);  
  }
}
