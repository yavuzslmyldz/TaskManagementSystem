import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Comment } from '../app-model/comment.model';

@Injectable({
  providedIn: 'root',
})
export class CommentService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  private postRoute: string = this.baseUrl + "comment"
  private _headers = { 'Content-Type': 'application/json' };

   create(_body: any): Observable<void> {
     return this.http.post<void>(this.postRoute, _body, { headers: this._headers });
  }

  update(_body: any): Observable<number> {
    return this.http.put<number>(this.postRoute, _body, { headers: this._headers });
  }

  delete(_params: any): Observable<number> {
    return this.http.delete<number>(this.postRoute, { params: _params, headers: this._headers });
  }

  get(_params: any): Observable<Comment> {
    return this.http.get<Comment>(this.postRoute, { params: _params, headers: this._headers });
  }

  getAll(_params: any): Observable<Comment[]> {
    return this.http.get<Comment[]>(this.postRoute + "/all", { params: _params, headers: this._headers });
  }
}
