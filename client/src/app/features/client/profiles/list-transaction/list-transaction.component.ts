import { Component, inject, ViewChild } from '@angular/core';
import { TransactionService } from '../../../../core/services/transaction.service';
import { UtilityService } from '../../../../core/services/utility.service';
import {
  Transaction,
  TransactionParams,
} from '../../../../shared/models/transaction';
import { Pagination } from '../../../../shared/models/pagination';
import { TransactionDetailComponent } from '../../../../shared/component/transaction-detail/transaction-detail.component';
import { NzTableModule } from 'ng-zorro-antd/table';
import { NzPaginationModule } from 'ng-zorro-antd/pagination';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { NzDatePickerModule } from 'ng-zorro-antd/date-picker';
import { AuthService } from '../../../../core/services/auth.service';

@Component({
  selector: 'app-list-transaction',
  standalone: true,
  imports: [
    NzTableModule,
    NzPaginationModule,
    NzButtonModule,
    NzInputModule,
    NzIconModule,
    FormsModule,
    CommonModule,
    NzDatePickerModule,
    TransactionDetailComponent,
  ],
  templateUrl: './list-transaction.component.html',
  styleUrl: './list-transaction.component.css',
})
export class ListTransactionComponent {
  // init
  private transactionService = inject(TransactionService);
  utilService = inject(UtilityService);
  date = null;
  authService = inject(AuthService);

  ngOnInit(): void {
    this.loadTransactions();
  }

  //load transaction
  transactions: Transaction[] = [];
  prm = new TransactionParams();
  pagination: Pagination = {
    currentPage: 1,
    itemsPerPage: 5,
    totalItems: 0,
    totalPages: 1,
  };

  loadTransactions() {
    this.transactionService.getMyTransactions(this.prm).subscribe({
      next: (response) => {
        console.log(response);
        this.transactions = response.result as Transaction[];
        this.pagination = response.pagination as Pagination;
      },
      error: (er) => {
        console.log(er);
      },
    });
  }

  // search, paging, sorting
  onPageIndexChange(newPageNumber: number) {
    this.prm.pageNumber = newPageNumber;
    this.loadTransactions();
  }

  onPageSizeChange(newPageSize: number) {
    this.prm.pageSize = newPageSize;
    this.loadTransactions();
  }

  onSortChange(sortBy: string) {
    const currentSort = this.prm.orderBy;

    if (currentSort === sortBy) {
      this.prm.orderBy = `${sortBy}_desc`;
    } else if (currentSort === `${sortBy}_desc`) {
      this.prm.orderBy = sortBy;
    } else {
      this.prm.orderBy = sortBy;
    }
    this.loadTransactions();
  }

  onSearch() {
    this.loadTransactions();
  }

  onChange(result: Date[]): void {
    this.prm.startDate = this.utilService.formatDateToStringWithTime(result[0]);
    this.prm.endDate = this.utilService.formatDateToStringWithTime(result[1]);
    this.loadTransactions();
  }

  onReset() {
    this.date = null;
    this.prm.searchTerm = '';
    this.prm.startDate = '';
    this.prm.endDate = '';
    this.loadTransactions();
  }

  @ViewChild(TransactionDetailComponent)
  transactionDetailComponent!: TransactionDetailComponent;
  openDetail(id: number) {
    if (this.transactionDetailComponent) {
      this.transactionDetailComponent.userVipSubcriptionId = id;
      this.transactionDetailComponent.showModal();
    } else {
      console.error('TransactionDetailComponent is not initialized yet');
    }
  }
}
