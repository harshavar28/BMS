import { Component } from '@angular/core';
import { AdminService } from '../admin.service';

@Component({
  selector: 'app-admin',
  standalone: false,
  templateUrl: './admin.component.html',
  styleUrl: './admin.component.css'
})
export class AdminComponent {
  Areq: any[] = []; 
  Ureq: any[] = [];
  show: boolean = false;
  constructor(private adminService: AdminService) { }

  getAReqs() {
    this.adminService.getAReq().subscribe({
      next: (data) => {
        console.log('Admin Requests:', data);
        this.Areq = data;
        this.show = true; 
      },
      error: (err) => {
        console.error('Error fetching admin requests:', err);
      }
    });
  }

  AppAReq(id: string) {
    this.adminService.AppAuth(id).subscribe({
      next: (data) => {
        console.log('Admin request approved:', data);
        this.getAReqs(); 
      },
      error: (err) => {
        console.error('Error approving admin request:', err);
      }
    });
  }
  getUReqs() {
    this.adminService.getUReq().subscribe({
      next: (data) => {
        console.log('User Requests:', data);
        this.Ureq = data;
        this.show = true;
      },
      error: (err) => {
        console.error('Error fetching user requests:', err);
      }
    });
  }
  AppUserReq(sId: string, bId: string) {
    this.adminService.AppUser(sId, bId).subscribe({
      next: (data) => {
        console.log('User request approved:', data.m);
        this.getUReqs(); 
      },
      error: (err) => {
        console.error('Error approving user request:', err);
      }
    });
  }
  
}
