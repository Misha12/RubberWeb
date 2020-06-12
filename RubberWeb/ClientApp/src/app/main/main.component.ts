import { Component, Input } from '@angular/core';
import { PaginatedData } from 'src/models/pagination';
import { KarmaItem } from 'src/models/karma';

@Component({
    selector: 'app-main',
    templateUrl: './main.component.html'
})
export class MainComponent {
    @Input() data: PaginatedData<KarmaItem>;

    get json() {
        return JSON.stringify(this.data);
    }
}
