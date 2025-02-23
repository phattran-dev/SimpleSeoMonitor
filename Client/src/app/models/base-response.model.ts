export interface BaseResponse<T> {
  isSuccess: boolean;
  data?: T;
  errorMessages?: string;
}
