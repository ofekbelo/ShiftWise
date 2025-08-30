import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';

export const api = createApi({
    reducerPath: 'api',
    baseQuery: fetchBaseQuery({
        baseUrl: import.meta.env.VITE_API_BASE ?? 'http://localhost:5232',
    }),
    endpoints: (builder) => ({
        getHealth: builder.query<{ status: string }, void>({
            query: () => '/health',
        }),
        getEmployees: builder.query<{ id: string; fullName: string }[], void>({
            query: () => '/employees',
        }),
    }),
});

export const { useGetHealthQuery, useGetEmployeesQuery } = api;
