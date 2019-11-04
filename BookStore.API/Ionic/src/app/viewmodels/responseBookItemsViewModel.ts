export class ResponseBookItemsViewModel {
    constructor(imgUrl, title, author, price) {
        this.imgUrl = imgUrl;
        this.title = title;
        this.author = author;
        this.price = price;
    }

    public imgUrl: string;
    public title: string;
    public author: string;
    public price: number;
}