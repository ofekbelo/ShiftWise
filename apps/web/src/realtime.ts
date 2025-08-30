import * as signalR from '@microsoft/signalr';

export const hub = new signalR.HubConnectionBuilder()
    .withUrl((import.meta.env.VITE_API_BASE ?? '') + '/hubs/schedule')
    .withAutomaticReconnect()
    .build();
