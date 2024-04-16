import { Routes } from '@angular/router';

export const routes: Routes = [
    { path: '', redirectTo: '/home', pathMatch: 'full' },
    { 
        path: 'home',
        loadComponent: () => import('./features/EventLogger/EventLogger.component').then(c => c.EventLoggerComponent) 
    },
    {
        path: 'eventForm',
        loadComponent: () => import('./features/EventLoggerForm/EventLoggerForm.component').then(c => c.EventLoggerFormComponent)
    },
    { path: '**', redirectTo: '/home' }
];
