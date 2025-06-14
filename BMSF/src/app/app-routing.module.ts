import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthComponent } from './Auth/auth/auth.component';
import { BookComponent } from './Books/book/book.component';
import { AdminComponent } from './Admin/admin/admin.component';
import { AuthorComponent } from './Author/author/author.component';
import { UserComponent } from './User/user/user.component';

const routes: Routes = [
  { path: 'auth', component: AuthComponent },
  { path: 'books', component: BookComponent },
  { path: 'admin', component: AdminComponent },
  { path: 'author/:id', component: AuthorComponent },
  { path: 'user/:id', component: UserComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
