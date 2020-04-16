export interface Pagination {
    currentPage: number;
    itemsPerPage: number;
    totalItems: number;
    totalPages: number;
}

// result: users etc
export class PaginatedResult<T> {
    result: T;
    pagination: Pagination;
}
