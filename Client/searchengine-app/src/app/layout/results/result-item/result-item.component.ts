import { Component, Input } from '@angular/core';
import { EngineResult } from '../../model/EngineResult';
import { SearchResult } from '../../model/SearchResult';

@Component({
    selector:'app-result-item',
    templateUrl:'./result-item.component.html',
    styleUrls: ['./result-item.component.scss']
})
export class ResultItemComponent {
    @Input() result: SearchResult
}
