import { ResponseBookItemsViewModel } from '../../viewmodels/responseBookItemsViewModel';

let bookItems = [];

for (let i = 0; i < 8; i++) {
    let newItem = new ResponseBookItemsViewModel("assets/images/1.jpg", "Loren", "Ipsum", 12);
    bookItems.push(newItem);
}

export const booksData = bookItems;