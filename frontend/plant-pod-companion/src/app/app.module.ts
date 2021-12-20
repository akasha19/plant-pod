import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { SensorOverviewComponent } from './sensor-overview/sensor-overview.component';
import { MatCardModule } from "@angular/material/card";
import { PlantpediaPageComponent } from './plantpedia-page/plantpedia-page.component';
import { RouterModule } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatToolbarModule } from '@angular/material/toolbar';

@NgModule({
  declarations: [
    AppComponent,
    SensorOverviewComponent,
    PlantpediaPageComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NoopAnimationsModule,
    MatCardModule,
    MatButtonModule,
    MatTooltipModule,
    MatToolbarModule,
    RouterModule.forRoot([
      {
        path: 'plantpedia',
        component: PlantpediaPageComponent
      },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})

export class AppModule { }
