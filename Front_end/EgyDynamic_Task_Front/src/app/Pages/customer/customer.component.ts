import { Component, ElementRef, EventEmitter, Output, ViewChild } from '@angular/core';
import { CustomerListComponent } from '../../Components/customer-list/customer-list.component';
import { Router } from '@angular/router';
import * as XLSX from 'xlsx';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { AccountServiceService } from '../../_Services/account-service.service';

@Component({
  selector: 'app-customer',
  standalone: true,
  imports: [CustomerListComponent, FormsModule, CommonModule],
  templateUrl: './customer.component.html',
  styleUrl: './customer.component.css'
})
export class CustomerComponent {
  constructor(private router:Router, private account:AccountServiceService){
    this.initializeColumnVisibility()
  }

  ngOnInti(){
    this.columnNames.forEach(column => {
      this.columnVisibility[column] = true;
    });
  }

  AddCustomer(){
    this.router.navigateByUrl('/add/Customer')
  }
  
  receivedTableData: any;
  
  handleTableData(data: any) {
    this.receivedTableData = data;
  }
    
  ExportToExcelFile(){
    const ws: XLSX.WorkSheet =XLSX.utils.table_to_sheet(this.receivedTableData);
    
    const wb: XLSX.WorkBook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, ws, 'Sheet1');
      
    XLSX.writeFile(wb, "CustomerData.xlsx");
  }
    
  PrintTable(){
    window.print();
  }

  @ViewChild(CustomerListComponent) childComponent!: CustomerListComponent;

  Refresh() {
    this.childComponent.refreshTableData();
  }

  columnNames: string[] = [
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
  showColumnSelector = false;

  initializeColumnVisibility() {
    this.columnNames.forEach(column => {
      this.columnVisibility[column] = true;
    });
  }

  Filter() {
    if(!this.showColumnSelector){
      this.childComponent.print(this.columnVisibility)
    }
    this.showColumnSelector = !this.showColumnSelector;
  }
    
  showSearch:boolean = false;
  search() {
    this.childComponent.showSearchFunc(this.showSearch);
    this.showSearch = !this.showSearch;
  }

  Logout(){
    this.account.logout()
  }
}

    