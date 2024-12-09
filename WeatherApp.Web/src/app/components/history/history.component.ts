import { Component, OnInit } from '@angular/core';
import { WeatherForecastService } from '../../services/weather-forecast.service';
import { Observable, Subscription } from 'rxjs';
import { WeatherForecastModel } from '../../model/weather-forecast.model';
import { AsyncPipe } from '@angular/common';
import { WeatherDataComponent } from '../weather-data/weather-data.component';

@Component({
  selector: 'app-history',
  imports: [AsyncPipe, WeatherDataComponent],
  templateUrl: './history.component.html',
  styleUrl: './history.component.scss',
  standalone: true,
})
export class HistoryComponent implements OnInit {
  //FIXME: Session cookie is not saving automatically

  public data$?: Observable<WeatherForecastModel[]>;
  private sub?: Subscription;

  get loading(): boolean {
    return this.sub != undefined && !this.sub?.closed;
  }

  constructor(private service: WeatherForecastService) { }

  ngOnInit(): void {
    this.reload();
  }

  reload() {
    this.data$ = this.service.getHistory();
  }
}
