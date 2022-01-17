import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PlantpediaPageComponent } from './plantpedia-page/plantpedia-page.component';
import { RoomOverviewPageComponent } from './room-overview-page/room-overview-page.component';
import { PlantDetailsPageComponent } from './plant-details-page/plant-details-page.component';

const routes: Routes = [
  {
    path: 'plantpedia',
    component: PlantpediaPageComponent
  },
  {
    path: 'room-overview',
    component: RoomOverviewPageComponent
  },
  {
    path: 'plant-details',
    component: PlantDetailsPageComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
