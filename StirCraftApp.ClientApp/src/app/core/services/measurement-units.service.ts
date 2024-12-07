import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { HttpClient, HttpParams } from '@angular/common/http';
import { MeasurementUnitParams } from '../../shared/models/measurementUnit/measurementUnitParams';
import { MeasurementUnit } from '../../shared/models/measurementUnit/measurementUnit';

@Injectable({
  providedIn: 'root'
})
export class MeasurementUnitsService {
  baseUrl = environment.apiUrl;
  private http = inject(HttpClient);

  getUnits() {
    return this.http.get<MeasurementUnit[]>(this.baseUrl + 'measurementUnits');
  }

}
