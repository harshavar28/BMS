import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthComponent } from './Auth/auth/auth.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AdminComponent } from './Admin/admin/admin.component';
import { BookComponent } from './Books/book/book.component';
import { AuthorComponent } from './Author/author/author.component';
import { UserComponent } from './User/user/user.component';

@NgModule({
  declarations: [
    AppComponent,
    AuthComponent,
    AdminComponent,
    BookComponent,
    AuthorComponent,
    UserComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
