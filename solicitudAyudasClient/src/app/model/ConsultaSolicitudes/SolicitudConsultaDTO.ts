export interface  PaginatedResult<T>{
    totalItems: number;
    data: Array<T>;
}