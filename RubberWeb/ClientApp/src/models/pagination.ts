export enum PageSort {
    Asc = 0,
    Desc = 1
}

export interface PaginatedRequest {
    limit?: number;
    page?: number;
    sort?: PageSort;
}

export interface PaginatedData<T> {
    data: T[];
    page: number;
    totalItemsCount: number;
    canNext: boolean;
    canPrev: boolean;
}
