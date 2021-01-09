import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

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
