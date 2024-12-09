export interface WeatherForecastModel {
  requestedAt: string;
  city: string;
  temperature: number;
  pressure: number;
  humidity: number;
  windSpeed: number;
  windDirection: number;
  windGust: number;
}
