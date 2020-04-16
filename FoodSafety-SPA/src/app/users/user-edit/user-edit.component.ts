import { Component, OnInit, ViewChild } from '@angular/core';
import { UserService } from 'src/_services/user.service';
import { AlertifyService } from 'src/_services/alertify.service';
import { AuthService } from 'src/_services/auth.service';
import { ActivatedRoute, Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { User } from 'src/app/models/User';

@Component({
  selector: 'app-user-edit',
  templateUrl: './user-edit.component.html',
  styleUrls: ['./user-edit.component.css']
})
export class UserEditComponent implements OnInit {
  @ViewChild('editForm', {static: true}) editForm: NgForm;
  user: User;

  constructor(private userService: UserService, private alert: AlertifyService, private route: ActivatedRoute, 
              private authService: AuthService, private router: Router) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.user = data['data'];
    });
  }

  updateUser() {
    this.userService.updateUser(this.authService.decodedToken.nameid, this.user)
      .subscribe(next => {
        this.alert.success('Updated successfully!');
        this.editForm.reset(this.user);
        this.router.navigate(['/home']);
      }, error => {
        this.alert.error('error updating user');
      });
  }

}
