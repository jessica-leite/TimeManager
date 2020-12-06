import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-completed-hours',
  templateUrl: './completed-hours.component.html',
  styleUrls: ['./completed-hours.component.css']
})
export class CompletedHoursComponent implements OnInit {

  public activities: any;
  public completedTime: string;
  constructor(private route: Router) { }

  ngOnInit(): void {

    this.activities = [];
  }

  public addHours(time: any){
    window.alert(time);
    this.route.navigate(['/dashboard'])
  }
}
