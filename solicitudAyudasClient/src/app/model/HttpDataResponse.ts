export interface HttpDataResponse<T> {
    Success: boolean;
    Data: T;
    Errors: string[];
    
}