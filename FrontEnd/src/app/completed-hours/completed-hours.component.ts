import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-completed-hours',
  templateUrl: './completed-hours.component.html',
  styleUrls: ['./completed-hours.component.css']
})
export class CompletedHoursComponent implements OnInit {

  public activities: any;
  constructor() { }

  ngOnInit(): void {

    this.activities = [];
  }

}
