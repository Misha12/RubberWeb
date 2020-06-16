import { Component, OnInit, ViewChild } from '@angular/core';
import { ApiService } from 'src/services/api.service';
import { PaginatedRequest, PaginatedData } from 'src/models/pagination';
import { KarmaItem } from 'src/models/karma';
import { MainComponent } from './main/main.component';
import { StorageService } from 'src/services/storage.service';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {
    isLoaded = false;
    data: PaginatedData<KarmaItem>;

    pageCount = 50;

    @ViewChild('main', { static: false }) mainComponent: MainComponent;

    constructor(
        private api: ApiService,
        private storage: StorageService
    ) { }

    ngOnInit() {
        const page = this.getPage();
        this.getData(page);
    }

    private getPage() {
        const pathElements = location.pathname.split('/');
        const page = parseInt(pathElements[pathElements.length - 1], 10);

        if (!page || isNaN(page)) {
            return parseInt(this.storage.get('page', 'session') || '1', 10);
        }

        return page;
    }

    private getData(page: number) {
        const request: PaginatedRequest = { page, limit: this.pageCount };

        window.history.replaceState({}, '', `/${page}`);
        this.api.getKarmaData(request).subscribe(data => {
            this.data = data;
            this.isLoaded = true;

            if (this.mainComponent) {
                this.mainComponent.loading = false;
            }

            this.storage.store('page', page.toString(), 'session');
        });
    }

    onPageChanged(page: number) {
        this.getData(page);
    }
}
