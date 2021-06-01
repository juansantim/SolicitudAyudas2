export interface  PaginatedResult<T>{
    TotalItems: number;
    Data: Array<T>;
}