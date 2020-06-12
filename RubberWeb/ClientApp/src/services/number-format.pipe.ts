import { PipeTransform, Pipe } from '@angular/core';

@Pipe({
    name: 'numberFormat'
})
export class NumberFormatPipe implements PipeTransform {
    transform(value: number, ...args: any[]) {
        return String(value).replace(/(?!^)(?=(?:\d{3})+$)/g, ' ');
    }
}
