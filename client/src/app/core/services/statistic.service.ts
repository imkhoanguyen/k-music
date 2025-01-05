import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { DailyRevenue } from '../../shared/models/statistic';

@Injectable({
  providedIn: 'root',
})
export class StatisticService {
  private baseUrl = `${environment.apiUrl}admin/`;
  private http = inject(HttpClient);

  statisticRevenueInYear(year: number) {
    return this.http.get<DailyRevenue[]>(
      this.baseUrl + `statistic/revenue/${year}`
    );
  }
}
