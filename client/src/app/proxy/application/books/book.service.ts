import { RestService, Rest } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { BookDTO, CreateUpdateBookDTO } from '../contracts/books/models';

@Injectable({
  providedIn: 'root',
})
export class BookService {
  apiName = 'Default';
  

  create = (input: CreateUpdateBookDTO, config?: Partial<Rest.Config>) =>
    this.restService.request<any, BookDTO>({
      method: 'POST',
      url: '/api/app/book',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/book/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, BookDTO>({
      method: 'GET',
      url: `/api/app/book/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getList = (input: PagedAndSortedResultRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<BookDTO>>({
      method: 'GET',
      url: '/api/app/book',
      params: { sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: CreateUpdateBookDTO, config?: Partial<Rest.Config>) =>
    this.restService.request<any, BookDTO>({
      method: 'PUT',
      url: `/api/app/book/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
