import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CompletedHoursComponent } from './completed-hours.component';

describe('CompletedHoursComponent', () => {
  let component: CompletedHoursComponent;
  let fixture: ComponentFixture<CompletedHoursComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CompletedHoursComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CompletedHoursComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
