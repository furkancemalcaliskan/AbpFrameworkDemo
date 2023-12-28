import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'AbpFrameworkDemo',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44323/',
    redirectUri: baseUrl,
    clientId: 'AbpFrameworkDemo_App',
    responseType: 'code',
    scope: 'offline_access AbpFrameworkDemo',
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:44366',
      rootNamespace: 'AbpFrameworkDemo',
    },
  },
} as Environment;
