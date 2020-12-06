import { Component, OnInit } from '@angular/core';
import Chart from 'chart.js';
import { HttpClient, HttpHeaders, HttpClientModule } from '@angular/common/http';


// core components
import {
  chartOptions,
  parseOptions,
  chartExample1,
  chartExample2
} from "../../variables/charts";

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  public datasets: any;
  public data: any;
  public salesChart;
  public clicked: boolean = true;
  public clicked1: boolean = false;
  public completedHours: any;
  public completedActivities: any;
  public activities: any;

  constructor(private http: HttpClient) { 
    this.activities = [{
      name: 'atividade1',
      estimatedTime: 20,
      completedTime: 5,
      remainingTime: 15
    },
    {
      name: 'atividade2',
      estimatedTime: 100,
      completedTime: 50,
      remainingTime: 50
    },
    {
      name: 'atividade3',
      estimatedTime: 100,
      completedTime: 10,
      remainingTime: 90
    }];

    this.completedHours = 257;
    this.completedActivities = 18;
  }

  ngOnInit() {

    // this.http.get('http://localhost:50292/api/report')
    // .subscribe((returnedStuff) => {
    // console.log(returnedStuff);
    // }); 

    // this.http.get('http://localhost:50292/api/report').subscribe( (data: any) => {
    //   console.log('received data: ' + data)
    // });

    this.datasets = [
      [0, 20, 10, 30, 15, 40, 20, 60, 60],
      [0, 20, 5, 25, 10, 30, 15, 40, 40]
    ];
    this.data = this.datasets[0];


    var chartOrders = document.getElementById('chart-orders');

    parseOptions(Chart, chartOptions());


    var ordersChart = new Chart(chartOrders, {
      type: 'bar',
      options: chartExample2.options,
      data: chartExample2.data
    });

    var chartSales = document.getElementById('chart-sales');

    this.salesChart = new Chart(chartSales, {
      type: 'line',
      options: chartExample1.options,
      data: chartExample1.data
    });
  }


  public updateOptions() {
    this.salesChart.data.datasets[0].data = this.data;
    this.salesChart.update();
  }
}
