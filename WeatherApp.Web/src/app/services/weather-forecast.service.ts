import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environment';
import { WeatherForecastModel } from '../model/weather-forecast.model';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class WeatherForecastService {
  constructor(private client: HttpClient) {}

  public search(city: string): Observable<WeatherForecastModel> {
    const url = `${environment.apiUrl}/search/${city}`;
    return this.client.get<WeatherForecastModel>(url);
  }

  public getHistory(): Observable<WeatherForecastModel[]> {
    const url = `${environment.apiUrl}/history`;
    return this.client.get<WeatherForecastModel[]>(url);
  }
}
