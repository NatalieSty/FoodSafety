import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { User } from '../models/User';
import { AuthService } from 'src/_services/auth.service';
import { AlertifyService } from 'src/_services/alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  user: User;
  @Output() cancelRegister = new EventEmitter();

  
  constructor(private authService: AuthService, private alert: AlertifyService,
              private fb: FormBuilder, private router: Router) { }

  ngOnInit() {
    this.createRegisterForm();
  }

  createRegisterForm() {
    this.registerForm = this.fb.group({
      username: ['', Validators.required],
      zipCode: ['', Validators.required],
      password: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(8)]],
      confirmPassword: ['', Validators.required]
    }, {validator: this.passwordMatchValidator});
  }

  passwordMatchValidator(g: FormGroup){
    return g.get('password').value === g.get('confirmPassword').value ? null : {'mismatch': true};
  }

  register() {
    if (this.registerForm.valid) {
      this.user = Object.assign({}, this.registerForm.value);
      this.authService.register(this.user).subscribe(() => {
        this.alert.success('registration success');
      }, error => {
        this.alert.error(error);
      }, () => {
        this.authService.login(this.user).subscribe(() => {
          this.router.navigate(['/home']);
        });
      });
    }
  }

  cancel() {
    this.cancelRegister.emit(false);
  }

}
