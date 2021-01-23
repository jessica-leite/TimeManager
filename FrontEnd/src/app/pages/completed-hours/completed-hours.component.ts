import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-completed-hours',
  templateUrl: './completed-hours.component.html',
  styleUrls: ['./completed-hours.component.css']
})
export class CompletedHoursComponent implements OnInit {

  public activities: any;
  public id: any;
  public name: any;
  public activityDescription: any;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.id = history.state.data.id;
    this.name = history.state.data.name;
    this.activityDescription = history.state.data.description;
  }

  public addHours(time: any){
    this.http.post('api/activity/hours', { Id: this.id, Time: time })
      .subscribe(() => history.back());
  }
}
