import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import {
  DailyRevenue,
  Overview,
  TopFavorite,
} from '../../shared/models/statistic';

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

  overview() {
    return this.http.get<Overview>(this.baseUrl + 'statistic/overview');
  }

  top5Favorite() {
    return this.http.get<TopFavorite>(
      this.baseUrl + `statistic/top-favorite/${5}`
    );
  }
}
