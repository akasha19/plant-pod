import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { PlantpediaPageComponent } from './plantpedia-page/plantpedia-page.component';
import { MatCardModule } from '@angular/material/card';
import { RouterModule } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatButtonToggleModule } from '@angular/material/button-toggle';



@NgModule({
  declarations: [
    AppComponent,
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
    MatGridListModule,
    MatButtonToggleModule,
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
