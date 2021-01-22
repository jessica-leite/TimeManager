import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-activity',
  templateUrl: './activity.component.html',
  styleUrls: ['./activity.component.css']
})
export class ActivityComponent implements OnInit {
  constructor(private http: HttpClient, private route: ActivatedRoute) { }

  public action: any;
  public id: any;
  public name: any;
  public estimatedTime: any;
  public activityDescription: any;

  ngOnInit(): void {
    this.action = this.route.snapshot.url[0].path;
    this.id = history.state.data?.id;
    this.name = history.state.data?.name;
    this.estimatedTime = history.state.data?.estimatedHours;
    this.activityDescription = history.state.data?.description;
  }

  public add(title: string, description: string, estimatedHours: any) {
    this.http.post('api/activity', { Name: title, Description: description, EstimatedHours: estimatedHours })
      .subscribe(() => history.back());
  }

  public delete() {
    this.http.delete('api/activity/' + this.route.snapshot.paramMap.get('id'))
      .subscribe(() => history.back());
  }

  public update(title: any, description: any, estimatedHours: any){
    this.http.put('api/activity', { Id:this.id, Name: title, Description: description, EstimatedHours: estimatedHours })
      .subscribe(() => history.back());
  }
}
