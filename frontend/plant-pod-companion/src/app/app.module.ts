import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { SensorOverviewComponent } from './sensor-overview/sensor-overview.component';
import { MatCardModule } from "@angular/material/card";
import { PlantpediaPageComponent } from './plantpedia-page/plantpedia-page.component';
import { RoomOverviewPageComponent } from './room-overview-page/room-overview-page.component';
import { RouterModule } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatGridListModule } from '@angular/material/grid-list';
@NgModule({
  declarations: [
    AppComponent,
    PlantpediaPageComponent,
    RoomOverviewPageComponent,
    SensorOverviewComponent,
    PlantpediaPageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NoopAnimationsModule,
    MatCardModule,
    MatButtonModule,
    MatTooltipModule,
    MatGridListModule,
    MatToolbarModule,
    RouterModule.forRoot([
      {
        path: 'plantpedia',
        component: PlantpediaPageComponent
      },
      {
        path: 'room-overview',
        component: RoomOverviewPageComponent
      }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})

export class AppModule { }
