import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/services/api.service';
import { PaginatedRequest, PaginatedData } from 'src/models/pagination';
import { KarmaItem } from 'src/models/karma';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {
    isLoaded = false;
    data: PaginatedData<KarmaItem>;

    constructor(private api: ApiService) { }

    ngOnInit() {
        this.getData(1);
    }

    private getData(page: number) {
        const request: PaginatedRequest = { page };

        this.api.getKarmaData(request).subscribe(data => {
            this.data = data;
            this.isLoaded = true;
        });
    }

    onPageChanged(page: number) {
        this.getData(page);
    }
}
