import { Component, EventEmitter, Input, Output, output } from '@angular/core';
import { CustomerServiceService } from '../../_Services/customer-service.service';
import { Customer } from '../../_Model/customer';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';

type CustomerKeys = keyof Customer;


@Component({
  selector: 'app-customer-list',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './customer-list.component.html',
  styleUrl: './customer-list.component.css'
})


export class CustomerListComponent {

  customers: Customer[] = [];
  totalItems: number = 0;
  pageNumber: number = 1;
  pageSize: number = 4;
  Math = Math

  constructor(private customerService: CustomerServiceService, private router:Router) { }

  @Output() tableDataEvent = new EventEmitter<any>();

  ngAfterViewInit() {
    this.tableDataEvent.emit(document.getElementById("TableId"));
  }

  ngOnInit(): void {
    this.loadCustomers();
    this.columnNames.forEach(column => {
      this.columnVisibility[column] = true;
    });
  }

  loadCustomers(): void {
    this.customerService.getCustomers(this.pageNumber, this.pageSize).subscribe(response => {
      this.customers = response.items;
      this.totalItems = response.totalItems;
    });
  }

  onPageChange(pageNumber: number): void {
    this.pageNumber = pageNumber;
    this.loadCustomers();
  }

  deleteCustomer(id:number){
    this.customerService.deleteCustomer(id).subscribe(
      respose => {
        console.log(respose)
        this.loadCustomers();
      },
      error => {
        console.error('Error deleting customer:', error);
      }
    )
  }

  editCustomer(cust:Customer){
    this.router.navigateByUrl('/edit/Customer', { state: { customer: cust } });
  }

  refreshTableData() {
    this.customers = [];
    this.loadCustomers();
  }

  columnNames: CustomerKeys[] = [
    "كود_العميل",
    "اسم_العميل",
    "عنوان_العميل",
    "الموبايل",
    "تليفون_1",
    "تليفون_2",
    "واتس",
    "ايميل",
    "الجنسيه",
    "محل_الاقامه",
    "توصيف",
    "الوظيفة",
    "ادخال_بواسطة",
    "تاريخ_الادخال",
    "اخر_تعديل",
    "اخر_تعديل_في",
    "رجل_المبيعات",
    "مصدر_العميل",
    "تصنيف_العميل",
  ];

  columnVisibility: { [key: string]: boolean } = {};

  print(r:any){
    this.columnVisibility = r
  }

  getCustomerProperty(customer: Customer, key: CustomerKeys): any {
    return customer[key];
  }

  showSearch:boolean = false;
  showSearchFunc(r:boolean){
    this.showSearch = r
    this.showSearch = !this.showSearch;
  }

  columnSearchText: string[] = Array(this.columnNames.length).fill('');
  
  Search(index: number) {
    console.log('Search string for column', this.columnNames[index], ':', this.columnSearchText[index]);
  }
}
