import { PipeTransform, Pipe } from '@angular/core';

@Pipe({
    name: 'numberFormat'
})
export class NumberFormatPipe implements PipeTransform {
    transform(value: number, ...args: any[]) {
        // see: https://stackoverflow.com/a/54036800
        return String(value).replace(/(?!^)(?=(?:\d{3})+$)/g, ' ');
    }
}
