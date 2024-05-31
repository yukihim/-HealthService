import { Component, Injector, OnInit, ViewChild, ViewEncapsulation, AfterViewInit } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { DocumentServiceProxy, DocumentListDto, ListResultDtoOfDocumentListDto } from '@shared/service-proxies/service-proxies';
import { NgForm } from '@angular/forms';
import { DateTime } from 'luxon';
import { BrowserModule } from '@angular/platform-browser';
import { LazyLoadEvent } from 'primeng/api';
import { Paginator } from 'primeng/paginator';
import { PrimengTableHelper } from 'shared/helpers/PrimengTableHelper';
import { DateTimeService } from '@app/shared/common/timing/date-time.service';
import { TableModule } from 'primeng/table';

@Component({
    selector: 'createDocumentModal',
    templateUrl: './quanlyvanban.component.html',
    animations: [appModuleAnimation()]
})

export class QuanlyvanbanComponent extends AppComponentBase implements OnInit {

  data: DocumentListDto[] = [];
  filter: string = '';
  validDate: string = '';
  expireDate: string = '';
  docType: string = '';
  showAdvancedSearch: boolean = false; // Variable to control the visibility of advanced search inputs
  statuses!: any[];

  constructor(
      injector: Injector,
      private _documentService: DocumentServiceProxy
  ) {
      super(injector);
  }

  ngOnInit(): void {
    this.getDoc();
    this.data.forEach(() => {
      this.checkboxStates.push(false);
    });

    this.statuses = [
      { label: 'Báo cáo', value: 'Báo cáo' },
      { label: 'Bản ghi nhớ', value: 'Bản ghi nhớ' },
      { label: 'Bản thỏa thuận', value: 'Bản thỏa thuận' },
      { label: 'Biên bản', value: 'Biên bản' },
      { label: 'Chỉ thị', value: 'Chỉ thị' },
      { label: 'Chương trình', value: 'Chương trình' },
      { label: 'Công điện', value: 'Công điện' },
      { label: 'Công văn', value: 'Công văn' },
      { label: 'Dự án', value: 'Dự án' },
      { label: 'Đề án', value: 'Đề án' },
      { label: 'Giấy giới thiệu', value: 'Giấy giới thiệu' },
      { label: 'Giấy mời', value: 'Giấy mời' },
      { label: 'Giấy nghỉ phép', value: 'Giấy nghỉ phép' },
      { label: 'Giấy ủy quyền', value: 'Giấy ủy quyền' },
      { label: 'Hợp đồng', value: 'Hợp đồng' },
      { label: 'Hướng dẫn', value: 'Hướng dẫn' },
      { label: 'Kế hoạch', value: 'Kế hoạch' },
      { label: 'Nghị quyết', value: 'Nghị quyết' },
      { label: 'Phương án', value: 'Phương án' },
      { label: 'Quy chế', value: 'Quy chế' },
      { label: 'Quy định', value: 'Quy định' },
      { label: 'Quyết định', value: 'Quyết định' },
      { label: 'Thông báo', value: 'Thông báo' },
      { label: 'Thông cáo', value: 'Thông cáo' },
      { label: 'Thư công', value: 'Thư công' },
      { label: 'Tờ trình', value: 'Tờ trình' },
      { label: 'Tài liệu', value: 'Tài liệu' },
      { label: 'Thông tin', value: 'Thông tin' },
      { label: 'Thủ tục', value: 'Thủ tục' },
    ];
  }

  checked: boolean = false;
  isButtonEnabled: boolean = false;
  checkboxStates: boolean[] = [];

  // onCheckboxChange(event: any): void {
  //     this.isButtonEnabled = event.target.checked;
  // }
  onCheckboxChange(checked: boolean, index: number): void {
    this.checkboxStates[index] = checked;
    this.isButtonEnabled = checked;
  }


  // Method to filter the documents based on the search text
  // filterDocs(): void {
  // // Convert the search text to lowercase for case-insensitive search
  // const searchTextLower = this.searchText1.toLowerCase();
  // // Filter the documents based on the search text
  // this.doc = this.doc.filter(doc =>
  // doc.fullText.toLowerCase().includes(searchTextLower) ||
  // doc.type.toLowerCase().includes(searchTextLower) ||
  // doc.docID.toLowerCase().includes(searchTextLower)
  // );
  // }

  // Function to toggle the visibility of advanced search inputs
  toggleAdvancedSearch(): void {
    // this.showAdvancedSearch = !this.showAdvancedSearch;
    this.filter = '';
    this.validDate = '';
    this.expireDate = '';
    this.docType = '';
    this.getSearch();
  }

  // Function to perform basic search
  getSearch(): void{
    if((this.validDate != '') && (this.expireDate == '')){
      this._documentService.search(this.filter, 1, this.validDate, this.expireDate, this.docType).subscribe((result) => {
          this.data = result.items;
      })
    }
    else if(this.validDate == '' && this.expireDate != ''){
      this._documentService.search(this.filter, 2, this.validDate, this.expireDate, this.docType).subscribe((result) => {
          this.data = result.items;
      })
    }
    else if(this.validDate != '' && this.expireDate != ''){
      this._documentService.search(this.filter, 3, this.validDate, this.expireDate, this.docType).subscribe((result) => {
          this.data = result.items;
      })
    }
    else{
      this._documentService.search(this.filter, 0, this.validDate, this.expireDate, this.docType).subscribe((result) => {
          this.data = result.items;
      })
    }
  }

  // Assuming 'docs' is your array of documents
  getDocumentCount(): number {
        // Return the count of documents based on a specific property, for example 'docID'
        return this.data.length;
  }
    

  getDoc(): void {
    this._documentService.getDocument(this.filter).subscribe((result) => {
        this.data = result.items;
        // this.updateDisplayedDocuments();
    });
  }

  filtered(selectedValue: string): void {
    this.data = this.data.filter(doc => doc.docType === selectedValue);
  }
  
  getSearchtype(selectedValue: string): void {
      // this.filtered(selectedValue);
      this.docType = selectedValue;
      if(!selectedValue)
        this.toggleAdvancedSearch();
      this.getSearch();
  }

}