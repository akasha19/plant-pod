import { Component, OnInit } from '@angular/core';
import { Plant } from '../types/Plant';
@Component({
  selector: 'app-plant-details-page',
  templateUrl: './plant-details-page.component.html',
  styleUrls: ['./plant-details-page.component.scss']
})
export class PlantDetailsPageComponent implements OnInit {



    plants: Plant[] | undefined;


    ngOnInit(): void {
      this.plants = [
        {
          id: "1",
          sensorId: "1",
          name: "Banana plant",
          description: "Musa ornata, the flowering banana, is one of more than 50 species of banana in the genus Musa of the family Musaceae. Most of these species are large tropical evergreen perennials, mainly from lowland areas with high temperature and humidity. Musa ornata originated in southeast Asia, and is cultivated for its commercial and ornamental value. The fruit is attractive but tends to be inedible. Banana Plants are best equipped for locations that provide bright, indirect light. Areas that are too dark will significantly increase the risk of root rot, along with slowed growth and yellowing older leaves.\nAllow the top half to dry out in between waters, reducing this further in the autumn and winter. Over-watering during its dormancy period is a common issue among owners, so always bear this in mind when the colder months arrive.\nFertilise using a 'Houseplant' labelled feed every four waters in the spring and summer, reducing this to every six in the colder months.\nKeep an eye out for Spider Mites that'll form webs on the under-sides of its foliage. Aphids can also attack the juvenile growth once the temperatures start to increase in the spring.\nEspecially if located in a dark location, wash or dust the foliage monthly, to increase the light-capturing efficiency.\nRepot every two or three years using 'Cactus & Succulent' soil. Introduce a layer of grit for larger specimens to strengthen their root system and downplay over-watering.",
          imageSource: "assets/img/bananaplant.jpg"
        },
        {
          id: "2",
          sensorId: "2",
          name: "Aloë Vera",
          description: "Aloe vera, sometimes described as a “wonder plant,” is a short-stemmed shrub. Aloe is a genus that contains more than 500 species of flowering succulent plants. Many Aloes occur naturally in North Africa. The leaves of Aloe vera are succulent, erect, and form a dense rosette. Many uses are made of the gel obtained from the plant’s leaves.",
          imageSource: "assets/img/aloevera.jpg"
        },
      ]
    }
  }
