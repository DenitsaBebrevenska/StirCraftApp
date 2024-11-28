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
  
  getUnits(measurementUnitParams: MeasurementUnitParams) {
    let params = new HttpParams();

    if(measurementUnitParams.isSolidSpecific){
      params = params.append('isSolidSpecific', measurementUnitParams.isSolidSpecific.toString());
    }

    if(measurementUnitParams.isLiquidSpecific){
      params = params.append('isLiquidSpecific', measurementUnitParams.isLiquidSpecific.toString());
    }

    return this.http.get<MeasurementUnit[]>(this.baseUrl + 'measurementUnits', { params });
  }

}
