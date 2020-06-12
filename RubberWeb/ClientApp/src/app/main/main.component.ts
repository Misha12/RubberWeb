import { Component, Input, Output, EventEmitter } from '@angular/core';
import { PaginatedData } from 'src/models/pagination';
import { KarmaItem } from 'src/models/karma';

@Component({
    selector: 'app-main',
    templateUrl: './main.component.html',
    styleUrls: ['./main.component.scss']
})
export class MainComponent {
    @Input() data: PaginatedData<KarmaItem>;
    @Input() currentPage = 1;
    @Output() pageChanged = new EventEmitter<number>();

    onPageChange(event: any) {
        this.pageChanged.emit(event);
    }
}
