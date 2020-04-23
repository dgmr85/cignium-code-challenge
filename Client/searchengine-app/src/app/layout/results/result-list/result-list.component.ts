import { Component, OnInit, OnDestroy } from '@angular/core';
import { EngineResult } from '../../model/EngineResult';
import { Subscription } from 'rxjs';
import { ResultsService } from '../results.service';
import { SearchResult } from '../../model/SearchResult';

@Component({
    selector:'app-result-list',
    templateUrl:'./result-list.component.html',
    styleUrls: ['./result-list.component.scss']
})
export class ResultListComponent implements OnInit,OnDestroy {
    results: SearchResult[] = [];
    finalWinner:string;
    private resultSub = new Subscription();

    constructor(private searchService: ResultsService) {}

    ngOnInit() {
      this.resultSub = this.searchService.getResultSubject()
      .subscribe(payload => {
        this.results = payload.searchResult;
        this.finalWinner = payload.finalWinner;
        console.log(this.results);
      });
    }

    ngOnDestroy() {
      this.resultSub.unsubscribe();
    }
}
