import { NgModule } from '@angular/core';
import { LayoutComponent } from './layout/layout.component';
import { SearchComponent } from './search/search.component';
import { ResultItemComponent } from './results/result-item/result-item.component';
import { ResultListComponent } from './results/result-list/result-list.component';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { LayoutRoutingModule } from './layout-routing.module';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';

@NgModule({
    declarations: [
        LayoutComponent,
        SearchComponent,
        ResultListComponent,
        ResultItemComponent
    ],
    imports: [
        CommonModule,
        HttpClientModule,
        RouterModule,
        LayoutRoutingModule,
        FormsModule
    ]
})
export class LayoutModule {

}
