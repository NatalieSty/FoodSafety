import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/_services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};


  constructor(public authService: AuthService, private router: Router) { }

  ngOnInit() {
  }

  login() {
    this.authService.login(this.model).subscribe(next => {
      console.log('loggedin');
    }, error => {
      console.log('error logging in');
    }, () => {
      this.router.navigate(['/home']);
    })
  }

  loggedIn() {
    return this.authService.loggedIn();
  }

  logout() {
    localStorage.removeItem('token');
    this.router.navigate(['/home']);
    localStorage.removeItem('user');
    this.authService.decodedToken = null;
    this.authService.currentUser = null;
  }

}
