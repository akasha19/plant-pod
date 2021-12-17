import { Component, OnInit } from '@angular/core';
import { PlantData } from '../types/PlantData';
@Component({
  selector: 'app-plant-overview-page',
  templateUrl: './plant-overview-page.component.html',
  styleUrls: ['./plant-overview-page.component.scss']
})
export class PlantOverviewPageComponent implements OnInit {

  Plant: PlantData[] | undefined;



  ngOnInit(): void {
        this.Plant = [
          {
            id: "1",
            sensorId: "1",
            name:  "Aloë Vera",
            description:  "das schöne plantje",
            temperature:  "10",
            moisture:  "13%",
            humidity:  "20%",
            imageSource: "assets/img/aloevera.jpg",
          },
          {
            id: "2",
            sensorId: "2",
            name:  "Banana plant",
            description:  "das schöne banana plantje",
            temperature:  "10",
            moisture:  "23%",
            humidity:  "30%",
            imageSource: "assets/img/bananaplant.jpg"
          },


    ]

}










}
