import { Component } from '@angular/core';
import { UserService } from '../user.service';
import { ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';

interface Books {
  title: string;
  name: string;
  category: string;
}

@Component({
  selector: 'app-user',
  standalone: false,
  templateUrl: './user.component.html',
  styleUrl: './user.component.css'
})
export class UserComponent {
  constructor(private userService: UserService, private route: ActivatedRoute, private router: Router) {}
  data: Books[] = [];
  Id: string = '';
  show: boolean = false;
  bshow: boolean = false;
  opt : string[] =[];
  drpv: string ='All'; 
  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      this.Id = params.get('id') || '';
      console.log('User ID:', this.Id); 
      this.getop();
      console.log('Dropdown value:', this.drpv);
    });
  }

  getUCarts() {
    this.userService.getUC(this.Id).subscribe({
      next: (response) => {
        this.data = response;
        console.log('User carts fetched successfully', this.data);
        this.show = true; 
        this.bshow = true;
      },
      error: (err) => {
        console.error('Error fetching user carts', err.error.m);
        alert('Error fetching user carts');
      }
    });
  }

  getUBooks() {
    this.userService.getUB(this.Id).subscribe({
      next: (response) => {
        this.data = response;
        console.log('User books fetched successfully', this.data);
        this.show = false;
        this.bshow = true;
      },
      error: (err) => {
        console.error('Error fetching user books', err.error.m);
      }
    });
  }
  getop() {
    this.userService.getp().subscribe({
      next: (response) => {
        this.opt = ['All',...response];
        this.drpv = this.opt[0];
        console.log('Available books fetched successfully', this.opt);
      },
      error: (err) => {
        console.error('Error fetching available books', err);
      }
    });
  }
}
