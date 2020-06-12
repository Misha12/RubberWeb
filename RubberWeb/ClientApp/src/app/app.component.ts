import { Component, OnInit, ViewChild } from '@angular/core';
import { ApiService } from 'src/services/api.service';
import { PaginatedRequest, PaginatedData } from 'src/models/pagination';
import { KarmaItem } from 'src/models/karma';
import { MainComponent } from './main/main.component';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {
    isLoaded = false;
    data: PaginatedData<KarmaItem>;

    @ViewChild('main', { static: false }) mainComponent: MainComponent;

    constructor(private api: ApiService) { }

    ngOnInit() {
        this.getData(1);
    }

    private getData(page: number) {
        const request: PaginatedRequest = { page };

        this.api.getKarmaData(request).subscribe(data => {
            this.data = data;
            this.isLoaded = true;

            if (this.mainComponent) {
                this.mainComponent.loading = false;
            }
        });
    }

    onPageChanged(page: number) {
        this.getData(page);
    }
}
