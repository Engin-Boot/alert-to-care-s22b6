import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VitalsmonitoringComponent } from './vitalsmonitoring.component';

describe('VitalsmonitoringComponent', () => {
  let component: VitalsmonitoringComponent;
  let fixture: ComponentFixture<VitalsmonitoringComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VitalsmonitoringComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(VitalsmonitoringComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
