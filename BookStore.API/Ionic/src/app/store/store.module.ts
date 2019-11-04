import { IonicModule } from '@ionic/angular';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { StorePageRoutingModule } from './store-routing.module';

import { StorePage } from './store.page';

@NgModule({
  imports: [
    IonicModule,
    CommonModule,
    FormsModule,
    StorePageRoutingModule
  ],
  declarations: [StorePage]
})
export class StorePageModule {}
