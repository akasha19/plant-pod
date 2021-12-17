import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlantOverviewPageComponent } from './plant-overview-page.component';

describe('PlantOverviewPageComponent', () => {
  let component: PlantOverviewPageComponent;
  let fixture: ComponentFixture<PlantOverviewPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PlantOverviewPageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PlantOverviewPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
