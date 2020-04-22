import { Component } from '@angular/core';
import { ResultsService } from '../results/results.service';

@Component({
    selector:'app-search',
    templateUrl:'./search.component.html',
    styleUrls: ['./search.component.scss']
})
export class SearchComponent {
  searchQuery: string;
  constructor(private searchService: ResultsService) {}

  onSubmit() {
    this.searchService.getResults(this.searchQuery);
  }
}
