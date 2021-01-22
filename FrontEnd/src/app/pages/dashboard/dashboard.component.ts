import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  public completedHours: any;
  public completedActivities: any;
  public activities: any;

  constructor(private http: HttpClient, private router: Router) {
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

  goToActivity(method: string, id: any, name: any, description: any, estimatedHours: any) {
    var url = '/' + method + '/' + id;
    this.router.navigate([url], { state: { data: { id, name, description, estimatedHours } } });
  }
}
