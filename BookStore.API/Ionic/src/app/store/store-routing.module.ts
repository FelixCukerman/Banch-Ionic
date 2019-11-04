import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StorePage } from './store.page';

const routes: Routes = [
  {
    path: 'store',
    component: StorePage,
    children: [
      {
        path: 'catalog',
        children: [
          {
            path: '',
            loadChildren: () => import('../catalog/catalog.module').then(m => m.CatalogPageModule)
          }
        ]
      },
      {
        path: '',
        redirectTo: '/store/catalog',
        pathMatch: 'full'
      }
    ]
  },
  {
    path: '',
    redirectTo: '/store/catalog',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class StorePageRoutingModule {}
