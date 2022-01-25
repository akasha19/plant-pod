import { InjectionToken, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SensorOverviewComponent } from './sensor-overview/sensor-overview.component';
import { MatCardModule } from "@angular/material/card";
import { PlantpediaPageComponent } from './plantpedia-page/plantpedia-page.component';
import { RoomOverviewPageComponent } from './room-overview-page/room-overview-page.component';
import { MatButtonModule } from '@angular/material/button';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatToolbarModule } from '@angular/material/toolbar';
import { RoomDetailsPageComponent } from './room-details-page/room-details-page.component';
import { WarningComponent } from './warning/warning.component';
import { PlantDetailsPageComponent } from './plant-details-page/plant-details-page.component';
import { HttpClientModule } from '@angular/common/http';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { LoadingIndicatorComponent } from './loading-indicator/loading-indicator.component';

export const SERVICE_URL = new InjectionToken<string>('service.url');
@NgModule({
  declarations: [
    AppComponent,
    RoomOverviewPageComponent,
    SensorOverviewComponent,
    PlantpediaPageComponent,
    RoomDetailsPageComponent,
    PlantDetailsPageComponent,
    LoadingIndicatorComponent,
    WarningComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MatCardModule,
    MatButtonModule,
    MatTooltipModule,
    MatToolbarModule,
    HttpClientModule,
    MatProgressSpinnerModule
  ],
  providers: [{ provide: SERVICE_URL, useValue: "http://localhost:8588/" }],
  bootstrap: [AppComponent]
})

export class AppModule { }
