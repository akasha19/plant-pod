import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PlantpediaPageComponent } from './plantpedia-page/plantpedia-page.component';
import { RoomDetailsPageComponent } from './room-details-page/room-details-page.component';

const routes: Routes = [
  {
    path: 'plantpedia',
    component: PlantpediaPageComponent
  },
  {
    path: 'room-details/:id',
    component: RoomDetailsPageComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
