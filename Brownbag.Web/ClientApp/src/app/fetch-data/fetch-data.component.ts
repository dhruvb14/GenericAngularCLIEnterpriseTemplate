import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: Brownbag.Web.Models.WeatherForecastViewModel[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Brownbag.Web.Models.WeatherForecastViewModel[]>(baseUrl + 'api/SampleData/WeatherForecasts').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
  }
}
