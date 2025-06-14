import { Component, Input, SimpleChanges } from '@angular/core';
import { BookService } from '../book.service';


@Component({
  selector: 'app-book',
  standalone: false,
  templateUrl: './book.component.html',
  styleUrl: './book.component.css'
})
export class BookComponent {
  books: any[] = []; 
 constructor(private bookService: BookService) { }
 @Input() uid!: string;
 @Input() drpval!: string;

 ngOnChanges(changes: SimpleChanges) {
  console.log('Changes detected:', this.drpval);
  console.log('Changes detected:', this.uid);
  if (changes['drpval']) {
    if (this.drpval === 'All') {
      this.bookService.getBooks().subscribe({
        next: (response) => {
          this.books = response;
          console.log('Books fetched successfully', response);
        },
        error: (err) => {
          console.error('Error fetching books', err);
          alert('Error fetching books');
        }
      });
    }
    else{
    this.bookService.getC(this.drpval).subscribe({
      next: (response) => {
        this.books = response;
        console.log('Books fetched successfully', response);
      },
      error: (err) => {
        console.error('Error fetching books', err);
        alert('Error fetching books');
      }
    });
  }
  }
}

  addToCart(bId: string) {
    this.bookService.addToCart( bId,this.uid).subscribe({
      next: (response) => {
        console.log('Book added to cart:', response);
        alert('Book added to cart successfully');
      },
      error: (err) => {
        console.error('Error adding book to cart', err);
      }
    });
  }
}
