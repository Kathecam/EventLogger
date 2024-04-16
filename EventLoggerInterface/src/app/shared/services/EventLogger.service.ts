import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';
import { EventLog } from '../interfaces/EventLog';

@Injectable({
  providedIn: 'root'
})
export class EventLoggerService {

  constructor(private http: HttpClient) { }

  getAll(): Observable<EventLog[]> {
    return this.http.get<EventLog[]>(`${environment.URI_API}/EventLogs`);
  }

  getOne(id: number) {
    return this.http.get(`${environment.URI_API}/EventLogs/${id}`);
  }

  create(data: EventLog): Observable<any> {
    return this.http.post<any>(`${environment.URI_API}/EventLogs`, data);
  }

  search(startDate: Date, endDate: Date): Observable<EventLog[]> {
    return this.http.get<EventLog[]>(`${environment.URI_API}/EventLogs/${startDate+'T00:00:00.482Z'}/${endDate+'T23:59:59.482Z'}`);
  }
}
