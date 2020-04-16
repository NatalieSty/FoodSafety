import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/_services/auth.service';
import { Router } from '@angular/router';
import { User } from '../models/User';
import { AlertifyService } from 'src/_services/alertify.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};
  user: User;

  constructor(public authService: AuthService, private router: Router, private alert: AlertifyService) {

  }

  ngOnInit() {
    this.user = this.authService.currentUser;
  }

  login() {
    this.authService.login(this.model).subscribe(next => {
      this.alert.success("Logged In")
    }, error => {
      this.alert.error("Error logging in")
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
