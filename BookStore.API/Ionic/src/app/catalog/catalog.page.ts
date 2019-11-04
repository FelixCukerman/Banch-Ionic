import { Component, OnInit } from '@angular/core';
import { ResponseBookItemsViewModel } from '../viewmodels/responseBookItemsViewModel';
import { booksData } from 'src/app/shared/mocked/booksData';

@Component({
  selector: 'app-catalog',
  templateUrl: 'catalog.page.html',
  styleUrls: ['catalog.page.scss']
})
export class CatalogPage implements OnInit {
    public inputSpeedRange = [5, 500];
    public booksFilter: boolean;
    public newspapersFilter: boolean;
    public magazineFilter: boolean;
    public mockedBookItems: Array<ResponseBookItemsViewModel>;
    constructor() {}

    public ngOnInit(): void {
        this.booksFilter = false;
        this.newspapersFilter = false;
        this.magazineFilter = false;
        this.mockedBookItems = booksData;
    }

    public filterBooks(): void {
        debugger;
    }
}
