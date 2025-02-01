import { inject, Pipe, PipeTransform } from '@angular/core';
import { DatetimeService } from '../services/datetime.service';

@Pipe({
  name: 'timepipe',
  standalone: true
})
export class TimepipePipe implements PipeTransform {

  private timeService = inject(DatetimeService);

  transform(value: string): string {
    return this.timeService.toLocalTime(value);
  }

}
