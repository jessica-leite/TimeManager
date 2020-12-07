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

    // this.http.get('http://localhost:50292/api/report')
    // .subscribe((returnedStuff) => {
    // console.log(returnedStuff);
    // }); 

    // this.http.get('http://localhost:50292/api/report').subscribe( (data: any) => {
    //   console.log('received data: ' + data)
    // });

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
}
