import { Component, Input, Output, EventEmitter, OnInit, HostListener } from '@angular/core';
import { PaginatedData } from 'src/models/pagination';
import { KarmaItem } from 'src/models/karma';

@Component({
    selector: 'app-main',
    templateUrl: './main.component.html',
    styleUrls: ['./main.component.scss']
})
export class MainComponent implements OnInit {
    @Input() data: PaginatedData<KarmaItem>;
    @Input() currentPage = 1;

    @Output() pageChanged = new EventEmitter<number>();

    loading = false;
    maxSize = 0;

    onPageChange(event: any) {
        this.pageChanged.emit(event);
        this.loading = true;
    }

    ngOnInit() {
        this.maxSize = this.computeMaxSize();
    }

    @HostListener('window:resize', ['$event'])
    onResize(_: any) {
        this.maxSize = this.computeMaxSize();
    }

    computeMaxSize() {
        const width = document.body.clientWidth;

        if (width < 700) {
            return 2;
        } else if (width < 1000) {
            return 10;
        } else if (width < 1500) {
            return 20;
        } else {
            return 50;
        }
    }
}
