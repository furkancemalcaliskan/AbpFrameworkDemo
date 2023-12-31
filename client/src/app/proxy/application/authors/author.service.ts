import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { AuthorDTO, CreateAuthorDTO, GetAuthorListDTO, UpdateAuthorDTO } from '../contracts/authors/models';

@Injectable({
  providedIn: 'root',
})
export class AuthorService {
  apiName = 'Default';
  

  create = (input: CreateAuthorDTO, config?: Partial<Rest.Config>) =>
    this.restService.request<any, AuthorDTO>({
      method: 'POST',
      url: '/api/app/author',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/author/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, AuthorDTO>({
      method: 'GET',
      url: `/api/app/author/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetAuthorListDTO, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<AuthorDTO>>({
      method: 'GET',
      url: '/api/app/author',
      params: { filter: input.filter, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: UpdateAuthorDTO, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'PUT',
      url: `/api/app/author/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
