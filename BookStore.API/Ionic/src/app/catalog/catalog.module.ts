import { IonicModule } from '@ionic/angular';
import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CatalogPage } from './catalog.page';
import { NouisliderModule } from 'ng2-nouislider';

@NgModule({
  imports: [
    IonicModule,
    CommonModule,
    FormsModule,
    NouisliderModule,
    RouterModule.forChild([{ path: '', component: CatalogPage }])
  ],
  declarations: [CatalogPage]
})
export class CatalogPageModule {}
