import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-tables',
  templateUrl: './tables.component.html',
  styleUrls: ['./tables.component.scss']
})
export class TablesComponent implements OnInit {

  public activities: any;

  constructor() { }

  ngOnInit() {

    this.activities = [{
      name: 'atividade1',
      estimatedTime: 20,
      completedTime: 5
    },
    {
      name: 'atividade2',
      estimatedTime: 100,
      completedTime: 50
    },
    {
      name: 'atividade3',
      estimatedTime: 100,
      completedTime: 10
    }];

  }

  alert() {
    console.log('oi');
  }
}
