import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { map, Observable, of } from 'rxjs';
import { PlantsService } from '../services/plants.service';
import { OverviewType } from '../types/OverviewType';
import { Plant } from '../types/Plant';
import { RequestError } from '../types/RequestError';
@Component({
  selector: 'app-plant-details-page',
  templateUrl: './plant-details-page.component.html',
  styleUrls: ['./plant-details-page.component.scss']
})

export class PlantDetailsPageComponent implements OnInit {
  id: string | undefined;
  sensorId: string | undefined;
  plant$: Observable<Plant> | undefined;
  error: RequestError = { hasError: false };

  readonly overviewType: string = OverviewType.Plant.toString()

  constructor(
    private route: ActivatedRoute,
    private plantsService: PlantsService
  ) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.id = params['id'];
      this.sensorId = params['sensorId']
      if (this.id && this.sensorId) {
        this.plantsService.getPlantById(this.id)
          .pipe(map((value) => {
            if (value.success && value.data) {
              this.plant$ = of(value.data)
            } else {
              this.error = { hasError: true, message: value.message };
            }
          })).subscribe();
      }
    });
  }
}
