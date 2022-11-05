import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Duty } from '../app-model/duty.model';

@Injectable({
  providedIn: 'root',
})
export class TaskService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  private postRoute = this.baseUrl + "task"
  private _headers = { 'Content-Type': 'application/json' };

  create(_body: any): Observable<number> {
    return this.http.post<number>(this.postRoute, _body, { headers: this._headers });
  }

  update(_body: any): Observable<number> {
    return this.http.post<number>(this.postRoute, _body, { headers: this._headers });
  }

  delete(_params: any): Observable<number> {
    return this.http.delete<number>(this.postRoute, { params: _params, headers: this._headers });
  }

  get(_params: any): Observable<Duty> {
    return this.http.get<Duty>(this.postRoute, { params: _params, headers: this._headers });
  }

  getAll(): Observable<Duty[]> {
    return this.http.get<Duty[]>(this.postRoute + "/all", { headers: this._headers });
  }
}
