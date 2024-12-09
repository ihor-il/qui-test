import { Component, OnDestroy } from '@angular/core';
import { FormsModule, NgModel } from '@angular/forms';
import { MatButton } from '@angular/material/button';
import { MatFormField, MatInput } from '@angular/material/input';
import { WeatherForecastService } from '../../services/weather-forecast.service';
import {
  Observable,
  Subject,
  Subscribable,
  Subscription,
  takeUntil,
} from 'rxjs';
import { WeatherForecastModel } from '../../model/weather-forecast.model';
import { WeatherDataComponent } from '../weather-data/weather-data.component';
import { AsyncPipe, NgIf } from '@angular/common';

@Component({
  selector: 'app-search',
  imports: [
    MatFormField,
    MatInput,
    MatButton,
    FormsModule,
    WeatherDataComponent,
    NgIf,
    AsyncPipe,
  ],
  templateUrl: './search.component.html',
  styleUrl: './search.component.scss',
  standalone: true,
})
export class SearchComponent implements OnDestroy {
  private readonly _unsub$ = new Subject<void>();

  public result?: WeatherForecastModel;
  public sub?: Subscription;

  public prompt: string = '';

  constructor(private service: WeatherForecastService) {}

  ngOnDestroy(): void {
    this._unsub$.next();
    this._unsub$.complete();
  }

  search() {
    this.sub = this.service
      .search(this.prompt)
      .pipe(takeUntil(this._unsub$))
      .subscribe((d) => (this.result = d));
  }
}
