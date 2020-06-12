import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PaginatedRequest, PaginatedData } from 'src/models/pagination';
import { KarmaItem } from 'src/models/karma';
import { APP_BASE_HREF } from '@angular/common';

@Injectable({ providedIn: 'root' })
export class ApiService {
    constructor(
        private httpClient: HttpClient,
        @Inject(APP_BASE_HREF) private baseHref: string
    ) { }

    getKarmaData(request: PaginatedRequest) {
        const queryParams = this.createPaginatedParams(request)
            .map(o => `${o.key}=${o.value}`)
            .join('&');

        let url = `${this.baseHref}/api/karma?${queryParams}`;
        if (url.startsWith('//')) {
            url = url.substring(1);
        }

        return this.httpClient.get<PaginatedData<KarmaItem>>(url);
    }

    private createPaginatedParams(request: PaginatedRequest) {
        const data: { key: string; value: any }[] = [];

        if (request.limit) {
            data.push({ key: 'limit', value: request.limit });
        }

        if (request.page) {
            data.push({ key: 'page', value: request.page });
        }

        if (request.sort) {
            data.push({ key: 'sort', value: request.sort as number });
        }

        return data;
    }
}
