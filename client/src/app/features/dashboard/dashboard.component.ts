import { Component, computed, effect, inject, signal } from '@angular/core';
import { BaseChartDirective } from 'ng2-charts';
import { ChartConfiguration, ChartOptions } from 'chart.js';
import { OrdersService } from '../../core/services/orders.service';
import { monthorders } from '../../shared/models/monthorders';
import { map } from 'rxjs';
import { ViewChild } from '@angular/core';
import { PartsService } from '../../core/services/parts.service';
import { Part } from '../../shared/models/part';
import { Production_order } from '../../shared/models/order';
import { countOrderPart } from '../../shared/models/countorder';
import { PressureStats } from '../../shared/models/pressureStats';
import { cycleMService } from '../../shared/models/cycleMService';
import ChartDataLabels from 'chartjs-plugin-datalabels';
import { CyclesService } from '../../core/services/cycles.service';
import { CyclesStatsService } from '../../core/services/cyclesStats.service';
import { SignalrService } from '../../core/services/signalr.service';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [
    BaseChartDirective
  ],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss',
})
export class DashboardComponent {
    @ViewChild(BaseChartDirective) chart?: BaseChartDirective;
    private ordersService = inject(OrdersService);
    public partsServer = inject(PartsService);
    public cycleStatsServer = inject(CyclesStatsService);
    public signalrService = inject(SignalrService);
    public doughnutChartPlugins = [ChartDataLabels]; 

    parts = signal<Part[]>([]);
    orders = signal<Production_order[]>([]);
    mOrders = signal<monthorders[]>([]);
    cOParts = signal<countOrderPart[]>([]);
    PressureS = signal<PressureStats[]>([]);
    stats = this.signalrService.cycleStats;  
    
  ngOnInit(): void {
        this.initializeMonth();
        this.initializepartList();
        this.initializeOrderList();
        this.initializeCycleList();
    }

  initializepartList() {
    this.partsServer.getAll().subscribe({
    next: response => {
      this.parts.set(response.data)
    },
      error: (err) => console.error('Error:', err)
    });
  }
  initializeOrderList(){
    this.ordersService.getAll().subscribe({
    next: response => {
        console.log(response.data);
        this.orders.set(response.data)
    },
    error: error=> console.log(error)      
    });
  }
  initializeCycleList(){
    this.cycleStatsServer.getPressureStats().subscribe({
            next: data => this.PressureS.set(data),
            error: err => console.error(err)
    });
  }
    lastPartCount = computed(() => {
    return this.parts().length > 0 ? this.parts()[this.parts().length - 1] : null;
    });
    totalOrdersCount = computed(() => {
    return this.mOrders().reduce((acc, current) => acc + current.totalOrders, 0);
    });

    totalFinishCount = computed(() => {
      return this.orders().reduce((sum, order) => {
        return sum + (order.final_quantity || 0);
      }, 0);
    });
    
    totaltargetCount = computed(() => {
      return this.orders().reduce((sum, order) => {
        return sum + (order.target_quantity || 0);
      }, 0);
    });
    procentCount = computed(() => {
      const target = this.totaltargetCount();
      const finish = this.totalFinishCount();

      if (target === 0) return 0; 
      const cal = (finish / target) * 100;
      return parseFloat(cal.toFixed(1));
    });

    initializeMonth() {
        this.ordersService.getMonthlyStats().subscribe({
            next: data => this.mOrders.set(data),
            error: err => console.error(err)
        });
        this.ordersService.getCountOrders().subscribe({
            next: data => this.cOParts.set(data),
            error: err => console.error(err)
        });
    }

  public lineChartData: ChartConfiguration<'line'>['data'] = {
      labels: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
      datasets: [
          {
              data: [],
              label: 'Orders 2026',
              backgroundColor: 'oklch(94.8% 0.028 342.258/ .6)',
              borderColor: '#510424',
              fill: true
          }
      ]
  };

  public BarChartData: ChartConfiguration<'bar'>['data'] = {
    labels: [],
    datasets: [
      { 
        data: [], 
        label: 'Complete Cycles', 
        backgroundColor: '#2ecc71' 
      },
      { 
        data: [], 
        label: 'Incomplete Cycles', 
        backgroundColor: '#e74c3c' 
      }
    ]
  };
  public doughnutChartData: ChartConfiguration<'doughnut'>['data'] = {
    labels: [],
    datasets: [
      {
        data: [],
        backgroundColor: [
        '#FF6384', 
        '#36A2EB', 
        '#FFCE56', 
        '#4BC0C0'  
        ],
        label: '2026',
        borderColor: '#510424',
        
      }
    ]
  };

  constructor() {
    effect(() => {
      const countO =  this.cOParts();
      const stats = this.mOrders();
      const pressure = this.PressureS();
      if (stats.length === 0)return; 
      const newData = new Array(12).fill(0);
      stats.forEach(item => {
        const monthIndex = Number(item.month) - 1;
        if (monthIndex >= 0 && monthIndex < 12) {
          newData[monthIndex] = item.totalOrders;
        }
      });
      this.lineChartData.datasets[0].data = [...newData];
      if (countO.length > 0) {
        const labelsPartes = countO.map(item => `PN-00000${item.part}`);
        const datosPartes = countO.map(item => item.totalQuantity);
        
        this.doughnutChartData = {
          labels: labelsPartes,
          datasets: [
            {
              ...this.doughnutChartData.datasets[0],
              data: datosPartes
            }
          ]
        };
      }
      if (pressure.length > 0) {
        const pressureLabels = pressure.map(item => `${item.pressure} PSI`);
        const dataCompletados = pressure.map(item => item.totalCycles);
        const dataIncompletos = pressure.map(item => item.incompleteCycles);
        this.BarChartData = {
          labels: pressureLabels,
          datasets: [
            {
              ...this.BarChartData.datasets[0],
              data: dataCompletados
            },
            {
              ...this.BarChartData.datasets[1],
              data: dataIncompletos
            }
          ]
        };
      }
      this.chart?.update();
    });
  }

 
  public lineChartOptions: ChartOptions<'line'> = {
    responsive: true,
    plugins: {
      legend: { display: true }
    }
  };




  public barChartOptions: ChartOptions<'bar'> = {
    responsive: true,
    plugins: {
      legend: { display: true }
    }
  };
 
  
 public doughnutChartOptions: ChartOptions<'doughnut'> = {
  responsive: true,
  plugins: {
    legend: { display: true },
    datalabels: {
      color: '#fff', 
      anchor: 'center',
      align: 'center',
      font: {
        weight: 'bold',
        size: 16
      },
      formatter: (value, ctx) => {
        const dataset = ctx.chart.data.datasets[0].data as number[];
        const total = dataset.reduce((acc, data) => acc + data, 0);
        const percentage = ((value * 100) / total).toFixed(0) + '%';
        return percentage; 
      },
    }
  }
};  

}
