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
    page = 1;
    data: PaginatedData<KarmaItem>;

    constructor(private api: ApiService) { }

    ngOnInit() {
        const request: PaginatedRequest = { limit: 100, page: this.page };

        this.api.getKarmaData(request).subscribe(data => {
            this.data = data;
            this.isLoaded = true;
        });
    }
}
