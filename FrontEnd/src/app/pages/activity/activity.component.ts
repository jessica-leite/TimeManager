import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-activity',
  templateUrl: './activity.component.html',
  styleUrls: ['./activity.component.css']
})
export class ActivityComponent implements OnInit {

  constructor(private route: Router) { }

  ngOnInit(): void {
  }

  public add(title: string, description: string, estimatedHours: any){
    window.alert(title + ', ' + description + ', ' + estimatedHours);
    this.route.navigate(['/dashboard']);
  }
}
