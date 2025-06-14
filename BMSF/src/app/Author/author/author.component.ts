import { Component } from '@angular/core';
import { AuthorService } from '../author.service';
import { Book} from '../author.service';
import { ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';

@Component({
  selector: 'app-author',
  standalone: false,
  templateUrl: './author.component.html',
  styleUrl: './author.component.css'
})
export class AuthorComponent {
  constructor(private authorService: AuthorService, private route: ActivatedRoute, private router: Router) {}
  book: Book = {
    title: '',
    category: ''
  };
  Books:any[]=[];
  Id: string = '';
  eId: string | null = null;
  show: boolean = false;
  showu : boolean = true;
  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      this.Id = params.get('id') || '';
      console.log('User ID:', this.Id);
      this.GetBooks(); 
    });
  }

  addBook() {
    this.authorService.AddB(this.Id, this.book).subscribe({
      next: response => {
        console.log('Book added:', response.m);
        alert('Book added successfully');
        this.GetBooks(); 
        this.show = false; 
      },
      error: error => {
        console.error('Error adding book:', error);
      }
    });
  }

  GetBooks() {
    this.authorService.getB(this.Id).subscribe({
      next: response => {
        console.log('Book details:', response);
        this.Books = response; 
      },
      error: error => {
        console.error('Error fetching book details:', error);
      }
    });
  }

  updateBook(id: string) {
    this.authorService.UpB(this.Id,id, this.book).subscribe({
      next: response => {
        console.log('Book updated:', response.m);
        alert('Book updated successfully');
        this.GetBooks(); 
      },
      error: error => {
        console.error('Error updating book:', error);
      }
    });
  }
  Fup(id: string) {
    this.eId = id;
  }
  Ab(){
    this.show = true;
    this.showu = false;
  }
}
