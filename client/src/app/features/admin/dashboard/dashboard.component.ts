import { Component, inject, OnInit } from '@angular/core';
import { NgxEchartsDirective, provideEchartsCore } from 'ngx-echarts';
import * as echarts from 'echarts/core';
import { BarChart } from 'echarts/charts';
import {
  GridComponent,
  LegendComponent,
  TooltipComponent,
} from 'echarts/components';
import { CanvasRenderer } from 'echarts/renderers';
import { CommonModule } from '@angular/common';
import { EChartsCoreOption } from 'echarts/core';
import { StatisticService } from '../../../core/services/statistic.service';
import { UtilityService } from '../../../core/services/utility.service';
import { NzStatisticModule } from 'ng-zorro-antd/statistic';
import { NzCardModule } from 'ng-zorro-antd/card';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { Overview } from '../../../shared/models/statistic';
import { Song } from '../../../shared/models/song';
import { Playlist } from '../../../shared/models/playlist';
import { Singer } from '../../../shared/models/singer';
import { NzTableModule } from 'ng-zorro-antd/table';
import { NzImageModule } from 'ng-zorro-antd/image';
import { NzToolTipModule } from 'ng-zorro-antd/tooltip';
echarts.use([
  BarChart,
  GridComponent,
  CanvasRenderer,
  TooltipComponent,
  LegendComponent,
]);

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [
    CommonModule,
    NgxEchartsDirective,
    NzStatisticModule,
    NzCardModule,
    NzIconModule,
    NzTableModule,
    NzImageModule,
    NzToolTipModule,
  ],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css',
  providers: [provideEchartsCore({ echarts })],
})
export class DashboardComponent implements OnInit {
  private statisticService = inject(StatisticService);
  utilService = inject(UtilityService);
  options!: EChartsCoreOption;
  overview: Overview = {
    totalPlaylist: 0,
    totalPrice: 0,
    totalSong: 0,
    totalUser: 0,
  };
  songList: Song[] = [];
  playlistList: Playlist[] = [];
  singerList: Singer[] = [];

  ngOnInit(): void {
    const currentYear = new Date().getFullYear();

    this.statisticService.statisticRevenueInYear(currentYear).subscribe({
      next: (res) => {
        const xAxisData: string[] = [];
        const data1: number[] = [];

        res.forEach((data) => {
          xAxisData.push(this.utilService.getFormattedOnlyDate(data.date));
          data1.push(data.totalRevenue);
        });

        this.options = {
          legend: {
            data: ['Doanh thu (VNĐ)'],
            align: 'left',
          },
          tooltip: {},
          xAxis: {
            data: xAxisData,
            silent: false,
            splitLine: {
              show: false,
            },
          },
          yAxis: {},
          series: [
            {
              name: 'Doanh thu (VNĐ)',
              type: 'bar',
              data: data1,
              animationDelay: (idx: number) => idx * 10,
            },
          ],
          animationEasing: 'elasticOut',
          animationDelayUpdate: (idx: number) => idx * 5,
        };
      },
    });

    this.loadOverview();
    this.loadTopFavorite();
  }

  loadOverview() {
    this.statisticService.overview().subscribe({
      next: (res) => {
        this.overview = res;
      },
      error: (er) => {
        console.log(er);
      },
    });
  }

  loadTopFavorite() {
    return this.statisticService.top5Favorite().subscribe({
      next: (res) => {
        console.log(res);
        this.playlistList = res.playlistList;
        this.singerList = res.singerList;
        this.songList = res.songList;
      },
      error: (er) => console.log(er),
    });
  }
}
