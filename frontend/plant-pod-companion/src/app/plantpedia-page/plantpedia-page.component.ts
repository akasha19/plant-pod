import { Component, OnInit } from '@angular/core';
import { map, Observable, of } from 'rxjs';
import { PlantsService } from '../services/plants.service';
import { Plant } from '../types/Plant';
import { RequestError } from '../types/RequestError';
import { MoistureLevel } from './MoistureLevels';

@Component({
  selector: 'app-plantpedia-page',
  templateUrl: './plantpedia-page.component.html',
  styleUrls: ['./plantpedia-page.component.scss']
})

export class PlantpediaPageComponent implements OnInit {

  plants$: Observable<Plant[]> | undefined;
  error: RequestError = { hasError: false };

  readonly maxTemperatureTooltip = "(Maximum Temperature) Too high temperatures and this plant could dry out and die. Try opening a window or turning down the heating. If the plant is in direct sunlight, try moving it to a less sunny area for some time.";
  readonly minTemperatureTooltip = "(Minimum Temperature) When the plant is too cold, it could damage the plant and eventually kill it. Too cold environments will also stop it from growing. Try putting the plant in a more sunny area, turning up the heating for some time, or closing a window.";
  readonly maxphTooltip = "(Maximum pH) Different plants require different soil acidity (pH) to grow healthily. A pH that is too high for the plant, could eventually kill the plant. Try adding a small amount of aluminium sulfate or elemental sulfur in order to lower the pH.";
  readonly minphTooltip = "(Minimum pH) Different plants require different soil acidity (pH) to grow healthily. A pH that is too low for the plant, could eventually kill the plant. Adding granulated limestone to the soil will help increase the pH of the soil.";
  readonly minHumidityTooltip = "(Minimum Relative Humidity) When the humidity is too low, the plant could dry out an eventually die. The humidity could be increased by using a humidifier or by placing a bowl filled with water on a heating source near the plant.";
  readonly maxHumidityTooltip = "(Maximum Relative Humidity) Too high relative humidity could lead to fungi or bacteria on the plant. Lowering the humidity can be done by using a dehumidifier, or opening a window on a dry day.";

  readonly moistureLevelTooltips: Map<MoistureLevel, string> = new Map<MoistureLevel, string>([
    [MoistureLevel.Dry, "Dry soil should not feel damp or wet in any way, only water the soil once every few weeks and make sure to have a flower pot with holes in the bottom in order to drain any excess water."],
    [MoistureLevel.Moist, "Moist soil should feel and look damp or wet when touched. The best way to keep this level of moisture is to have a draining plant pod which is placed inside a container filled with water. Make sure to always keep the container filled with water."],
    [MoistureLevel.Normal, "This level of moisture can be obtained by regularly watering the plant pot. Make sure to drain the excess water, but always keep the soil damp."],
    [MoistureLevel.Wet, "This level of moisture can be dangerous for a lot of plants as it provides an excellent environment for moulds and root rot but some plants thrive in this environment. Moist soil can be provided by having a closed plant pot which is regularly provided with fresh water."],
  ]);


  constructor(private plantsService: PlantsService) { }

  ngOnInit(): void {
    this.plantsService.getPlants()
      .pipe(map((value) => {
        if (value.success && value.data) {
          this.plants$ = of(value.data)
        } else {
          this.error = { hasError: true, message: value.message };
        }
      })).subscribe();
  }
}
