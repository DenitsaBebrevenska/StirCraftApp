import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DatetimeService {
  toLocalTime(utcDate: string): string {
    return new Date(utcDate).toLocaleString();
  }
}