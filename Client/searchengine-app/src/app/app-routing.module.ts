import { NgModule } from '@angular/core';
import { Routes, RouterModule, PreloadAllModules } from '@angular/router';

const routes: Routes = [
    { path:'search',loadChildren: () => import('./layout/layout.module').then(m=>m.LayoutModule) },
    { path: '**', redirectTo: 'search'  }
  ];

@NgModule({
    imports:[
        RouterModule.forRoot(routes,{preloadingStrategy:PreloadAllModules})
    ],
    exports:[RouterModule]
})
export class AppRoutingModule {}