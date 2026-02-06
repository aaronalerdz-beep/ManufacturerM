import { Component } from '@angular/core';
import { BaseChartDirective } from 'ng2-charts';
import { ChartConfiguration, ChartOptions } from 'chart.js';

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

  public lineChartData: ChartConfiguration<'line'>['data'] = {
    labels: ['Enero', 'Febrero', 'Marzo', 'Abril'],
    datasets: [
      {
        data: [65, 59, 80, 81],
        label: 'Ventas 2026',
        backgroundColor: 'oklch(94.8% 0.028 342.258/ .6)',
        borderColor: '#510424',
        fill: true
      }
    ]
  };

  public BarChartData: ChartConfiguration<'bar'>['data'] = {
    labels: ['Enero', 'Febrero', 'Marzo', 'Abril'],
    datasets: [
      {
        data: [65, 59, 80, 81],
        label: 'Ventas 2026',
        backgroundColor: [
        '#FF6384', 
        '#36A2EB', 
        '#FFCE56', 
        '#4BC0C0'  
        ],
        borderColor: '#510424',
      }
    ]
  };

  public PieChartData: ChartConfiguration<'pie'>['data'] = {
    labels: ['Enero', 'Febrero', 'Marzo', 'Abril'],
    datasets: [
      {
        data: [65, 59, 80, 81],
        backgroundColor: [
        '#FF6384', 
        '#36A2EB', 
        '#FFCE56', 
        '#4BC0C0'  
        ],
        label: 'Ventas 2026',
        borderColor: '#510424',
        
      }
    ]
  };

  // 2. Definir opciones (Responsivo, títulos, etc.)
  public lineChartOptions: ChartOptions<'line'> = {
    responsive: true,
    plugins: {
      legend: { display: true }
    }
  };
  // 2. Definir opciones (Responsivo, títulos, etc.)
  public barChartOptions: ChartOptions<'bar'> = {
    responsive: true,
    plugins: {
      legend: { display: true }
    }
  };
  // 2. Definir opciones (Responsivo, títulos, etc.)
  public pieChartOptions: ChartOptions<'pie'> = {
    responsive: true,
    plugins: {
      legend: { display: true }
    }
  };

}
