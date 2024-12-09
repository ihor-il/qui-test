import { ChangeDetectionStrategy, Component, Input } from '@angular/core';
import { WeatherForecastModel } from '../../model/weather-forecast.model';

@Component({
  selector: 'app-weather-data',
  imports: [],
  templateUrl: './weather-data.component.html',
  styleUrl: './weather-data.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
  standalone: true
})
export class WeatherDataComponent {
  @Input({ required: true }) data!: WeatherForecastModel;
}
