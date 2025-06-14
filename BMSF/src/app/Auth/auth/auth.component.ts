import { Component } from '@angular/core';
import { AuthSService } from '../auth-s.service';
import { Cred } from '../auth-s.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-auth',
  standalone: false,
  templateUrl: './auth.component.html',
  styleUrl: './auth.component.css'
})
export class AuthComponent {
  cred: Cred = { uname: '', password: '' };
  title = 'BMSF';
  show : boolean = false;
  change : boolean = false;
  constructor( private authservice: AuthSService,private router: Router) {
  }
  registerU(){
    this.authservice.registeru(this.cred).subscribe({
      next: (response) => {
        console.log('Registration successful', response);
        alert(response.message);
      },
      error: (err) => {
        console.error('Registration failed', err.message);
        alert('Registration failed: ' + err.message);
      }
    });
  }
  loginU() {
    this.authservice.login(this.cred).subscribe({
      next: (response : any) => {
        console.log('Login successful', response);
        alert('Login successful');
        if(response.uname === 'admin') {
          this.router.navigate([`/admin`]);
        } else {
          this.router.navigate([`/user/${response.id}`]);
        }
      },
      error: (error) => {
        console.error('Login failed', error.message);
        alert('Login failed: ' + error.message);
      }
    });
  }
  registerA() {
    this.authservice.registera(this.cred).subscribe({
      next: (response) => {
        console.log('registration successful', response);
        alert("registration successful : authentication Request sent to admin");
      },
      error: (err) => {
        console.error('registration failed', err.message);
        alert('registration failed: ' + err.message);
      }
    });
  }
  loginA() {
    this.authservice.logAu(this.cred).subscribe({
      next: (response:any) => {
        console.log('login successful', response);
        alert("login successful");
        this.router.navigate([`/author/${response.id}`]);
      },
      error: (err) => {
        console.error('login failed', err.message);
        alert('login failed: ' + err.message);
      }
    });
  }
 toogle() {
    this.show = !this.show;
  }
  changef() {
    this.change = !this.change;
  }
}