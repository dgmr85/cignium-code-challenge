import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Subject } from 'rxjs';
import { SearchResult } from '../model/SearchResult';

@Injectable({
  providedIn: 'root'
})
export class ResultsService {
  private url = "http://localhost:5000/api/SearchEngine/Search";
  private resultSubject = new Subject<{ searchResult: SearchResult[], finalWinner:string}>();

  constructor(private http: HttpClient) {}

  getResults(searchQuery: string) {
    const queryBody = {
      searchQuery
    };

    this.http.post<{result:SearchResult[], finalWinner:string}>(this.url,queryBody)
    .subscribe(response => {
        this.resultSubject.next({ searchResult: [...response.result], finalWinner: response.finalWinner});
    })
  }

  getResultSubject() {
    return this.resultSubject.asObservable();
  }
}
