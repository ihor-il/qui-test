import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { MatTabsModule } from '@angular/material/tabs';
import { NgTemplateOutlet } from '@angular/common';
import { SearchComponent } from './components/search/search.component';
import { HistoryComponent } from "./components/history/history.component";

@Component({
  selector: 'app-root',
  imports: [MatTabsModule, SearchComponent, HistoryComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent {
  title = 'weather-app-web';
}
