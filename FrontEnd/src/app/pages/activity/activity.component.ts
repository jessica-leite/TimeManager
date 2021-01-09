import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-activity',
  templateUrl: './activity.component.html',
  styleUrls: ['./activity.component.css']
})
export class ActivityComponent implements OnInit {
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
  }

  public add(title: string, description: string, estimatedHours: any){
    this.http.post('api/activity', {Name: title, Description: description, EstimatedHours: estimatedHours});

    history.back();
  }
}
