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
  }

  ngOnInit() {

    this.http.get('api/report')
    .subscribe((data) => {
      this.completedHours = Object.values(data);
    });
    
   this.http.get('api/report/totalCompleted')
   .subscribe((data) => {
     this.completedActivities = data;
   });

   this.http.get('api/activity')
   .subscribe((data) => {
     this.activities = data;
   });
  }
}
