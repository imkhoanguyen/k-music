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
  imports: [CommonModule, NgxEchartsDirective],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css',
  providers: [provideEchartsCore({ echarts })],
})
export class DashboardComponent implements OnInit {
  private statisticService = inject(StatisticService);
  private utilService = inject(UtilityService);
  options!: EChartsCoreOption;

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
  }
}
